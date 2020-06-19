using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillCell : MonoBehaviour
{
   private SkillInfo _skillInfo;
   public Text contentText;
   public void SetModel(SkillInfo skillInfo)
   {
      _skillInfo = skillInfo;
      
      contentText.text = skillInfo.skillSet.skillName;
   }

   public void Equip()
   {
      GloablManager.Instance.PlayerInfo.currentMonster.EquipSkill(_skillInfo);
      GetComponent<Image>().color = Color.green;
   }
}
