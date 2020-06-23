using System;
using System.Collections;
using System.Collections.Generic;
using DreamerTool.UI;
using Sirenix.OdinInspector;
using UnityEngine;

 
public class EventNodeFunction : SerializedScriptableObject
{
   
    public void CloseTalkView()
    {
       
        View.CurrentScene.CloseView<TalkView>();
    }
}
