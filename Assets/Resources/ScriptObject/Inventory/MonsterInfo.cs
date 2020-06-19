using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Tools.Monster;
using UnityEngine;
/// <summary>
/// 怪物信息类,用于实例化实时管理玩家游戏中怪物的信息
/// </summary>
 
public class MonsterInfo  
{
    public MonsterInfo()
    {
        
        
    }
    public MonsterInfo(MonsterSet monsterSet)
    {
        this.monsterSet = monsterSet;
        
        EquipModule(new ModuleInfo(monsterSet.birthModule,5));
        
        containerLevel += monsterSet.monsterSpecificLevel;
    }
    /// <summary>
   /// 怪物预设引用
   /// </summary>
    public MonsterSet monsterSet;
    /// <summary>
    /// 怪物模块点数,用来手动升级模块
    /// </summary>
    public int monsterModulePoint;

    public Dictionary<MonsterRealTimeField, bool> monsterRealimeField;
    /// <summary>
    /// 怪物实时属性
    /// </summary>
    public Dictionary<MonsterStateV, int> monsterStateNow;
    /// <summary>
    /// 怪物实时属性抗性
    /// </summary>
    public Dictionary<Element, DetermineExtent> elementDetermine;
    /// <summary>
    /// 怪物容器等级
    /// </summary>
    public int containerLevel{ get; private set; }
    /// <summary>
    /// 怪物当前等级
    /// </summary>
    public int levelNow{ get; private set; }
    /// <summary>
    /// 怪物所装备的模块列表
    /// </summary>
    public List<ModuleInfo> monModuleInfos = new List<ModuleInfo>();
    /// <summary>
    /// 怪物所装备的技能列表
    /// </summary>
    public List<SkillInfo> monEquipSkillInfos = new List<SkillInfo>();
    /// <summary>
    /// 生效的技能列表
    /// </summary>
    public List<SkillInfo> monSkillInfos = new List<SkillInfo>();
    public bool ModuleEquipable(ModuleInfo moduleInfo)
    {
        switch (moduleInfo.moduleSet.moduleTypeField)
        {
            case ModuleSet.moduleType.种族模块:
                return false;
            case ModuleSet.moduleType.扩展模块:
                return true;
            case ModuleSet.moduleType.通用模块:
                if (moduleInfo.moduleLevel > monsterSet.monsterSpecificLevel - levelNow)
                    return false;
                return true;
        }
        return false;
    }

    public void AddSkillInfo(SkillInfo skillInfo)
    {
        monSkillInfos.Add(skillInfo);
        GloablManager.Instance.EventManager.BroadCast(EventTypeArg.AddSkill,skillInfo);
    }
    public void EquipSkill(SkillInfo skillInfo)
    {
        monEquipSkillInfos.Add(skillInfo);
    }
    public void EquipModule(ModuleInfo moduleInfo)
    {
        monModuleInfos.Add(moduleInfo);
        
        if ( moduleInfo.moduleSet.moduleTypeField == ModuleSet.moduleType.扩展模块)
        {
            containerLevel += moduleInfo.moduleLevel;
        }

        levelNow += moduleInfo.moduleLevel;
        
        GloablManager.Instance.EventManager.BroadCast(EventTypeArg.EquipModule,moduleInfo);
    }
   
}
