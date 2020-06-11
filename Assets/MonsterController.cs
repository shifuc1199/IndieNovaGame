using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MonsterController : MonoBehaviour
{
    private MonsterInfo monsterInfo;
    public AssetReference asset;
    // Start is called before the first frame update
    void Start()
    {
        asset.LoadAssetAsync<MonsterInfo>().Completed+= (op) =>
        {

            monsterInfo = op.Result;   
             
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
