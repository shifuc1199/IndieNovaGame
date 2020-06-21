using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMonster : TableView<TeamMonsterCell,MonsterInfo>
{
    public override void Init()
    {
        base.Init();
        foreach (var monster in GloablManager.Instance.PlayerInfo.playerMonsterTeamList)
        {
            AddCell(monster);
        }
    }

 
}
