using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Demos.RPGEditor;
using UnityEngine;
/// <summary>
/// 玩家信息类,用于实例化实时管理玩家游戏中的信息
/// </summary>
[CreateAssetMenu(fileName = "玩家信息",menuName = "信息/玩家保存信息")]
public class PlayerInfo : SerializedScriptableObject
{
    /// <summary>
    /// 玩家当前的怪物队伍列表
    /// </summary>
    public List<MonsterInfo> playerMonsterTeamList;
    /// <summary>
    /// 玩家当前的物品列表
    /// </summary>
    public List<ItemInfo> playerItemList;
    /// <summary>
    /// 玩家当前的背包内的模块列表
    /// </summary>
    public List<ModuleInfo> playerPubModuleList;
    /// <summary>
    /// 玩家场景信息
    /// </summary>
    public int playerSceneName;
    /// <summary>
    /// 玩家货币
    /// </summary>
    public int playerCoin;
    /// <summary>
    /// 玩家位置信息
    /// </summary>
    public Vector3 playerPostion;
}
