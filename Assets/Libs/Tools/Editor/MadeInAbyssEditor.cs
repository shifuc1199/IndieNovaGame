using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector.Demos.RPGEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using Tools.Monster;
using UnityEditor;
using UnityEngine;

public class MadeInAbyssEditor : OdinMenuEditorWindow
{
    [MenuItem("Tools/AbyssEditor")]
    private static void Open()
    {
        var window = GetWindow<MadeInAbyssEditor>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
    }

    protected override OdinMenuTree BuildMenuTree()
    {

        var tree = new OdinMenuTree(true);
        tree.DefaultMenuStyle.IconSize = 28.00f; //图标大小
        tree.Config.DrawSearchToolbar = true; //搜索栏
        //角色预览页
        MonsterOverview.Instance.UpdataMonsterOverview();
        tree.Add("Monsters", new MonsterTable(MonsterOverview.Instance.AllMonsters));
        //增加所有角色到左边
        tree.AddAllAssetsAtPath("Resources/ScriptsObject/MonsterSet", "Assets", typeof(MonsterSet), true, true);
        //添加所有的模块到左边
        tree.AddAllAssetsAtPath("Resources/ScriptsObject/ModuleSet", "Assets", typeof(ModuleSet), true,true);
        //拖拽功能
        tree.EnumerateTree().Where(x => x.Value as ModuleSet).ForEach(AddDragHandles);
        //添加所有的技能到左边
        tree.AddAllAssetsAtPath("Resources/ScriptsObject/SkillSet", "Assets", typeof(SkillSet), true,true);
        //拖拽功能
        tree.EnumerateTree().Where(x => x.Value as SkillSet).ForEach(AddDragHandles);
        //添加图标
        tree.EnumerateTree().AddIcons<MonsterSet>(x => x.monsterIcon);
        tree.EnumerateTree().AddIcons<ModuleSet>(x => x.moduleIconA);
        tree.EnumerateTree().AddIcons<SkillSet>(x => x.skillIconA);
        return tree;
    }

    private void AddDragHandles(OdinMenuItem menuItem)
    {
        menuItem.OnDrawItem += x => DragAndDropUtilities.DragZone(menuItem.Rect, menuItem.Value, false, false);
    }

    protected override void OnBeginDrawEditors()
    {
        var selected = this.MenuTree.Selection.FirstOrDefault();
        var toolbarHeight = this.MenuTree.Config.SearchToolbarHeight;
        SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
        {
            if (selected != null)
            {
                GUILayout.Label(selected.Name);
            }

            if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建模组")))
            {
                ScriptableObjectCreator.ShowDialog<ModuleSet>("Assets/Resources/ScriptObject/ModuleSet", obj =>
                {
                    obj.moduleName = obj.name;
                    base.TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }

            if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建怪物")))
            {
                ScriptableObjectCreator.ShowDialog<MonsterSet>("Assets/Resources/ScriptObject/MonsterSet", obj =>
                {
                    obj.monsterSpecificName = obj.name;
                    base.TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }
            if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建技能")))
            {
                ScriptableObjectCreator.ShowDialog<SkillSet>("Assets/Resources/ScriptObject/SkillSet", obj =>
                {
                    obj.skillName = obj.name;
                    base.TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }
}
