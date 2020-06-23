using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DreamerTool.UI;
public class TalkView : View
{
    public Image talkerImage;
    public Text talkerNameText;
    public Text contextText;
    private bool istalkOver;
    private float talkTime=0.2f;
    private int talkIndex;
    private string talkContext;
    public void SetModel(Talker talker,string context)
    { 
        talkerImage.sprite = talker.talkerHead;
        talkerNameText.text = talker.talkerName;
        SetTalk(context);
    }

    public bool IsTalkOver()
    {
        return istalkOver;
    }
    public void TalkOver()
    {
        contextText.text = talkContext;
        istalkOver = true;
    }
    private float talkTimer;
    private StringBuilder talkSb = new StringBuilder();
    private void Update()
    {
        if (!istalkOver)
        {
            talkTimer += Time.deltaTime;
            if (talkTimer >= talkTime)
            {
                talkSb.Append(talkContext[talkIndex]);
                contextText.text =talkSb.ToString();
                talkTimer = 0;
                talkIndex++;
                if (talkIndex >= talkContext.Length)
                {
                    istalkOver = true;
                }
            }
        }
    }

    public void SetTalk(string context)
    {
        talkIndex = 0;
        talkSb.Clear();
        contextText.text = "";
        this.talkContext = context;
        istalkOver = false;
    }
}
