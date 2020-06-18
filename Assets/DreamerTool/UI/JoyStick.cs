using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    protected bool isDown = false; //是否按下 可以在update里判断一直按下的函数
    public RectTransform bound;
    public RectTransform center;
    public bool isDisable = false;//不可用 不触发事件
    public bool isDrag = true;//可触发事件 不能拖拽
    public float radius;
    
    public void OnPointerDown(PointerEventData eventData)
    { 
        if (isDisable)
            return;
        if (!isDrag)
        {
            onJoystickDown(Vector2.zero, 0);
            return;
        }

        isDown = true;
        var dir = GetDir(eventData.position);
        float r = dir.magnitude;
        r = Mathf.Clamp(r, 0, radius);
        center.localPosition = dir.normalized * r;
        onJoystickDown(dir.normalized,r);
    }

  
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDisable)
            return;
        if (!isDrag)
        {
            onJoystickUp(Vector2.zero, 0);
            return;
        }

        isDown = false;
        var dir = GetDir(eventData.position);
        float r = dir.magnitude;
        r = Mathf.Clamp(r, 0, radius);
        center.localPosition = Vector2.zero;
        onJoystickUp(dir.normalized,r);
    }

    public void OnDrag(PointerEventData eventData)
    {
       
        if (isDisable)
            return;
        if (!isDrag)
        {
            onJoystickMove(Vector2.zero, 0);
            return;
        }
        var dir = GetDir(eventData.position);
        float r = dir.magnitude;
        r = Mathf.Clamp(r, 0, radius);
        center.localPosition = dir.normalized * r;
        onJoystickMove(dir.normalized,r);
    }

    public virtual void onJoystickDown(Vector2 V,float R)
    {

    }
    public virtual void onJoystickUp(Vector2 V, float R)
    {

    }
    public virtual void onJoystickMove(Vector2 V, float R)
    {

    }

    
    private Vector2 GetDir(Vector2 pos)
    {
        var uiCamera = DreamerTool.UI.Scene.GetUICamera();
       
        if (uiCamera != null)
        {
            return bound.InverseTransformPoint(uiCamera.ScreenToWorldPoint(pos));
        }
        else
        {
            return pos-(Vector2)center.position;
        }
    }

 
}
