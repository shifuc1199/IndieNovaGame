using System.Collections;
using System.Collections.Generic;
using DreamerTool.Inactive;
using UnityEngine;

public class InputSystemInactiveTrigger : InactiveTrigger
{
    private void Awake()
    {
        GloablManager.Instance.GameInput.Common.Inactive.performed += callback=> Inactive();
    }

    public void Inactive()
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
