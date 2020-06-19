using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipModuleCell : ModuleCell 
{
    public void LevelUp()
    {
        if (!GloablManager.Instance.PlayerInfo.currentMonster.EquipModuleLevelUpable(moduleInfo))
            return;
        GloablManager.Instance.PlayerInfo.currentMonster.EquipModuleLevelUp(moduleInfo);
        UpdateModel();
    }
}
