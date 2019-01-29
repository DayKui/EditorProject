using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EditorWindowStudy : EditorWindow, IHasCustomMenu
{
    #region  IHasCustomMenu
    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddDisabledItem(new GUIContent("Disable"));
        menu.AddItem(new GUIContent("Test1"),true,()=> {
            Debug.Log("Test1");
        });
        menu.AddItem(new GUIContent("Test2"), true, () => {
            Debug.Log("Test2");
        });
        menu.AddSeparator("Test/");
        menu.AddItem(new GUIContent("Test/Test3"),true,()=> {
            Debug.Log("Test3");
        });
    }
    #endregion
    [MenuItem("Window/Open My Window")]
    static void Init()
    {
        EditorWindowStudy window = (EditorWindowStudy)EditorWindow.GetWindow(typeof(EditorWindowStudy));
        window.Show();
    }
}
