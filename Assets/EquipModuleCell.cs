using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipModuleCell : ModuleCell,IPointerDownHandler
{
   
    public void OnPointerDown(PointerEventData eventData)
    {
        moduleInfo.LevelUp();
        UpdateModel();
    }
}
