using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModuleCell : MonoBehaviour
{
    protected ModuleInfo moduleInfo;
    
    public Text infoText;

    public virtual void SetModel(ModuleInfo info)
    {
        moduleInfo = info;
        
        infoText.text = info.moduleSet.moduleName + ": LV " + info.moduleLevel;
    }
}
