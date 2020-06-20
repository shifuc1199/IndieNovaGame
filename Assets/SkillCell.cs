using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillCell : ModelCell<SkillInfo,MonsterInfo>
{
   public Text contentText;
   public override void SetModel(SkillInfo model, MonsterInfo commonModel)
   {
      base.SetModel(model, commonModel);
      contentText.text = model.skillSet.skillName;
   }

   public void Equip()
   {
      commonModel.EquipSkill(model);
      GetComponent<Image>().color = Color.green;
   }
}
