using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObjectRecover : MonoBehaviour
{
    public UnityAction<GameObject> recover_call_back;
    public void Recover(float timer)
    {
        if (timer == -1)
            return;
     
        Invoke("Recover", timer);
    }
    public void RecoverImmediately()
    {
        CancelInvoke();
        Recover();
    }
    private void Recover()
    {
        recover_call_back?.Invoke(gameObject);
    }
}