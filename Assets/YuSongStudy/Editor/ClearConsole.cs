using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
public class ClearConsole  {

    [MenuItem("Tools/CreateConsole")]
    static void CreateConsole()
    {
        Debug.Log("CreateConsole");
    }
    [MenuItem("Tools/CleanConsole")]
    static void CleanConsole()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(Editor));
        MethodInfo methodInfo = assembly.GetType("UnityEditor.LogEntries").GetMethod("Clear");
        methodInfo.Invoke(new object(),null);
    }
}
