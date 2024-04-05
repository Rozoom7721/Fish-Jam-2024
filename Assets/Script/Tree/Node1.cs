using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

[System.Serializable]

public abstract class Node1 
{
    protected NodeState _nodeState;

    public NodeState nodeState { get { return _nodeState; } }

    public abstract NodeState Evaluate();
}
public enum NodeState
{
    RUNNING, SUCCESS, FAILURE,
}
