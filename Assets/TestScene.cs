using System;
using System.Collections;
using System.Collections.Generic;
using Tools.Monster;
using UnityEngine;
using UnityEngine.AddressableAssets;
using DreamerTool.UI;
public class TestScene : Scene
{
    private DialogueGraph dialogueGraph;
   public GameObject controller;
   private async void Awake()
   {
      base.Awake();
      await GloablManager.Instance.GameInit();
      controller.SetActive(true);
      var monster_1 = new MonsterInfo(MonsterSet.Get(1));
      var monster_2 = new MonsterInfo(MonsterSet.Get(2));
      GloablManager.Instance.PlayerInfo.AddMonster(monster_1);
      GloablManager.Instance.PlayerInfo.AddMonster(monster_2);
      View.CurrentScene.GetView<MonsterInfoView>().SetModel(monster_1);
   }

   public void PlayDialogueGraph(DialogueGraph graph)
   {
       this.dialogueGraph = graph;
       graph.Reset();
       
   }

   private void Update()
   {
       if (dialogueGraph != null)
       {
           dialogueGraph.Execute();
           if (dialogueGraph.state == RunningState.Stop)
           {
               dialogueGraph = null;
           }
       }
   }

   public void AddBag(int id)
   {
     var module = new ModuleInfo(ModuleSet.Get(id),1);
     GloablManager.Instance.PlayerInfo.AddBagModule(module);
   }
}
