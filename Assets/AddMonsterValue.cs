using System.Collections;
using System.Collections.Generic;
using Tools.Monster;
using UnityEngine;

public class ChangeMonsterTag : SkillExecute
{
     public MonsterRealTimeField field;
     public bool ChangeValue = true;
     public override void OnEquip(MonsterInfo monsterInfo)
     {
          monsterInfo.SetRealTimeField(field, ChangeValue);
          
     }

     public override void OnUnEquip(MonsterInfo monsterInfo)
     {
          monsterInfo.monsterRealimeField[field] = ! ChangeValue;
     }

     public override void OnUpdate(MonsterController controller)
     {
          
     }
}
public class AddMonsterValue : SkillExecute
{
     public Dictionary<MonsterStateV,int>  states;
      
     public override void OnEquip(MonsterInfo monsterInfo)
     {
          foreach (var state in states)
          {
               monsterInfo.monsterStateNow[state.Key] += state.Value;
          }
          
     }

     public override void OnUnEquip(MonsterInfo monsterInfo)
     {
          foreach (var state in states)
          {
               monsterInfo.monsterStateNow[state.Key] -= state.Value;
          }
     }

     public override void OnUpdate(MonsterController controller)
     {
           
     }
}
