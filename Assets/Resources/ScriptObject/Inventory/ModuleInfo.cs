using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
/// <summary>
/// 模块信息类,用于实例化实时管理玩家游戏中的模块信息
/// </summary>
 
public class ModuleInfo  
{
    public ModuleInfo(){
    }
    public ModuleInfo(ModuleSet moduleSet, int moduleLevel=0)
    {
        this.moduleSet = moduleSet;
        this.moduleLevel = moduleLevel;
 
        foreach (var skill in  moduleSet.moduleSkills)
        {
            lockSkill.Add(new SkillInfo(skill.Key));
        }
    }
    /// <summary>
    /// 模块预设引用
    /// </summary>
    public ModuleSet moduleSet;
    /// <summary>
    /// 模块等级
    /// </summary>
    public int moduleLevel;
    public MonsterInfo ownerMonster;
    public List<SkillInfo> unlockSkill = new List<SkillInfo>();
    public List<SkillInfo> lockSkill = new List<SkillInfo>();
    public void Equiped(MonsterInfo monsterInfo)
    {
        ownerMonster = monsterInfo;
    }
    public void UnEquiped()
    {
        moduleLevel = 1;

        foreach (var skill in unlockSkill)
        {
            ownerMonster.RemoveSkillPool(skill);
            lockSkill.Add(skill);
        }
        unlockSkill.Clear();
        lockSkill.Sort((info, skillInfo) => { return moduleSet.moduleSkills[skillInfo.skillSet].CompareTo(moduleSet.moduleSkills[info.skillSet]);});
        ownerMonster = null;
         
    }
    public void LevelUp()
    {
        moduleLevel += 1;
        
        ownerMonster.EquipedModuleLevelUp(this);
        
        if(lockSkill.Count == 0)
            return;
        
        var skill = lockSkill[0];
        
        if (moduleLevel >= moduleSet.moduleSkills[skill.skillSet])
        {
            ownerMonster.AddSkillPool(skill);
            unlockSkill.Add(skill);
            lockSkill.RemoveAt(0); 
        }
    }
}

