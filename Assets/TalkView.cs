using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DreamerTool.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class TalkView : View
{
    public Image talkerImage;
    public Text talkerNameText;
    public Text contextText;
    
    private bool istalkOver;
    private bool isTalking = false;
    private float talkTime=0.05f;
    private int talkIndex;
    private int contextIndex = 0;
    private List<string> talkContext = new List<string>();
    private float talkTimer;
    private StringBuilder talkSb = new StringBuilder();
    
    public void SetModel(Talker talker,List<string> contexts)
    { 
        talkerImage.sprite = talker.talkerHead;
        talkerNameText.text = talker.talkerName;
        SetTalk(contexts);
    }
    public bool IsTalkOver()
    {
        return istalkOver;
    }

    public void TalkOver()
    {
        if (isTalking)
        {
            isTalking = false;
            contextText.text = talkContext[contextIndex];
        }
        else
        {
            if (contextIndex < talkContext.Count-1)
            {
                ResetTalk();
                contextIndex++;
                return;
            }
             
            istalkOver = true;
        }
    }
    
    #region ----------------Choice------------

    private List<GameObject> choiceBtnGameObj = new List<GameObject>();
    public Transform choiceBtnRoot;
    public GameObject choiceBtnPrefab;

    public void ClearChoice()
    {
        foreach (var choiceBtn in choiceBtnGameObj)
        {
            Destroy(choiceBtn);
        }
        choiceBtnGameObj.Clear();
    }

    public bool isChoice()
    {
        return choiceBtnGameObj.Count > 0;
    }
    public void SetChoice(List<TalkChoice> talkChoices,string content,Action<int> callback)
    {
       
        this.contextText.text = content;
        foreach (var talkChoice in talkChoices)
        {
            var btn =Instantiate(choiceBtnPrefab, choiceBtnRoot);
            btn.GetComponent<Button>().onClick.AddListener(()=>
            {
                callback(btn.transform.GetSiblingIndex());
            });
            btn.GetComponentInChildren<Text>().text = talkChoice.content;
            choiceBtnGameObj.Add(btn);
        }
    }

    #endregion
   
    #region ----------------RichText---------------
 
    Stack<string> result= new Stack<string>();
    public Stack<string> ParseStr(string str,ref int index)
    {
        Stack<string> result = new Stack<string>();
        int recordIndex=index;
        Stack<string> richStr = new Stack<string>();
        Stack<string> rich = new Stack<string>();
        for (int i = index; i < str.Length; i++)
        {
            
            
            if (str[i] == '<')
            {
                if (recordIndex != i)
                {

                    if (i - recordIndex - 1 > 0)
                    {
                        var sub = str.Substring(recordIndex + 1, i - recordIndex - 1);
 
                        richStr.Push(sub );
                    }
                     
                }
                if (str[i + 1] == '/')
                {
                    var endIndex = str.IndexOf('>', i);
                    if (endIndex != -1)
                    {
                        recordIndex = endIndex;
                       var endRich =str.Substring(i,endIndex-i+1);
                       var headRich = rich.Pop();
                       index = endIndex+1;
                       if (rich.Count == 0)
                       {
                           while (richStr.Count > 0)
                           {
                               var s = richStr.Pop();
                               for (int j =  s.Length-1; j >=0; j--)
                               {
                             
                                   result.Push(headRich +s[j] + endRich);
                               }
                             
                           }
                           break;
                       }
                       else
                       {
                           var s = richStr.Pop();        
                           richStr.Push( headRich+s+endRich);
                       }
                        i = endIndex;
                    }
                }
                else
                {
                    
                    var endIndex = str.IndexOf('>', i);
                    if (endIndex != -1)
                    {
                       
                        recordIndex = endIndex;
                        rich.Push(str.Substring(i,endIndex-i+1));
                        i = endIndex;
                    }

                   
                }
            }
        }

       

        return result;
    }
    
    #endregion
    private void Update()
    {
        if (!isChoice())
        {
            if (GloablManager.Instance.GameInput.Common.Talk.triggered)
            {
                TalkOver();
            }
        }

        if (isTalking)
        {       
 
            talkTimer += Time.deltaTime;  
            if (talkTimer >= talkTime)
            {
                if (result.Count > 0)
                {
                    talkSb.Append(result.Pop());
                }
                else
                {
                    if (talkIndex >= talkContext[contextIndex].Length)
                    {
                        isTalking = false;
                        return;
                    }
                    var _char = talkContext[contextIndex][talkIndex];
                    if (_char == '<')
                    {
                        result = ParseStr(talkContext[contextIndex],ref talkIndex);
                        
                        if (result.Count > 0)
                        {
                            talkSb.Append(result.Pop());
                        }
                    }
                    else
                    {
                        talkSb.Append(_char);
                        talkIndex++;
                        if (talkIndex >= talkContext[contextIndex].Length)
                        {
                            isTalking = false;
                        }
                    }
                }
                contextText.text =talkSb.ToString();
                talkTimer = 0;
 
            }
        }
    }

    public void ResetTalk ()
    { 
        isTalking = true;
        contextText.text = "";
        talkSb.Clear();
        talkIndex = 0;
        
    }
    public void SetTalk(List<string> context)
    {
        
        this.talkContext = context;
        contextIndex = 0;
        istalkOver = false;
        ResetTalk();
        
    }
}
