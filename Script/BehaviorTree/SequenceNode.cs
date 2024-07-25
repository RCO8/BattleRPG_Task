using System.Collections.Generic;

public class SequenceNode : INode
{
    //자식 노드들
    List<INode> childs;

    public SequenceNode(List<INode> _childs)
    {
        //생성자를 통해 자식 노드들 설정
        childs = _childs;
    }

    public INode.ENodeState Evaluate()
    {
        //자식 노드들이 없다거나 존재하지 않으면 실패를 반환함
        if (childs == null || childs.Count == 0)
            return INode.ENodeState.ENS_Failure;

        foreach (var child in childs)
        {
            //자식 노드들을 모두 순회한다. 노드를 실행해 실행 중이거나 실패이면 return하고 다음 자식 노드로 넘어간다.
            switch (child.Evaluate())
            {
                case INode.ENodeState.ENS_Running:
                    return INode.ENodeState.ENS_Running;
                case INode.ENodeState.ENS_Success:
                    continue;
                case INode.ENodeState.ENS_Failure:
                    return INode.ENodeState.ENS_Failure;
            }
        }

        //자식 노드들이 다 성공을 반환한다면 이 Sequence노드도 성공을 반환함
        return INode.ENodeState.ENS_Success;
    }
}
