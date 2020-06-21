using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DreamerTool.UI;
public class MonsterInfoView : View
{  
    private MonsterInfo _monsterInfo;
    public SkillPool skillPool;
    public SkillEquip skillEquip;
    public ModuleEquip moduleEquip;
    public ModuleBag moduleBag;
    public Text levelText;
    // Start is called before the first frame update
    private void Awake()
    {
        SetModel(GloablManager.Instance.PlayerInfo.currentMonster);
        GloablManager.Instance.EventManager.AddListener<SkillInfo>(EventTypeArg.RemoveSkill,skillInfo=>
        {
            skillPool.RemovelCell(skillInfo);
        });
        GloablManager.Instance.EventManager.AddListener<SkillInfo>(EventTypeArg.UnEquipSkill,skillInfo=>
        {
            skillEquip.RemovelCell(skillInfo);
             
        });
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.UnEquipModule,moduleinfo=>
        {
            moduleBag.AddCell(moduleinfo,_monsterInfo);
            moduleEquip.RemovelCell(moduleinfo);
        });
        GloablManager.Instance.EventManager.AddListener<SkillInfo>(EventTypeArg.EquipSkill,skillinfo=>
        {
            skillEquip.AddCell(skillinfo,_monsterInfo);
        });
        GloablManager.Instance.EventManager.AddListener<SkillInfo>(EventTypeArg.AddSkill,skillinfo=>
        {
            skillPool.AddCell(skillinfo,_monsterInfo);
        });
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.AddBagModule,moduleInfo=>
        {
            moduleBag.AddCell(moduleInfo,_monsterInfo);
        });
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.EquipModule,moduleInfo=>
        {
            moduleBag.RemovelCell(moduleInfo);
            moduleEquip.AddCell(moduleInfo);
        });
        GloablManager.Instance.EventManager.AddListener(EventTypeArg.LevelNowChange,()=>
        {
            moduleBag.RefreshAllCell();
            moduleEquip.RefreshAllCell();
            UpdateMonsterLevelText();
        });
    }

    public void UpdateMonsterLevelText()
    {
        levelText.text ="怪物等级："+_monsterInfo.levelNow+"/"+ _monsterInfo.monsterSet.monsterSpecificLevel+"\n容器等级: "+_monsterInfo.containerLevel;
    }
    public void SetModel(MonsterInfo monster)
    {
        _monsterInfo = monster;
        moduleEquip.SetMonster(monster);
        moduleBag.SetMonster(monster);
        UpdateMonsterLevelText();
    }
}
