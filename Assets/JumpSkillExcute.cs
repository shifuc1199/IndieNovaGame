using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSkillExcute : SkillExecute
{
    public int maxJumpCount;
    private int jumpIndex=0;
    public override void OnEquip(MonsterInfo monsterInfo)
    {
         
    }

    public override void OnUnEquip(MonsterInfo monsterInfo)
    {
         
    }

    public override void OnUpdate(MonsterController controller)
    {
        if(controller.moveInput.y<0)
            return;
        
        if (controller.isGround)
        {
            jumpIndex = 0;
        }

        if (controller.mosterControlInput.MonsterControll.Jump.triggered)
        { 
            
            if(jumpIndex>=maxJumpCount)
                return;
            controller.JumpExcute();
            jumpIndex++;
        }
    }
}
