using System.Collections;
using System.Collections.Generic;
using DreamerTool.UI;
using UnityEditor.UIElements;
using UnityEngine;
using XNode;
[System.Serializable]
public class TalkChoice
{
	[TextArea]public string content;
	 
}
[NodeWidth(300)]
public class TalkChoiceNode : DialogueNodeBase
{
	[Input(ShowBackingValue.Never)] public byte In;
	public string content;
	private int index;
	private bool isChoice = false;
	private bool isExcute = false;
	public List<TalkChoice> Choices = new List<TalkChoice>(1);
	// Use this for initialization
	public override NodePort GetOutputPort()
	{
		var outputEnumerator = DynamicOutputs.GetEnumerator();
	 
		for (int i = 0; i < index+1; i++)
		{
			outputEnumerator.MoveNext();
		}
		 
		return outputEnumerator.Current;
	}

	public override void Reset()
	{
		this.index = 0;
		isChoice = false;
		isExcute = false;
	}

	public void SetIndex(int index)
	{
		this.index = index;
		isChoice = true;
	}

	public override void OnExit()
	{
		View.CurrentScene.GetView<TalkView>().ClearChoice();
	}

	public override bool Execute()
	{
		if (!isExcute)
		{
			View.CurrentScene.OpenView<TalkView>().SetChoice(Choices,content,SetIndex);
			isExcute = true;
		}
		 
		return isChoice;
	}
}