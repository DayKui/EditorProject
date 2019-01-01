using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyList : MonoBehaviour
{
	[System.Serializable]
	public class Enemy
	{
		public int hp { get; set; }

		public int atk { get; set; }

		public int def { get; set; }
	}


	public List<Enemy> enemies;

	public List<bool> showEnemiesFoldout;

	public int maxValue = 100;

	public int minValue = 0;

	public Color minValueColor;

	public Color maxValueColor;

	public Color backGroundColor;

	public Color buttonColor;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
