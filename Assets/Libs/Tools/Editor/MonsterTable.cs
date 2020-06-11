using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Tools.Monster;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

//使用这个类来使用TableList属性呈现所有怪物的概述。不过，所有怪物都是统一对象，
    //因此它们在检查器中呈现为单个统一对象怪物，这并不是我想要的。我想向大家展示全部的怪物。
    //所以为了呈现Unity对象的成员，我将创建一个类来包装Unity对象
    //并通过与TableList和attributes一起工作的properties显示相关成员。
public class MonsterTable 
{    //绘制左边部分
    [FormerlySerializedAs("allMonsters")]
    [TableList(IsReadOnly = true, AlwaysExpanded = true), ShowInInspector]
    //private
    private readonly List<MonsterWrapper> allMonsters;

    public MonsterSet this[int index]
    {
        get { return this.allMonsters[index].Monster; }
    }

    public MonsterTable(IEnumerable<MonsterSet> monsters)
    {
        this.allMonsters = monsters.Select(x => new MonsterWrapper(x)).ToList();
    }
    private class MonsterWrapper
    {
        private MonsterSet monster; 
        public MonsterSet Monster
        {
            get { return this.monster; }

        }

        public MonsterWrapper(MonsterSet monster)
        {
            this.monster = monster;
        }
        [TableColumnWidth(50,false)]//横着的合集
        [ShowInInspector,PreviewField(45,ObjectFieldAlignment.Center)]
        public Sprite monsterIcon_Table
        {
            get { return this.monster.monsterIcon; }
            set { this.monster.monsterIcon = value;EditorUtility.SetDirty(this.monster); }
            //如果修改一个prefab的MonoBehaviour或ScriptableObject变量，必须告诉Unity该值已经改变。每当一个属性发生变化，
            //Unity内置组件在内部调用setDirty。MonoBehaviour或ScriptableObject不自动做这个，因此如果你想值被保存，必须调用SetDirty
        }

        [TableColumnWidth(70, false)]
        [ShowInInspector]
        [VerticalGroup("Name"),HideLabel]
        public string monsterSpecificName_Table
        {
            get { return this.monster.monsterSpecificName; }
            set { this.monster.monsterSpecificName = value;EditorUtility.SetDirty(this.monster); }
        }

        [TableColumnWidth(230, false)] [ShowInInspector]
        public ModuleSet birthModule_table
        {
            get { return this.monster.birthModule; }
            set { this.monster.birthModule = value;EditorUtility.SetDirty(this.monster); }
        }
    
        /*
        [TableColumnWidth(230, false)]
        [ShowInInspector]
        public MonsterSet.SomeEnum AttackType
        {
            get { return this.monster.普通攻击类型; }
            set { this.monster.普通攻击类型 = value;EditorUtility.SetDirty(this.monster); }
        }
        */



    }
}
