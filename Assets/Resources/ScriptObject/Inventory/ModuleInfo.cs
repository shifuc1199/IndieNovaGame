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
    
    public List<SkillInfo> unlockSkill = new List<SkillInfo>();
    public List<SkillInfo> lockSkill = new List<SkillInfo>();
    public void LevelUp()
    {
        moduleLevel += 1;
        if(lockSkill.Count == 0)
            return;
        
        var skill = lockSkill[0];
       
        if (moduleLevel >= moduleSet.moduleSkills[skill.skillSet])
        {
            GloablManager.Instance.PlayerInfo.currentMonster.AddSkillInfo(skill);
            unlockSkill.Add(skill);
            lockSkill.RemoveAt(0); 
        }
    }
}

