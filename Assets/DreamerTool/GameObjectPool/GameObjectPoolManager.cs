using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DreamerTool.EditorTool;
using System.IO;
using  System.Text;
using System;
using DreamerTool.Util;
using DreamerTool.Extra;
namespace DreamerTool.GameObjectPool
{



    public static class GameObjectPoolManager
    {
        private static Dictionary<GameObjectPoolPrefabType, GameObjectPool> pools =
            new Dictionary<GameObjectPoolPrefabType, GameObjectPool>();
#if UNITY_EDITOR    
 
        public static void AddGameObjectPoolPrefabType(List<GameObject> gameObjectLst)
        {
            var path = AssetDataBaseManager.GetScriptPath(DreamerToolConfig.GameObjectPrefabTypeName);
            if (path == "")
                return;

            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Truncate)))
            {
                StringBuilder result = new StringBuilder();
                var header = "public enum GameObjectPoolPrefabType\n{";
                result.Append(header);
                foreach (int v in Enum.GetValues(typeof(GameObjectPoolPrefabType)))
                {
                    result.Append("\n\t");
                    string strName = Enum.GetName(typeof(GameObjectPoolPrefabType), v);
                    var gameObj = gameObjectLst.Find(gameObject => { return gameObject.name == strName; });
                    if (gameObj != null)
                    {
                        gameObjectLst.Remove(gameObj);
                    }
                    
                    result.Append(strName);
                    result.Append(",");
                }



                foreach (var gameObject in gameObjectLst)
                {
                    result.Append("\n\t");
                    result.Append(gameObject.name);
                    result.Append(",");

                }


                result.Append("\n}");
                sw.Write(result.ToString());
            }

            var prefabs = DreamerUtil.GetScriptableObject<GameObjectPoolPrefabs>();
            foreach (var gameObject in gameObjectLst)
            {

                prefabs.AddGameObject(new GameObjectPoolPrefab(gameObject.name, gameObject));
            }
        }
        
#endif
        public static void InitByScriptableObject()
        {
            var prefabs = DreamerUtil.GetScriptableObject<GameObjectPoolPrefabs>();
            foreach (var item in prefabs.Prefabs)
            {
                var prefabType = item.prefabType.String2Enum<GameObjectPoolPrefabType>();
                if (!pools.ContainsKey(prefabType))
                    pools.Add(prefabType, new GameObjectPool(item.prefab));
            }
        }

        public static void ClearAll()
        {
            foreach (var pool in pools)
            {
                pool.Value.Clear();
            }
        }

        public static GameObjectPool AddPool(GameObjectPoolPrefabType pool_id, GameObject prefab)
        {
            if (pools.ContainsKey(pool_id))
            {
                return null;
            }

            var pool = new GameObjectPool(prefab);
            pools.Add(pool_id, pool);
            return pool;
        }

        public static GameObjectPool GetPool(GameObjectPoolPrefabType pool_id)
        {
            return pools[pool_id];
        }
    }
}