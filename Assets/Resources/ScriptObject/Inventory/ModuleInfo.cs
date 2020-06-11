using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
/// <summary>
/// 模块信息类,用于实例化实时管理玩家游戏中的模块信息
/// </summary>
[CreateAssetMenu(fileName = "模块信息",menuName = "信息/模块保存信息")]
public class ModuleInfo : SerializedScriptableObject
{
    public ModuleInfo(){
    }
    public ModuleInfo(ModuleSet moduleSet, int moduleLevel)
    {
        this.moduleSet = moduleSet;
        this.moduleLevel = moduleLevel;
    }
    /// <summary>
    /// 模块预设引用
    /// </summary>
    public ModuleSet moduleSet;
    /// <summary>
    /// 模块等级
    /// </summary>
    public int moduleLevel;
}

