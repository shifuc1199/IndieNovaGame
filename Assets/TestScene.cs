using System;
using System.Collections;
using System.Collections.Generic;
using Tools.Monster;
using UnityEngine;
using UnityEngine.AddressableAssets;
using DreamerTool.UI;
public class TestScene : Scene
{
    public GameObject controller;
   private async void Awake()
   {
       base.Awake();
      await GloablManager.Instance.GameInit();
      controller.SetActive(true);
      GloablManager.Instance.PlayerInfo.AddMonster(new MonsterInfo(MonsterSet.Get(1)));
      GloablManager.Instance.PlayerInfo.AddMonster(new MonsterInfo(MonsterSet.Get(2)));
   }

   public void AddBag(int id)
   {
     var module = new ModuleInfo(ModuleSet.Get(id),1);
     GloablManager.Instance.PlayerInfo.AddBagModule(module);
   }
}
