using UnityEngine;
using System.Collections;

public class hit2 : MonoBehaviour {

	public GameObject weapon;

	public AnimationCurve curveRotX;
	public AnimationCurve curveRotY;
	public AnimationCurve curveRotZ;
	public AnimationCurve curvePosX;
	public AnimationCurve curvePosY;
	public AnimationCurve curvePosZ;
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
		Vector3 vecRot = new Vector3 (curveRotX.Evaluate (index), curveRotY.Evaluate (index), curveRotZ.Evaluate (index));
		weapon.transform.localEulerAngles = vecRot;
		Vector3 vecPos = new Vector3 (curvePosX.Evaluate (index), curvePosY.Evaluate (index), curvePosZ.Evaluate (index));
		weapon.transform.localPosition = vecPos;
	}
}
