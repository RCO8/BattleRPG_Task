public interface INode
{
    public enum ENodeState
    {
        ENS_Running,    //실행 중
        ENS_Success,    //성공
        ENS_Failure,    //실패
    }

    //노드 실행
    public ENodeState Evaluate();
}

public class BehaviorTreeRunner
{
    //루트 노드
    INode _rootNode;

    public BehaviorTreeRunner(INode rootNode)
    {
        //생성자를 통해 루트 노드 설정
        _rootNode = rootNode;
    }

    //루트 노드 실행
    public void Operate()
    {
        _rootNode.Evaluate();
    }
}