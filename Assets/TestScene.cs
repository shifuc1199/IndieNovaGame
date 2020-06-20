using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestScene : MonoBehaviour
{
 
   private void Awake()
   {
      GloablManager.Instance.GameInit();
   }

   public void AddBag(int id)
   {
     var module = new ModuleInfo(ModuleSet.Get(id),1);
     GloablManager.Instance.PlayerInfo.AddBagModule(module);
   }
}
