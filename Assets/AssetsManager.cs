using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools.Monster;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class AssetsManager  
{
    public async Task Load()
    {
      await ModuleSet.Load();
      await MonsterSet.Load();
         
    }
 
}
