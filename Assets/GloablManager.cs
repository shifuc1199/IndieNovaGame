using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DreamerTool.Singleton;
using UnityEngine;

public class GloablManager : Singleton<GloablManager>
{
    public readonly MonoManager MonoManager;
    public readonly GameInput GameInput = new GameInput();
    public readonly PlayerInfo PlayerInfo = new PlayerInfo();
    public readonly EventManager EventManager = new EventManager();
    public readonly AssetsManager AssetsManager = new AssetsManager();
    
    public GloablManager()
    {
        MonoManager = new GameObject("MonoManager").AddComponent<MonoManager>();
    }
    
    public async Task GameInit()
    {
       this.GameInput.Enable();
       await AssetsManager.Load();
    }
 
}
