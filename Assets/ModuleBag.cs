using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class ModuleBag : TableView<BagModuleCell,ModuleInfo,MonsterInfo>
{
    private MonsterInfo monsterInfo;
    public void SetMonster(MonsterInfo monsterInfo)
    {
        this.monsterInfo = monsterInfo;
        
        SetCommonModel(monsterInfo);
    }
    
    public override void Init()
    {
        var bagModules = GloablManager.Instance.PlayerInfo.playerPubModuleList;
        foreach (var module in bagModules)
        {
            AddCell(module,null);
        }    
    }
}
