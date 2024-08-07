using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]
    private float m_roughness;      //거칠기 정도
    [SerializeField]
    private float m_magnitude;      //움직임 범위

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Shake(1f));
        }
    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake(1f));
    }

    IEnumerator Shake(float duration)
    {
        float halfDuration = duration / 2;
        float elapsed = 0f;
        float tick = Random.Range(-10f, 10f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime / halfDuration;

            tick += Time.deltaTime * m_roughness;
            transform.position = new Vector3(
                Mathf.PerlinNoise(tick, 0) - .5f * m_magnitude * Mathf.PingPong(elapsed, halfDuration),
                Mathf.PerlinNoise(0, tick) - .5f * m_magnitude * Mathf.PingPong(elapsed, halfDuration),
                -10f);// * m_magnitude * Mathf.PingPong(elapsed, halfDuration);

            yield return null;
        }
        transform.position = new Vector3(0.0f, 0.0f, -10.0f);
    }
}
