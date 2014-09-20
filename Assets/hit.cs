using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {

	public GameObject weapon;

	public AnimationCurve curveX;
	public AnimationCurve curveY;
	public AnimationCurve curveZ;
	public float maxTime;

	private float index = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		index += Time.deltaTime;
		if (index > maxTime)
			index = 0;
		Vector3 vecPos = new Vector3 (curveX.Evaluate (index), curveY.Evaluate (index), curveZ.Evaluate (index));
		weapon.transform.localPosition = vecPos;
	}
}
