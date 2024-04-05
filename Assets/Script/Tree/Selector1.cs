using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector1 : Node1
{
    protected List<Node1> nodes = new List<Node1>();

    public Selector1(List<Node1> nodes)
    {
        this.nodes = nodes;
    }
    public override NodeState Evaluate()
    {
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;
                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                case NodeState.FAILURE:
                    break;
                default:
                    break;

            }
        }
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
