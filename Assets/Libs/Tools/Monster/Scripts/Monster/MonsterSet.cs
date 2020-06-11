using System.Collections;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

namespace Tools.Monster
{
    using UnityEngine;
    using System;
    /// <summary>
    /// 怪物的预设文件类,存放怪物初始的配置
    /// </summary>
    public class MonsterSet : SerializedScriptableObject
    {
        /// <summary>
        /// 怪物的预览图标,头像
        /// </summary>
        public Sprite monsterIcon;
        /// <summary>
        /// 怪物的种族名字
        /// </summary>
        public String monsterSpecificName;
        /// <summary>
        /// 怪物的ID编号
        /// </summary>
        public int monsterID;
        /// <summary>
        /// 怪物的种族等级
        /// </summary>
        public int monsterSpecificLevel;
        /// <summary>
        /// 怪物对模块的适应能力
        /// </summary>
        public Dictionary<ModuleSet, DetermineExtent> moduleAdaptability;
         
        /// <summary>
        /// 怪物的出生模块
        /// </summary>
        public ModuleSet birthModule;
        /// <summary>
        /// 怪物描述
        /// </summary>
        [TextArea]
        public string monsterDetail;
    }
    

    

}




