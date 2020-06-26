using UnityEditor;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;
using XNode;
using  XNodeEditor;
[CustomNodeEditor(typeof(TalkChoiceNode))]
public class TalkChoiceNodeEdtior : NodeEditor
{
     
    public override void OnBodyGUI()
    {
        NodeEditorGUILayout.PortField(new GUIContent("In"), target.GetInputPort("In"), GUILayout.MinWidth(0));
       var node = target as TalkChoiceNode;
       EditorGUILayout.LabelField("内容");
       node.content= EditorGUILayout.TextArea(node.content,GUILayout.Height(50));
 
       
        NodeEditorGUILayout.DynamicPortList("Choices",typeof(byte),serializedObject,XNode.NodePort.IO.Output);
      
      
      
       
    }
}
