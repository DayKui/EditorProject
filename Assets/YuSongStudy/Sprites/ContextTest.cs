using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ContextTest : MonoBehaviour {

    public string contextName;

#if UNITY_EDITOR
    [MenuItem("CONTEXT/ContextTest/New Context3")]
    public static void NewContext3(MenuCommand command)
    {
        ContextTest script = (command.context as ContextTest);
        script.contextName = "hello world!!";
    }

    [ContextMenu("Remove Component")]
    void RemoveComponent()
    {
        Debug.Log("RemoveComponent");
        //等一帧在删除自己
        UnityEditor.EditorApplication.delayCall = delegate ()
        {
            DestroyImmediate(this);
        };
    }
#endif
}
