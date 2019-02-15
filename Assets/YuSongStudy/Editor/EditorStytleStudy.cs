using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;

public class EditorStytleStudy : EditorWindow {

    static List<GUIStyle> styles = null;
    [MenuItem("Window/Open My Window2")]
    public static void Test()
    {
        EditorWindow.GetWindow<EditorStytleStudy>("styles");
        styles = new List<GUIStyle>();
        foreach (PropertyInfo fi in typeof(EditorStyles).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
            object o = fi.GetValue(null, null);
            if (o.GetType() == typeof(GUIStyle))
            {
                styles.Add(o as GUIStyle);
            }
        }
    }

    public Vector2 scrollPosition = Vector2.zero;
    void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        for (int i = 0; i < styles.Count; i++)
        {
            GUILayout.Label("EditorStyles." + styles[i].name, styles[i]);
        }
        GUIStyle style = new GUIStyle(EditorStyles.largeLabel);
        style.normal.textColor = Color.red;
        GUILayout.Label("测试了", style);
        GUILayout.EndScrollView();
    }
}
