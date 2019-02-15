using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPreview(typeof(Camera))]
public class Preview1 : ObjectPreview {

    public override bool HasPreviewGUI()
    {
        return true;
    }
    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        base.OnPreviewGUI(r, background);
        GUI.DrawTexture(r,AssetDatabase.LoadAssetAtPath<Texture>("Assets/unity.png"));
        GUILayout.Label("Hello World!!");
    }
}
