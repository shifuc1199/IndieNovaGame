using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagModuleCell : ModuleCell,IPointerDownHandler
{
    public bool isEquipable;

    private void Awake()
    {
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.EquipModule,UpdateEquipable);
    }

    private void OnDestroy()
    {
        GloablManager.Instance.EventManager.RemoveListener<ModuleInfo>(EventTypeArg.EquipModule,UpdateEquipable);
    }

    public override void SetModel(ModuleInfo info)
    {
        base.SetModel(info);
        UpdateEquipable();
    }
    public void UpdateEquipable(ModuleInfo info=null)
    {
        isEquipable = GloablManager.Instance.PlayerInfo.currentMonster.ModuleEquipable(moduleInfo);
        if (!isEquipable)
        {
            GetComponent<Image>().color = Color.gray;
        }
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isEquipable)
        {
            return;
        } 
        
        GloablManager.Instance.PlayerInfo.currentMonster.EquipModule(moduleInfo);
    }
}
