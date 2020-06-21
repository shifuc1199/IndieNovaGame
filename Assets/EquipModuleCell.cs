using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipModuleCell : ModelCell<ModuleInfo>
{
    public Text infoText;
    
    private bool isLevelUpable;
    
    public void SetLevelUpable(bool value)
    {
        isLevelUpable = value;
        GetComponent<Button>().interactable = isLevelUpable;
    }

    public override void SetModel(ModuleInfo model)
    {
        base.SetModel(model);
        Refresh();
    }

    public void UnEquip()
    {
        model.ownerMonster.UnEquipModule(model);
    }
    public override void Refresh()
    {
        infoText.text = model.moduleSet.moduleName + ": LV " + model.moduleLevel;
        SetLevelUpable(model.ownerMonster.EquipModuleLevelUpable(model));
    }

    public void LevelUp()
    {
        model.LevelUp();
    }
}
