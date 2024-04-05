using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence1 : Node1
{
    protected List<Node1> nodes = new List<Node1>();

    public Sequence1(List<Node1> nodes)
    {
        this.nodes = nodes;
    }
    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    break;
                case NodeState.SUCCESS:
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                default:
                    break;

            }
        }
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _nodeState;
    }
}
