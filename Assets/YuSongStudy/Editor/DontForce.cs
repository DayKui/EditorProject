using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DontForce {
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        SceneView.onSceneGUIDelegate = delegate (SceneView sceneView)
        {
            Event e = Event.current;
            if (e != null)
            {
                int controlId = GUIUtility.GetControlID(FocusType.Passive);
                if (e.type == EventType.Layout)
                {
                    HandleUtility.AddDefaultControl(controlId);
                }
            }
        };
    }
}
