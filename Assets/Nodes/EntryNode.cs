using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class DialogueNodeBase : Node
{
	public abstract bool Execute();

	public virtual NodePort GetOutputPort()
	{
		return this.GetOutputPort("Out");
	}
}
public class EntryNode : DialogueNodeBase
{

	[Output]public byte Out;
	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}

 

	public override bool Execute()
	{
		return true;
	}
}