using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Stydy_01_01
{
    [MenuItem("Window/Test/yusong")]
    static void Test()
    {
    }

    [MenuItem("Window/Test/momo")]
    static void Test1()
    {
    }
    [MenuItem("Window/Test/雨松/MOMO")]
    static void Test2()
    {
    }

    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        EditorApplication.projectWindowItemOnGUI = delegate (string guid, Rect selectionRect)
          {
              if (Selection.activeObject &&
                  guid == AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(Selection.activeObject)))
              {
                  float width =40f;
                  selectionRect.x += (selectionRect.width - width);
                  selectionRect.y += 40;
                  selectionRect.width = width;
                  selectionRect.height = width;
                  GUI.color = Color.red;
                  if (GUI.Button(selectionRect,"click"))
                  {
                      Debug.LogFormat("Click:{0},",Selection.activeObject.name);
                  }
                  GUI.color = Color.white;
              }
          };
    }
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethodTwo()
    {
        EditorApplication.hierarchyWindowItemOnGUI = delegate (int instanceID, Rect selectionRect) {
            //在Hierarchy视图中选择一个资源
            if (Selection.activeObject &&
                instanceID == Selection.activeObject.GetInstanceID())
            {
                //设置拓展按钮区域
                float width = 50f;
                float height = 20f;
                selectionRect.x += (selectionRect.width - width);
                selectionRect.width = width;
                selectionRect.height = height;
                //点击事件
                if (GUI.Button(selectionRect, AssetDatabase.LoadAssetAtPath<Texture>("Assets/unity.png")))
                {
                    Debug.LogFormat("click : {0}", Selection.activeObject.name);
                }
            }
        };
    }

    [InitializeOnLoadMethod]
    static void StartInitializeOnLoadMethod()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        //if (Event.current != null && selectionRect.Contains(Event.current.mousePosition)
        //    && Event.current.button == 0&& Event.current.type == EventType.MouseUp)
        //{
        //    GameObject selectedGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        //    //这里可以判断selectedGameObject的条件
        //    if (selectedGameObject)
        //    {
        //        Vector2 mousePosition = Event.current.mousePosition;

        //        EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "Window/Test", null);
        //        Event.current.Use();
        //    }
        //}
    }

}
