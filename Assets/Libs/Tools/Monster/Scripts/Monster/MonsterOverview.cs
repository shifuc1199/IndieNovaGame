using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Tools.Monster;
using UnityEditor;
using UnityEngine;
[GlobalConfig("Monsters",UseAsset = true)]
public class MonsterOverview : GlobalConfig<MonsterOverview>
{
    [ReadOnly] 
    [ListDrawerSettings(Expanded = true)] //扩大List
    public MonsterSet[] AllMonsters;

    [Button(ButtonSizes.Medium), PropertyOrder(-1)]
    public void UpdataMonsterOverview()
    {
        this.AllMonsters = AssetDatabase.FindAssets("t:MonsterSet")
            .Select(guid => AssetDatabase.LoadAssetAtPath<MonsterSet>(AssetDatabase.GUIDToAssetPath(guid)))
            .ToArray();
    }

}
