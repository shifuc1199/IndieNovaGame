using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;
using DreamerTool.UI;
 
[System.Serializable]
public class Talker
{
	[PreviewField(100)]
	public Sprite talkerHead;
	public string talkerName;
}
 [NodeTint("#22BCE5")]
 [NodeWidth(300)]
public class TalkNode : DialogueNodeBase
{ 
	[Input(ShowBackingValue.Never)]public byte In;
	public Talker talker;
	
    public List<string> content = new List<string>();
    [Output]public byte Out;
    
	private bool isExcute;
 

	public override void Reset()
	{
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
		return talkView.IsTalkOver();
	}
 
	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}

 
