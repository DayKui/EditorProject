using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AssetsEditor {

    public class Script_03_01
    {
        [MenuItem("Assets/My Tools/Tools 1", false, 2)]
        static void MyTools1()
        {
            Debug.Log(Selection.activeObject.name);
        }
        [MenuItem("Assets/My Tools/Tools 2", false, 1)]
        static void MyTools2()
        {
            Debug.Log(Selection.activeObject.name);
        }
        [MenuItem("Assets/Create/My Create/Cube", false, 2)]
        static void CreateCube()
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube); //创建立方体
        }
        [MenuItem("Assets/Create/My Create/Sphere", false, 1)]
        static void CreateSphere()
        {
            GameObject.CreatePrimitive(PrimitiveType.Sphere);//创建球体
        }
        [MenuItem("GameObject/My Create/Cylinder", false, 0)]
        static void CreateCylinder()
        {
            GameObject.CreatePrimitive(PrimitiveType.Cylinder); //创建立方体
        }
    }
}
