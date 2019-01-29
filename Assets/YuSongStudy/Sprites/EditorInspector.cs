using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EditorInspector : MonoBehaviour {

    public Vector3 scrollPos;
    public int myId;
    public string myName;
    public GameObject prefab;
    public MyEnum myEnum = MyEnum.One;
    public bool toogle1;
    public bool toogle2;

    public enum MyEnum
    {
        One = 1,
        Two,
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(EditorInspector))]
public class ScriptEditorInspector : Editor
{
    private bool m_EnableToogle;
    public override void OnInspectorGUI()
    {
        //获取脚本对象
        EditorInspector script = target as EditorInspector;
        //绘制滚动条
        script.scrollPos = EditorGUILayout.BeginScrollView(script.scrollPos,false ,true);

        script.myName = EditorGUILayout.TextField("text",script.myName);
        script.myId = EditorGUILayout.IntField("int",script.myId);
        script.prefab = EditorGUILayout.ObjectField("GameObject",script.prefab,typeof(GameObject),true)as GameObject;

        //绘制按钮
        EditorGUILayout.BeginHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Button("1");
        GUILayout.Button("2");
        script.myEnum = (EditorInspector.MyEnum)EditorGUILayout.EnumPopup("MyEnum:",script.myEnum);
        //Toggle组件
        m_EnableToogle = EditorGUILayout.BeginToggleGroup("EnableToggle",m_EnableToogle);
        script.toogle1 = EditorGUILayout.Toggle("toggle1",script.toogle1);
        script.toogle2 = EditorGUILayout.Toggle("toggle2",script.toogle2);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndScrollView();
    }
}
#endif

