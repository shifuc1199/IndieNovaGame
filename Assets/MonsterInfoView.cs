using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterInfoView : MonoBehaviour
{
    Dictionary<ModuleInfo,GameObject> equipModuleCell = new Dictionary<ModuleInfo, GameObject>();
    Dictionary<ModuleInfo,GameObject> bagModuleInfoCell = new Dictionary<ModuleInfo, GameObject>();
    public GameObject moduleCellPrefab;
    public GameObject bagModuleCellPrefab;
    public Transform moduleEquip;
    public Transform moduleBag;
    public Transform skillEquip;
    private MonsterInfo _monsterInfo;
    public Text levelText;
    // Start is called before the first frame update
    private void Awake()
    {
        SetModel(GloablManager.Instance.PlayerInfo.currentMonster);
        InitBagModule();
 
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.EquipModule,RemoveBagModule);
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.EquipModule,AddEquipModule);
        GloablManager.Instance.EventManager.AddListener<ModuleInfo>(EventTypeArg.AddBagModule,AddBagModule);
    }

    private void OnDestroy()
    {
        GloablManager.Instance.EventManager.RemoveListener<ModuleInfo>(EventTypeArg.EquipModule,RemoveBagModule);
        GloablManager.Instance.EventManager.RemoveListener<ModuleInfo>(EventTypeArg.EquipModule,AddEquipModule);
        GloablManager.Instance.EventManager.RemoveListener<ModuleInfo>(EventTypeArg.AddBagModule,AddBagModule);
    }

    public void InitBagModule()
    {
       var bagModules = GloablManager.Instance.PlayerInfo.playerPubModuleList;

       foreach (var bagModule in bagModules)
       {
           var cell = Instantiate(bagModuleCellPrefab, moduleBag);
           cell.GetComponent<ModuleCell>().SetModel(bagModule);
           bagModuleInfoCell.Add(bagModule,cell);
       }
    }

    public void RemoveBagModule(ModuleInfo info)
    {
        if (bagModuleInfoCell.ContainsKey(info))
        {
            Destroy(bagModuleInfoCell[info]);
            bagModuleInfoCell.Remove(info);
        }
    }
    public void AddBagModule(ModuleInfo moduleInfo)
    {
        var cell = Instantiate(bagModuleCellPrefab, moduleBag);
        cell.GetComponent<ModuleCell>().SetModel(moduleInfo);
        
        bagModuleInfoCell.Add(moduleInfo,cell);
    }
    public void RemoveEquipModule(ModuleInfo info)
    {
        if (equipModuleCell.ContainsKey(info))
        {
            Destroy(equipModuleCell[info]);
            equipModuleCell.Remove(info);
        }
    }
    public void AddEquipModule(ModuleInfo moduleInfo)
    {
        var cell = Instantiate(moduleCellPrefab, moduleEquip);
        cell.GetComponent<ModuleCell>().SetModel(moduleInfo);
        
        equipModuleCell.Add(moduleInfo,cell);

        UpdateMonsterLevelText();
    }

    public void UpdateMonsterLevelText()
    {
        levelText.text ="怪物等级："+_monsterInfo.levelNow+"/"+ _monsterInfo.monsterSet.monsterSpecificLevel+"\n容器等级: "+_monsterInfo.containerLevel;
    }
    public void SetModel(MonsterInfo monster)
    {
        _monsterInfo = monster;
        
        foreach (var module in monster.monModuleInfos)
        {
            var cell = Instantiate(moduleCellPrefab, moduleEquip);
            cell.GetComponent<ModuleCell>().SetModel(module);
            equipModuleCell.Add(module,cell);
        }

        UpdateMonsterLevelText();
    }
}
