using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public abstract class SkillExecute
{
    
    public abstract void OnEquip(MonsterInfo monsterInfo);

    public abstract void OnUnEquip(MonsterInfo monsterInfo);

    public abstract void OnUpdate(MonsterInfo monsterInfo);

}
 