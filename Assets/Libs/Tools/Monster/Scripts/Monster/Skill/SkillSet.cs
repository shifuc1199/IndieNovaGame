using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Tools.Monster;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
/// <summary>
/// 技能的预设文件类,存放技能初始的配置
/// </summary>
public class SkillSet : SerializedScriptableObject
{
    /// <summary>
    /// 技能名字
    /// </summary>
    public string skillName;
    /// <summary>
    /// 技能头像A
    /// </summary>
    [FormerlySerializedAs("Icon")] 
    public Texture skillIconA;
    /// <summary>
    /// 技能头像B
    /// </summary>
    public Texture skillIconB;
    /// <summary>
    /// 技能ID编号
    /// </summary>
    public int skillID;
    /// <summary>
    /// 技能描述
    /// </summary>
    [TextArea]
    public String skillDetail;
      
    public List<SkillExecute> skillExecutes = new List<SkillExecute>();

    public void OnEquip(MonsterInfo monsterInfo)
    {
        foreach (var skillExcute in skillExecutes)
        {
            skillExcute.OnEquip(monsterInfo);
        }
    }
    public void OnUnEquip(MonsterInfo monsterInfo)
    {
        foreach (var skillExcute in skillExecutes)
        {
            skillExcute.OnUnEquip(monsterInfo);
        }
    }
    public void OnUpdate(MonsterController controller)
    {
        foreach (var skillExcute in skillExecutes)
        {
            skillExcute.OnUpdate(controller);
        }
    }
}
