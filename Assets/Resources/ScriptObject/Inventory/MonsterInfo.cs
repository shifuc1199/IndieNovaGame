using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Tools.Monster;
using UnityEngine;
/// <summary>
/// 怪物信息类,用于实例化实时管理玩家游戏中怪物的信息
/// </summary>
[CreateAssetMenu(fileName = "怪物信息",menuName = "信息/怪物保存信息")]
public class MonsterInfo : SerializedScriptableObject
{
 
    public MonsterInfo()
    {
        
        
    }
    
    public MonsterInfo(MonsterSet monsterSet)
    {
        this.monsterSet = monsterSet;
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
    /// 怪物当前等级
    /// </summary>
    public int levelNow;
    /// <summary>
    /// 怪物所装备的模块列表
    /// </summary>
    public List<ModuleInfo> monModuleInfos;

   
}
