using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagModuleCell : ModuleCell 
{
    
    private void Awake()
    {
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.EquipModule,UpdateEquipable);
    }

    private void OnDestroy()
    {
        GloablManager.Instance.EventManager.RemoveListener<ModuleInfo>(EventTypeArg.EquipModule,UpdateEquipable);
    }

    public void Equip()
    {
        GloablManager.Instance.PlayerInfo.currentMonster.EquipModule(moduleInfo);
    }
    public override void SetModel(ModuleInfo info)
    {
        base.SetModel(info);
        UpdateEquipable();
    }
    public void UpdateEquipable(ModuleInfo info=null)
    {
        var isEquipable = GloablManager.Instance.PlayerInfo.currentMonster.ModuleEquipable(moduleInfo);
        GetComponent<Button>().interactable = isEquipable;
    }
 
}
