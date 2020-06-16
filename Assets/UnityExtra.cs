using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtra  
{
    public static void SetRotationOffset_180(this PlatformEffector2D effector2D,float time=0.5f)
    {
        effector2D.rotationalOffset = 180;
        Timer.Register(time, () => {  effector2D.rotationalOffset = 0;});
    }
}
