using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DrawContext : Editor {

    [MenuItem("CONTEXT/Transform/New Context 1")]
    public static void NewContext(MenuCommand command)
    {
        Debug.Log(command.context.name);
        
    }
    [MenuItem("CONTEXT/Component/New Context 2")]
    public static void NewContext2(MenuCommand command)
    {
        Debug.Log(command.context.name);
    }

}
