using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamerTool.Singleton
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject temp = new GameObject();
                    temp.name = typeof(T).Name;
                    instance = temp.AddComponent<T>();
                }

                return instance;
            }
        }
    }
}
