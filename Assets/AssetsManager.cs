using System.Collections;
using System.Collections.Generic;
using Tools.Monster;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class AssetsManager  
{
    public void Load()
    {
        ModuleSet.Load();
        MonsterSet.Load();
    }
 
}
