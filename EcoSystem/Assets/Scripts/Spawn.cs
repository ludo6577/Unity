﻿using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public int number;
	public GameObject entity;
	public float rangeX;
	public float rangeY;
	public float rangeZ;

	// Use this for initialization
	void Start () {
		GameObject parent = new GameObject ("Clones (" + number + ": " + entity.name + ") ");
		for (int i=0; i<number; i++) {
			float x = entity.transform.position.x + (Random.value-0.5f) * rangeX;
			float y = entity.transform.position.y + (Random.value-0.5f) * rangeY;
			float z = entity.transform.position.z + (Random.value-0.5f) * rangeZ;
			GameObject child = (GameObject)Object.Instantiate(entity, new Vector3(x, y , z), new Quaternion());
			child.transform.parent = parent.transform;
		}
	}

	private float center(float posBeg, float posEnd){
		return (posBeg + posEnd) / 2;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
