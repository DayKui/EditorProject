using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Camera))]
public class DrawScene : Editor {

    private void OnSceneGUI()
    {
        Camera camera = target as Camera;
        if (camera!=null)
        {
            Handles.color = Color.red;
            Handles.Label(camera.transform.position, camera.transform.position.ToString());

            Handles.BeginGUI();
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("click",GUILayout.Width(200f)))
            {
                Debug.LogFormat("click={0}",camera.name);
            }
            GUILayout.Label("Lable");
            Handles.EndGUI();
        }
    }
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        SceneView.onSceneGUIDelegate = delegate (SceneView sceneView)
        {
            Handles.BeginGUI();

            GUI.Label(new Rect(0, 0, 50, 15), "标题");
            GUI.Button(new Rect(0, 20, 50, 50), AssetDatabase.LoadAssetAtPath<Texture>("Assets/unity.png"));

            Handles.EndGUI();
        };
    }
}
