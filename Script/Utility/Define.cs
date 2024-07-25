//이 클래스의 존재 이유는 string 매개변수를 넣을 때, 오타로 인한 오류를 방지하고자 만들었다.
public class Define
{
    //인풋액션에셋 이름
    public const string ACTIONASSET_BATTLE = "Battle";
    public const string ACTIONASSET_FIELD = "Field";

    //태그 이름
    public const string TAG_PLAYER = "Player";
    public const string TAG_GROUND = "Ground";
    public const string TAG_WALL = "Wall";
    public const string TAG_ENEMY = "Enemy";

    //씬 이름
    public const string SCENE_BATTLE = "BattleScene";

    //배틀 씬 양 끝 좌표
    public const float BATTLESCENE_RIGHTWALL_X = 7.2f;
    public const float BATTLESCENE_LEFTWALL_X = -6.7f;

    //장비 리스트 순서
    public const int HAIR_NUM = 0;
    public const int HELMET_NUM = 2;
    public const int TOP_BODY_NUM = 3;
    public const int TOP_RIGHT_NUM = 4;
    public const int TOP_LEFT_NUM = 5;
    public const int PANTS_RIGHT_NUM = 6;
    public const int PANTS_LEFT_NUM = 7;
    public const int WEAPON_NUM = 11;
    public const int CLOAK_NUM = 15;

}
