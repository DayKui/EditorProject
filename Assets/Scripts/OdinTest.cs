using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.Utilities.Editor;
#endif
public class OdinTest : SerializedMonoBehaviour {

    [Title("数据类型")]
    [FoldoutGroup("基本数据")]
    public bool boolValue;

    [ShowIf("boolValue")]
    [FoldoutGroup("基本数据")]
    public string str;
    [FoldoutGroup("基本数据")]
    [MinValue(0)]
    public int minValueLimit = 1;
    [FoldoutGroup("基本测试")]
    [MaxValue(100)]
    public int maxValueLimit = 99;
    [Wrap(0,100)]
    public int valueLimit = 50;

    [MinMaxSlider(0,100)]
    public Vector2 v;
    [ProgressBar(0,1,ColorMember = "ChangeColor")]
    public float hpBar;

    public Color ChangeColor(float value)
    {
        return Color.Lerp(Color .red ,Color.green ,MathUtilities.LinearStep(0,1,value));
    }

    [EnumToggleButtons]
    public Direction direction;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    [Title("数据结构")]
    [ListDrawerSettings(NumberOfItemsPerPage =5)]
    public List<int> array;

    public Dictionary<int,string> keyValuePairs;

    [ValueDropdown("doopDownValues")]
    public string value;
    private string[] doopDownValues = new string[] {"Odin","Thor","Loki" };
    //PopUp
    public List<string> stringList;
    [HideInInspector]
    public string selectString;


}
