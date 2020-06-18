using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestScene : MonoBehaviour
{
   public AssetReference asset;
   public void AddBag()
   {
      asset.LoadAssetAsync<ModuleSet>().Completed += op =>
      {
         var module = new ModuleInfo(op.Result,30);
         GloablManager.Instance.PlayerInfo.AddBagModule(module);
     
      };
    
   }
}
