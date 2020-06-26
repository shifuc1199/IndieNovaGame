using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public enum RunningState
{
	Running,
	Stop
}
[CreateAssetMenu(fileName= "DialogueGraph")]
public class DialogueGraph : NodeGraph
{
	public RunningState state = RunningState.Running;
	public EntryNode _entryNode;
	private DialogueNodeBase _currentNode;
	public override Node AddNode(Type type)
	{
		var node = base.AddNode(type);
		if (node is EntryNode)
		{
			_entryNode = node as EntryNode;
		}
		return node;	 
	}

 

	public void Reset()
	{		
		 
		state = RunningState.Running;
		_currentNode = null;
		foreach (var node in nodes)
		{
			(node as DialogueNodeBase).Reset();
		}
	}

	public void Execute()
	{
		 
		if (state == RunningState.Stop)
			return;
		
		if (_entryNode == null)
		{
			Debug.LogWarning("EntryNode Can't Find");
			return;
		}

		if (_currentNode == null)
		{
			 
			var entryOutput = _entryNode.GetOutputPort().Connection;

			if (entryOutput != null)
			{
				_currentNode = entryOutput.node as DialogueNodeBase;
				_currentNode.OnEnter();
			}
		}

		if (_currentNode == null)
		{
			Debug.LogWarning("CurrentNode Can't Find");
			return;
		}
		 
		if (_currentNode.Execute())
		{
			 
			var outPut = _currentNode.GetOutputPort().Connection;

			if (outPut != null)
			{
				_currentNode.OnExit();
				_currentNode = outPut.node as DialogueNodeBase;
				_currentNode.OnEnter();
			}
			else
			{
				state = RunningState.Stop;
			}
		}
	}
 
	 
}