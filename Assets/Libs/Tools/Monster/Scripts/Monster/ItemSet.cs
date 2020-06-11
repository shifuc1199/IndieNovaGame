 using System;
 using Sirenix.OdinInspector;
 using Tools.Monster;
 using UnityEngine;

 public class ItemSet : SerializedScriptableObject
 {
     public String itemName;
     public Sprite itemIconA;
     public int itemID;
     public int itemShopPrice;
     public ItemType itemType;
     public GameObject itemSetView;
     [TextArea] public String itemDetail;

 }
 