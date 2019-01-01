using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor( typeof( EnemyList ) )]
public class EnemyListEditor : Editor
{
	private EnemyList _enemyList { get { return target as EnemyList; } }

	private void OnEnable()
	{
		if( _enemyList.enemies == null )
		{
			_enemyList.enemies = new List<EnemyList.Enemy>();
			_enemyList.showEnemiesFoldout = new List<bool>();
		}	
	}

	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();
		GUI.color = _enemyList.backGroundColor;
		EditorGUILayout.BeginVertical( "box" );
		GUI.color = Color.white;

		DrawSettingData();

		EditorGUILayout.Space();

		GUIStyle style = new GUIStyle( EditorStyles.boldLabel );
		style.normal.textColor = Color.white;
		EditorGUILayout.LabelField( "Enemies", style );
		for( int i = 0; i < _enemyList.enemies.Count; i++ )
		{
			EditorGUILayout.BeginVertical( "box" );
			_enemyList.showEnemiesFoldout[i] = EditorGUILayout.Foldout( _enemyList.showEnemiesFoldout[i], ( "Enemy" + ( i + 1 ).ToString() ) );
			if( _enemyList.showEnemiesFoldout[i] )
			{
				EnemyList.Enemy enemy = _enemyList.enemies[i];
				enemy.hp = EditorGUILayout.IntSlider( "HP", enemy.hp, _enemyList.minValue, _enemyList.maxValue );
				enemy.atk = EditorGUILayout.IntSlider( "ATK", enemy.atk, _enemyList.minValue, _enemyList.maxValue );
				enemy.def = EditorGUILayout.IntSlider( "DEF", enemy.def, _enemyList.minValue, _enemyList.maxValue );
				DrawProgessBar( enemy.hp, "HP" + enemy.hp );
				DrawProgessBar( enemy.atk, "ATK" + enemy.atk );
				DrawProgessBar( enemy.def, "DEF" + enemy.def );

				GUI.color = _enemyList.buttonColor;
				if( GUILayout.Button( "Remove" ) )
				{
					_enemyList.enemies.Remove( enemy );
					_enemyList.showEnemiesFoldout.RemoveAt( i );
				}
				GUI.color = Color.white;
			}
			EditorGUILayout.EndVertical();
		}

		GUI.color = _enemyList.buttonColor;
		if( GUILayout.Button( "Add A Enemy" ) )
		{
			_enemyList.enemies.Add( new EnemyList.Enemy() );
			_enemyList.showEnemiesFoldout.Add( true );
		}
		GUI.color = Color.white;

		GUILayout.EndVertical();

		if( EditorGUI.EndChangeCheck() )
		{
			Undo.RegisterCompleteObjectUndo( _enemyList ,"Change enemyList setting");
			EditorUtility.SetDirty(_enemyList);
		}
	}

	private void DrawSettingData()
	{
		GUIStyle style = new GUIStyle( EditorStyles.boldLabel );
		style.normal.textColor = Color.white;
		EditorGUILayout.LabelField( "Setting", style);

		EditorGUILayout.BeginVertical( "box" );
		GUILayout.BeginHorizontal();
		_enemyList.maxValue = EditorGUILayout.IntField( "MaxValue", _enemyList.maxValue );
		EditorGUILayout.LabelField( "Color", GUILayout.MaxWidth(50 ) );
		_enemyList.maxValueColor = EditorGUILayout.ColorField( _enemyList.maxValueColor );
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		_enemyList.minValue = EditorGUILayout.IntField( "MinValue", _enemyList.minValue );
		EditorGUILayout.LabelField( "Color", GUILayout.MaxWidth( 80 ) );
		_enemyList.minValueColor = EditorGUILayout.ColorField( _enemyList.minValueColor );
		GUILayout.EndHorizontal();

		_enemyList.backGroundColor = EditorGUILayout.ColorField( "BgColor", _enemyList.backGroundColor );
		_enemyList.buttonColor = EditorGUILayout.ColorField( "ButtonColor", _enemyList.buttonColor );
		EditorGUILayout.EndVertical();
	}

	private void DrawProgessBar( float value, string text )
	{
		float normalizeValue = ( value - _enemyList.minValue ) / ( _enemyList.maxValue - _enemyList.minValue );

		float average = ( _enemyList.maxValue - _enemyList.minValue ) / 2;
        if (value > average)
        {
            float delta = (value - average) / average;
            GUI.backgroundColor = new Color(delta, 1 - delta, 0, 1f);
        }
        else
        {
            float delta = (average - value) / average;
            GUI.backgroundColor = new Color(delta, 1-delta, delta, 1f);
        }

        //Color maxColor = _enemyList.maxValueColor;
        //Color minColor = _enemyList.minValueColor;

        //float r = Mathf.Lerp(minColor.r, maxColor.r, normalizeValue);
        //float g = Mathf.Lerp(minColor.g, maxColor.g, normalizeValue);
        //float b = Mathf.Lerp(minColor.b, maxColor.b, normalizeValue);

        //Color color = new Color(r, g, b, 1f);

        Rect rect = GUILayoutUtility.GetRect(50, 20);
		EditorGUI.ProgressBar( rect, normalizeValue, text );
		GUI.backgroundColor = Color.white;
	}
}

