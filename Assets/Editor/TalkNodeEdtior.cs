using UnityEditor;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;
using  XNodeEditor;
[CustomNodeEditor(typeof(TalkNode))]
public class TalkNodeEdtior : NodeEditor
{
    public bool istest;
    private bool isShowList=true;
    private int count = 0;
    public override void OnBodyGUI()
    {
        GUILayout.BeginVertical();
        NodeEditorGUILayout.PortField(new GUIContent("In"), target.GetInputPort("In"), GUILayout.MinWidth(0));
        NodeEditorGUILayout.PortField(new GUIContent("Out"), target.GetOutputPort("Out"), GUILayout.MinWidth(0));
        GUILayout.EndVertical();
        TalkNode node = target as TalkNode;
        node.talker.talkerName = EditorGUILayout.TextField("名称",node.talker.talkerName);
        node.talker.talkerHead = EditorGUILayout.ObjectField("头像", node.talker.talkerHead, typeof(Sprite),GUILayout.Width(200),GUILayout.Height(125)) as Sprite;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("对话数量：");
        count  =  EditorGUILayout.IntField(node.content.Count);
         if (count > node.content.Count)
         {
             for (int i = node.content.Count; i < count; i++)
             {
                 node.content.Add("");
             }

         }
         else if (count < node.content.Count)
         {
             for (int i = node.content.Count-1; i >= count; i--)
             {
                 node.content.RemoveAt(i);
             }
         }
         EditorGUILayout.EndHorizontal();
         EditorGUILayout.BeginHorizontal();
       

        if (isShowList)
        {
            if (GUILayout.Button("折叠",GUILayout.Height(20)))
            {
                isShowList = false;
            }
        }
        else
        {
            if (GUILayout.Button("展开",GUILayout.Height(20)))
            {
                isShowList = true;
            }
        }
        if (GUILayout.Button("+",GUILayout.Width(20)))
        {
            node.content.Add("");
            count++;
        }
        EditorGUILayout.EndHorizontal();
        if (isShowList)
        {
            int removeIndex = -1;
           
            for (int i = 0; i < node.content.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                node.content[i] = EditorGUILayout.TextArea(node.content[i], GUILayout.Height(50),GUILayout.Width(245));
                if (GUILayout.Button("-", GUILayout.Width(20), GUILayout.Height(50)))
                {
                    removeIndex = i;
                }
                EditorGUILayout.EndHorizontal();
            }

            if (removeIndex != -1)
            {
                node.content.RemoveAt(removeIndex);
                count--;
            }
        }
    }
}
