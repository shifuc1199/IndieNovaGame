using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamerTool.GameObjectPool
{

    public class GameObjectPool
    {

        private Queue<GameObject> object_pool_queue = new Queue<GameObject>();
        private GameObject _prefab;

        public GameObjectPool(GameObject _prefab)
        {
            this._prefab = _prefab;
        }

        public virtual GameObject Get(Vector3 pos, Quaternion rot, float life_time = -1)
        {
            GameObject get_object = null;
            if (object_pool_queue.Count == 0)
            {
                get_object = GameObject.Instantiate(_prefab, pos, rot);
                ObjectRecover _recover = get_object.AddComponent<ObjectRecover>();
                _recover.recover_call_back = Remove;
            }
            else
            {
                get_object = object_pool_queue.Dequeue();
                get_object.SetActive(true);
                get_object.transform.position = pos;
                get_object.transform.rotation = rot;
            }

            get_object.GetComponent<ObjectRecover>().Recover(life_time);

            return get_object;
        }

        public virtual void Remove(GameObject tempObject)
        {
            tempObject.SetActive(false);
            object_pool_queue.Enqueue(tempObject);
        }

        public void Clear()
        {
            object_pool_queue.Clear();
        }
    }
}