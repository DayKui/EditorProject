using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
[CustomEditor(typeof(Transform))]
public class DrawTransform : Editor {
    private Editor m_Ediotr;
    private void OnEnable()
    {
        m_Ediotr = Editor.CreateEditor(target, 
            Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.TransformInspector", true));
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("扩展按钮")) { }
        GUI.enabled = false;
        m_Ediotr.OnInspectorGUI();
        GUI.enabled = true;
    }

    [MenuItem("GameObject/3D Object/Lock/Lock", false, 0)]
    static void Lock()
    {
        if (Selection.gameObjects !=null)
        {
            foreach (var gameObject in Selection.gameObjects)
            {
                gameObject.hideFlags = HideFlags.NotEditable;
            }
        }
    }
    [MenuItem("GameObject/3D Object/Lock/UnLock", false, 1)]
    static void UnLock()
    {
        if (Selection.gameObjects !=null)
        {
            foreach (var gameObject in Selection.gameObjects)
            {
                gameObject.hideFlags = HideFlags.None;
            }
        }

    }


}
