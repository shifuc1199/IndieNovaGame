 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 using DreamerTool.UI;
public class TeamMonsterCell : ModelCell<MonsterInfo>
{
    public Text nameText;
    public override void SetModel(MonsterInfo model)
    {
        base.SetModel(model);
        nameText.text = model.monsterSet.monsterSpecificName;
      
    }
    
    public void SelectModel()
    {
        Debug.Log("Select: "+model.monsterSet.monsterSpecificName);
        View.CurrentScene.GetView<MonsterInfoView>().SetModel(model);
    }

 
}
