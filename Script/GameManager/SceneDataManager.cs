using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

enum EField
{
    Battle,
    Return,
    Potal
}

public class SceneDataManager : MonoBehaviour
{
    private static SceneDataManager _instance;

    public static SceneDataManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("SceneDataManager").AddComponent<SceneDataManager>();
            }
            return _instance;
        }
    }

    private string _beforeFieldScene;
    private Vector2 _position;
    private int _id;
    private EField eField;

    [SerializeField] private Image _image;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Image _progressBackGroundBar;
    [SerializeField] private Text _percentText;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance == this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        //DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += LoadedScreen; // 이벤트에 추가
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= LoadedScreen; // 이벤트에서 제거
    }

    private void SaveFieldSceneData()
    {
        _beforeFieldScene = SceneManager.GetActiveScene().name;
        _position = CharacterManager.instance.basePlayer.gameObject.transform.position;
    }

    public void ReturnToFieldScene()
    {
        if (_beforeFieldScene != null)
        {
            eField = EField.Return;

            if (CharacterManager.instance.npcDic.ContainsKey(CharacterManager.instance.enemy.enemyStatSO.id))
            {
                NPCDataManager.instance.npcDataDictionary[CharacterManager.instance.enemy.enemyStatSO.id].isClear = true;
            }

            Destroy(CharacterManager.instance.enemy.gameObject);
            Destroy(CharacterManager.instance.basePlayer.gameObject);
            CharacterManager.instance.enemy = null;
            CharacterManager.instance.basePlayer = null;

            FadeScreen(_beforeFieldScene);
        }
    }

    private void PlayerSpawnToReturnToField()
    {
        if (CharacterManager.instance.basePlayer == null)
        {
            Debug.Log("basePlayer == null");
            var _playerbject = Instantiate(CharacterManager.instance.fieldPlayer, gameObject.transform);
            _playerbject.transform.position = _position;
        }
        else
        {
            Debug.Log("basePlayer != null");
            CharacterManager.instance.basePlayer.gameObject.transform.position = _position;
        }
    }

    public void EnterToBattleScene(int _npcID)
    {
        eField = EField.Battle;
        _id = _npcID;
        SaveFieldSceneData();
        FadeScreen(Define.SCENE_BATTLE);
    }

    public void SpawnObject()
    {
        CharacterManager.instance.basePlayer = null;

        //배틀씬에 적과 플레이어 소환
        if (NPCDataManager.instance.npcDataDictionary.ContainsKey(_id))
        {
            GameObject _enemy = NPCDataManager.instance.npcDataDictionary[_id].prefab;
            var _enemyObject = Instantiate(_enemy, gameObject.transform);
            _enemyObject.gameObject.transform.position = new Vector2(4.5f, -3.9f);

            //플레이어
            var _playerOject = Instantiate(CharacterManager.instance.battlePlayer, gameObject.transform);
            _playerOject.gameObject.transform.position = new Vector2(-4.5f, -3.9f);
        }
        else
        {
            Debug.Log("Enemy is NULL");
        }
    }

    public void ChangeField()
    {
        CharacterManager.instance.npcDic.Clear();
        CharacterManager.instance.basePlayer = null;
        //SceneManager.LoadScene(Define.SCENE_BATTLE);        //비동기로 바꾸기 ( 이동하려는 씬으로 수정 )
    }

    private void FadeScreen(string _scene)
    {
        _image.gameObject.SetActive(true);

        _image.DOFade(1, 0.5f).OnComplete(
            () => {
                StartCoroutine("LoadScene", _scene);
            });
    }

    private void LoadedScreen(Scene _scene, LoadSceneMode _mode)
    {
        switch (eField)
        {
            case EField.Battle:
                SpawnObject();
                break;
            case EField.Return:
                PlayerSpawnToReturnToField();
                break;
            case EField.Potal:
                break;
        }

        _image.DOFade(0, 0.5f).OnStart(
            () =>
            {
                _progressBar.gameObject.SetActive(false);
                _percentText.gameObject.SetActive(false);
                _progressBackGroundBar.gameObject.SetActive(false);
            })
        .OnComplete(
            () =>
            {
                _image.gameObject.SetActive(false);
            });
    }

    IEnumerator LoadScene(string _scene)
    {
        _progressBackGroundBar.gameObject.SetActive(true);
        _progressBar.gameObject.SetActive(true);
        _percentText.gameObject.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(_scene);
        async.allowSceneActivation = false;

        float _time = 0.0f;
        float _per = 0.0f;

        while (!(async.isDone))
        {
            yield return null;
            _time += Time.deltaTime;

            if(_per >= 90.0f)
            {
                _per = Mathf.Lerp(_per, 100.0f, _time);

                if (_per >= 100.0f)
                {
                    async.allowSceneActivation = true;
                }
            }
            else
            {
                _per = Mathf.Lerp(_per, async.progress * 100f, _time);
                if (_per >= 90.0f) _time = 0.0f;
            }

            _progressBar.fillAmount = _per * 0.01f;
            _percentText.text = _per.ToString("0") + "%"; //로딩 퍼센트 표기
        }
    }
}
