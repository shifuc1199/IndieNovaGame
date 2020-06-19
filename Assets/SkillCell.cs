using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
using UnityEngine.UI;

public class SkillCell : MonoBehaviour
{
   public Text contentText;
   public void SetModel(SkillInfo skillInfo)
   {
      contentText.text = skillInfo.skillSet.skillName;
   }
}
