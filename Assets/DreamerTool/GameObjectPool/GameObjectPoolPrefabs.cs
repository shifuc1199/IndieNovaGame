/*****************************
Created by 师鸿博
*****************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "GameObjectPoolPrefabs")]
public class GameObjectPoolPrefabs : ScriptableObject 
{
    public List<GameObjectPoolPrefab> Prefabs = new List<GameObjectPoolPrefab>();
    
    public void AddGameObject(GameObjectPoolPrefab prefab)
    {
#if UNITY_EDITOR
        Prefabs.Add(prefab);
        EditorUtility.SetDirty(this);
         AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif
    }
 }
[System.Serializable]
public class GameObjectPoolPrefab
{
    [HideInInspector]
    public   string prefabType;
    public GameObject prefab;

    public GameObjectPoolPrefab(string pfbtype, GameObject pfb)
    {
        this.prefabType = pfbtype;
        this.prefab = pfb;
      
    }

    public GameObjectPoolPrefab()
    {
        
    }
}

