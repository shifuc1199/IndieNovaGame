using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagModuleCell : ModelCell<ModuleInfo,MonsterInfo>
{
 
    private bool isEquipable;
    
    public Text infoText;

    public override void SetModel(ModuleInfo model,MonsterInfo monsterInfo)
    {
        base.SetModel(model,monsterInfo);
        infoText.text = model.moduleSet.moduleName + ": LV " + model.moduleLevel;
        SetEquipable(commonModel.ModuleEquipable(model));
    }

    public override void UpdateCommonModel(MonsterInfo commonModel)
    {
        base.UpdateCommonModel(commonModel);
        SetEquipable(commonModel.ModuleEquipable(model));
    }

    public override void Refresh()
    {
        SetEquipable(commonModel.ModuleEquipable(model));
    }

    public void SetEquipable(bool value)
    {
        isEquipable = value;
        GetComponent<Button>().interactable = isEquipable;
    }
    public void Equip()
    {
        commonModel.EquipModule(model);
        
    }

   
}
