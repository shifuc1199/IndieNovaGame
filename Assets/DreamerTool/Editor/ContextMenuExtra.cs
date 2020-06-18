
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using DreamerTool.GameObjectPool;
using DreamerTool.Util;
 
public class ContextMenuExtra   
{
   
   [MenuItem(  "Assets/AddToGameObjectPool")]
   private static void AddToGameObjectPool()
   {
       var config =  DreamerUtil.GetScriptableObject<GameObjectPoolPrefabs>();
       var selectObjects = Selection.objects;
       List<GameObject> gameObjectList = new List<GameObject>();
       foreach (var selectedobject in selectObjects)
       {
           if (selectedobject is GameObject)
           {
               gameObjectList.Add(selectedobject as GameObject);
              
           }
           else
           {
             Debug.Log(selectedobject.name+"不是预制体");
           }
       }
       
      GameObjectPoolManager.AddGameObjectPoolPrefabType(gameObjectList);
   }
}
