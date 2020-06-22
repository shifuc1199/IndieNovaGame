using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPool : TableView<SkillCell,SkillInfo,MonsterInfo>
{
    public void SetMonster(MonsterInfo monsterInfo)
    {
        this.SetCommonModel(monsterInfo);
        ClearCell();
        foreach (var skill in monsterInfo.monSkillPool)
        {
            AddCell(skill.Value,monsterInfo);
        }
    }
}
