using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Demos.RPGEditor;
using UnityEngine;
/// <summary>
/// 玩家信息类,用于实例化实时管理玩家游戏中的信息
/// </summary>
 
public class PlayerInfo
{
    /// <summary>
    /// 玩家当前控制的怪物
    /// </summary>
    public MonsterInfo currentMonster;
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
    public List<ModuleInfo> playerPubModuleList = new List<ModuleInfo>();
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

 
    public void AddBagModule(ModuleInfo module)
    {
        playerPubModuleList.Add(module);
        GloablManager.Instance.EventManager.BroadCast(EventTypeArg.AddBagModule,module);
    }
}
