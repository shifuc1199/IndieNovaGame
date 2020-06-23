using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;
using DreamerTool.UI;
using UnityEngine.InputSystem;
[System.Serializable]
public class Talker
{
	[PreviewField(100)]
	public Sprite talkerHead;
	public string talkerName;
}
 
public class TalkNode : DialogueNodeBase
{
	[Input(ShowBackingValue.Never)]public byte In;
	public Talker talker;
	[TextArea]
    public string content;
    [Output]public byte Out;
    
	private bool isExcute;
 

	private  void OnEnable()
	{
		base.OnEnable();
		isExcute = false;
	}

	public override bool Execute()
	{
		var talkView = View.CurrentScene.OpenView<TalkView>();
		if (!isExcute)
		{
			isExcute = true;
			talkView.SetModel(talker, content);
		}

		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			if (!talkView.IsTalkOver())
			{
				talkView.TalkOver();
				return false;
			}
			 
			return true;
		}

		return false;
	}
 
	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}

 
