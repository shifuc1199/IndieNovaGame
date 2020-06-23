using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XNode;

public class EventNode : DialogueNodeBase
{

	[Input(ShowBackingValue.Never)] public byte In;
	public UnityEvent unityEvent;
	[Output] public byte Out;
	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}

	public override bool Execute()
	{
		unityEvent?.Invoke();
		return true;
	}
}