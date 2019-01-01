using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( Layout ) )]
public class LayoutEditor : Editor
{
	private Layout _layout { get { return target as Layout; } }

	public override void OnInspectorGUI()
	{
		_layout.backGroundColor = EditorGUILayout.ColorField( "Color", _layout.backGroundColor );

		GUI.color = _layout.backGroundColor;
		EditorGUILayout.BeginHorizontal("box");
		GUI.color = Color.white;

		EditorGUILayout.LabelField( "Horizontal1", GUILayout.MaxWidth( 100 ) );
		EditorGUILayout.LabelField( "H2", GUILayout.MaxWidth( 30 ) );
		EditorGUILayout.LabelField( "H3", GUILayout.MaxWidth( 30 ) );

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginVertical("box");
		EditorGUILayout.LabelField( "Vertical1" );
		EditorGUILayout.LabelField( "V2" );
		EditorGUILayout.LabelField( "V3" );

		EditorGUILayout.EndVertical();

		_layout.isShow = EditorGUILayout.Foldout( _layout.isShow, "Foldout" );
		if( _layout.isShow )
		{
			_layout.percent = EditorGUILayout.Slider( "Percent", _layout.percent, 1, 100 );
			GUILayout.Button( "Button" );
		}
	}

}
