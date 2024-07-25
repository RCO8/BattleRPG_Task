public interface INode
{
    public enum ENodeState
    {
        ENS_Running,    //���� ��
        ENS_Success,    //����
        ENS_Failure,    //����
    }

    //��� ����
    public ENodeState Evaluate();
}

public class BehaviorTreeRunner
{
    //��Ʈ ���
    INode _rootNode;

    public BehaviorTreeRunner(INode rootNode)
    {
        //�����ڸ� ���� ��Ʈ ��� ����
        _rootNode = rootNode;
    }

    //��Ʈ ��� ����
    public void Operate()
    {
        _rootNode.Evaluate();
    }
}