using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( Variable ) )]
public class VariableEditor : Editor
{
	private Variable _variable { get { return target as Variable; } }

	private SerializedProperty _intValue;

	private SerializedProperty _floatValue;

	private SerializedProperty _boolValue;

	private SerializedProperty _direction;

	private SerializedProperty _prefab;

	private void OnEnable()
	{
        //_intValue = serializedObject.FindProperty("intValue");
        //_floatValue = serializedObject.FindProperty("floatValue");
        //_boolValue = serializedObject.FindProperty("boolValue");
        //_direction = serializedObject.FindProperty("direction");
        //_prefab = serializedObject.FindProperty("prefab");
    }

	public override void OnInspectorGUI()
	{
        /****************这一种无法实现撤销的功能*******************/
        _variable.intValue = EditorGUILayout.IntField("Int", _variable.intValue);

        _variable.floatValue = EditorGUILayout.FloatField("Float", _variable.floatValue);

        _variable.boolValue = EditorGUILayout.Toggle("Bool", _variable.boolValue);

        _variable.direction = (Variable.Direction)EditorGUILayout.EnumPopup("Direction", _variable.direction);

        _variable.prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", _variable.prefab, typeof(GameObject), true);
        /*******************************************************/


        /****************这一种也可以实现撤销的功能*******************/
        //serializedObject.Update();

        //EditorGUILayout.PropertyField(_intValue);

        //EditorGUILayout.PropertyField(_floatValue);

        //EditorGUILayout.PropertyField(_boolValue);

        //EditorGUILayout.PropertyField(_direction);

        //EditorGUILayout.PropertyField(_prefab);

        //serializedObject.ApplyModifiedProperties();
        /*******************************************************/


        /****************这一种可以实现撤销的功能*******************/
        //EditorGUI.BeginChangeCheck();

        //int intValue = EditorGUILayout.IntField("Int", _variable.intValue);

        //float floatValue = EditorGUILayout.FloatField("Float", _variable.floatValue);

        //bool boolValue = EditorGUILayout.Toggle("Bool", _variable.boolValue);

        //Variable.Direction direction = (Variable.Direction)EditorGUILayout.EnumPopup("Direction", _variable.direction);

        //GameObject prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", _variable.prefab, typeof(GameObject), true);

        //if (EditorGUI.EndChangeCheck())
        //{
        //    Undo.RegisterCompleteObjectUndo(_variable, "Change variable");

        //    _variable.intValue = intValue;

        //    _variable.floatValue = floatValue;

        //    _variable.boolValue = boolValue;

        //    _variable.direction = direction;

        //    _variable.prefab = prefab;
        //}
        /****************************************/
    }
}
