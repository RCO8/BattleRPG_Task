using System.Collections.Generic;

public class SelectNode : INode
{
    //자식 노드들
    List<INode> childs;

    public SelectNode(List<INode> _childs)
    {
        //생성자를 통해 자식 노드들 설정
        childs = _childs;
    }

    public INode.ENodeState Evaluate()
    {
        //자식 노드들이 없다면 실패를 반환함
        if (childs == null)
            return INode.ENodeState.ENS_Failure;

        foreach (var child in childs)
        {
            //자식 노드들을 모두 순회한다. 노드를 실행해 실행 중이거나 성공이면 return하고 다음 자식 노드로 넘어간다.
            switch (child.Evaluate())
            {
                case INode.ENodeState.ENS_Running:
                    return INode.ENodeState.ENS_Running;
                case INode.ENodeState.ENS_Success:
                    return INode.ENodeState.ENS_Success;
            }
        }

        //자식 노드들이 다 실패를 반환한다면 이 Select노드도 실패를 반환함
        return INode.ENodeState.ENS_Failure;
    }
}
