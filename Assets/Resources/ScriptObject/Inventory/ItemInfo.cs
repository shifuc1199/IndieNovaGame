using Sirenix.OdinInspector;
using UnityEngine;
/// <summary>
/// 物品信息类,用于实例化实时管理玩家游戏中的物品信息
/// </summary>
[CreateAssetMenu(fileName = "物品信息",menuName = "信息/物品保存信息")]
public class ItemInfo : SerializedScriptableObject
{
    /// <summary>
    /// 物品预设引用
    /// </summary>
    public ItemSet itemSet;
    /// <summary>
    /// 物品数量
    /// </summary>
    public int num;

}
