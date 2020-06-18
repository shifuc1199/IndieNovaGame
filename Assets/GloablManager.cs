using System.Collections;
using System.Collections.Generic;
using DreamerTool.Singleton;
using UnityEngine;

public class GloablManager : Singleton<GloablManager>
{
    public PlayerInfo PlayerInfo = new PlayerInfo();
    public EventManager EventManager = new EventManager();

    public void GameInit()
    {
        
    }
}
