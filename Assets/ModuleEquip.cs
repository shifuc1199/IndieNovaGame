using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleEquip : TableView<EquipModuleCell,ModuleInfo>
{

   public void SetMonster(MonsterInfo monsterInfo)
   {
      ClearCell();
      foreach (var moduleInfo in  monsterInfo.monEquipModules)
      {
         AddCell(moduleInfo.Value);
      }  
   }

  
}
