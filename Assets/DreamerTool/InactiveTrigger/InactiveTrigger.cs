using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace DreamerTool.Inactive
{
    public class InactiveTrigger : MonoBehaviour
    {
        public string _inactive_key;
        public GameObject _inactive_key_show;
        [HideInInspector]public GameObject otherGameobject;
        [Header("-----------事件-----------")]
        public UnityEvent _inactive_event;

        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player")
                return;

            if(_inactive_key_show)
                _inactive_key_show.SetActive(true);

            otherGameobject = other.gameObject;


        }

        public virtual void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag != "Player")
                return;
            
            if (_inactive_key_show)
                _inactive_key_show.SetActive(false);

            otherGameobject = null;
        }

       
        public   virtual  void LateUpdate()
        {
            if (_inactive_event != null && otherGameobject!=null)
            {
                if (Input.GetKeyDown(_inactive_key))
                {
                    _inactive_event.Invoke();
                    otherGameobject = null;
                }
            }
        }
    }
}