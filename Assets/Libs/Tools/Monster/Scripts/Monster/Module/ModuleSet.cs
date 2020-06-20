using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Tools.Monster;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// 模块的预设文件类,存放模块初始的配置
/// </summary>
public class ModuleSet : SerializedScriptableObject
{
    /// <summary>
    /// 模块的名字
    /// </summary>
    public string moduleName;
    /// <summary>
    /// 模块的头像A
    /// </summary>
    public Sprite moduleIconA;
    /// <summary>
    /// 模块的头像B
    /// </summary>
    public Sprite moduleIconB;
    /// <summary>
    /// 模块的ID编号
    /// </summary>
    public int moduleID;
    /// <summary>
    /// 模块类型
    /// </summary>
    [InfoBox("一共有三种类型的模块")]
    [EnumPaging]
    public moduleType moduleTypeField;
    public enum moduleType
    {
        种族模块,
        通用模块,
        扩展模块
    }
    /// <summary>
    /// 模块升级所需要的模块点数
    /// </summary>
    public List<int> LevelEXP;
    /// <summary>
    /// 模块技能表以及对应的解锁等级
    /// </summary>
    [InfoBox("key:模块拥有的技能,value:技能解锁需要的模块的等级")]
    public Dictionary<SkillSet,int> moduleSkills ;
    /// <summary>
    /// 模块对元素抗性的影响
    /// </summary>
    public Dictionary<Element, DetermineExtent> elementEsistance;
    /// <summary>
    /// 模块对怪物属性数值的补正
    /// </summary>
    public Dictionary<MonsterStateV, float> stateFix;
    /// <summary>
    /// 模块描述
    /// </summary>
    [TextArea]
    public String moduleDetail;
    
    private static Dictionary<int,ModuleSet> moduleSets= new Dictionary<int, ModuleSet>();
    
    public static void Load()
    {
        Addressables.LoadAssetsAsync<ModuleSet>(typeof(ModuleSet).Name, op =>
        {
            moduleSets.Add(op.moduleID,op);
        });
    }

    public static ModuleSet Get(int id)
    {
        if (!moduleSets.ContainsKey(id))
        {
            return null;
        }
        return moduleSets[id];
    }
}
