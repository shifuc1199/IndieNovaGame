using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
/// <summary>
/// 模块信息类,用于实例化实时管理玩家游戏中的技能信息
/// </summary>
public class SkillInfo    
{
    public SkillInfo()
    {
        
    }

    public SkillInfo(SkillSet set)
    {
        skillSet = set;
    }

    public int countInSkillPool = 0;
    /// <summary>
    /// 技能预设引用
    /// </summary>
    public SkillSet skillSet;
}
