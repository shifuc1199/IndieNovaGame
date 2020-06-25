using System.Collections;
using System.Collections.Generic;
using DreamerTool.Inactive;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemInactiveTrigger : InactiveTrigger
{
    private void OnEnable()
    {
        GloablManager.Instance.GameInput.Common.Inactive.performed +=   Inactive;
    }
    private void OnDisable()
    {
        GloablManager.Instance.GameInput.Common.Inactive.performed -= Inactive;
    }

    public void Inactive(InputAction.CallbackContext callback)
    {
        if (_inactive_event != null && otherGameobject!=null)
        {   
            _inactive_event.Invoke();
            //otherGameobject = null;
        }
    }

    public override void LateUpdate()
    {
        
    }
}
