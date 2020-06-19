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
        EquipModule(new ModuleInfo(monsterSet.birthModule, 5));
        containerLevel = monsterSet.monsterSpecificLevel;
    }

     
    /// <summary>
   /// 怪物预设引用
   /// </summary>
    public MonsterSet monsterSet { get; private set; }
    /// <summary>
    /// 怪物模块点数,用来手动升级模块
    /// </summary>
    public int monsterModulePoint;
 
    public Dictionary<MonsterRealTimeField, bool> monsterRealimeField = new Dictionary<MonsterRealTimeField, bool>();
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
    public List<SkillInfo> monSkillPool = new List<SkillInfo>();
    /// <summary>
    /// 生效的技能列表
    /// </summary>
    public List<SkillInfo> monEquipSkill = new List<SkillInfo>();

 
    public void EquipModuleLevelUp(ModuleInfo moduleInfo)
    {
         
        if (monModuleInfos.Contains(moduleInfo))
        {
            moduleInfo.LevelUp();
            switch (moduleInfo.moduleSet.moduleTypeField)
            {
                case ModuleSet.moduleType.种族模块:
                    levelNow++;
                    break;
                case ModuleSet.moduleType.扩展模块:
                    containerLevel++;
                    break;
                case ModuleSet.moduleType.通用模块:
                    levelNow++;
                    break;
            }
            GloablManager.Instance.EventManager.BroadCast(EventTypeArg.EquipModuleLevelUp);
        }
    }
    public bool EquipModuleLevelUpable(ModuleInfo moduleInfo)
    {
 
        switch (moduleInfo.moduleSet.moduleTypeField)
        {
            case ModuleSet.moduleType.种族模块:
                return  monsterSet.monsterSpecificLevel - levelNow >=1;
            case ModuleSet.moduleType.扩展模块:
                return true;
            case ModuleSet.moduleType.通用模块:
                return monsterSet.monsterSpecificLevel - levelNow >=1;
        }
        return false;
    }
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

    public void SetRealTimeField(MonsterRealTimeField realTimeField, bool value)
    {
        if (!monsterRealimeField.ContainsKey(realTimeField))
        {
            monsterRealimeField.Add(realTimeField,value);    
        }
        else
        {
            monsterRealimeField[realTimeField] = value;
        }
    }
    public void AddSkillInfo(SkillInfo skillInfo)
    {
        if (monEquipSkill.Exists(s=>s.skillSet == skillInfo.skillSet))
            return;
        
        monEquipSkill.Add(skillInfo);
        GloablManager.Instance.EventManager.BroadCast(EventTypeArg.AddSkill,skillInfo);
    }
    public void EquipSkill(SkillInfo skillInfo)
    {
        skillInfo.skillSet.OnEquip(this);
        monSkillPool.Add(skillInfo);
        GloablManager.Instance.EventManager.BroadCast(EventTypeArg.EquipSkill,skillInfo);
    }
 
    public void EquipModule(ModuleInfo moduleInfo)
    {
        monModuleInfos.Add(moduleInfo);
        
        if ( moduleInfo.moduleSet.moduleTypeField == ModuleSet.moduleType.扩展模块)
        {
            containerLevel += moduleInfo.moduleLevel;
        }
        else
        {
            levelNow += moduleInfo.moduleLevel;
        }
         
        
        GloablManager.Instance.EventManager.BroadCast(EventTypeArg.EquipModule,moduleInfo);
    }
   
}
