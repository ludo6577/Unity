using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour {
	
	public CharacterMotor motor;
	public Camera playerCamera;
	public int waterHeight = 104;
	
	public AnimationCurve fieldOfView;
	public AnimationCurve gravity;
	public AnimationCurve velocity;
	
	private float timeFieldOfView = 0.01f;
	private float timeGravity = 0.01f;
	private float timeVelocity = 0.01f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		bool isUnderWater = playerCamera.transform.position.y < waterHeight;
		
		//UnderWater
		if (isUnderWater) 
		{
			//FieldOfView
			float maxTime = fieldOfView.keys [fieldOfView.length - 1].time;
			if(timeFieldOfView < maxTime){
				playerCamera.fieldOfView = fieldOfView.Evaluate (timeFieldOfView);
				timeFieldOfView += Time.deltaTime;
			}
			//Gravity
			maxTime = gravity.keys [gravity.length - 1].time;
			if (timeGravity < maxTime) 
			{
				//motor.movement.gravity = gravity.Evaluate (timeGravity);
				Physics.gravity = new Vector3(0f, gravity.Evaluate (timeGravity), 0f);
				timeGravity += Time.deltaTime;
			}
			//Velocity
			maxTime = velocity.keys [velocity.length - 1].time;
			if (timeVelocity < maxTime) 
			{
				motor.movement.velocity.y = velocity.Evaluate (timeVelocity);
				timeVelocity += Time.deltaTime;
			}
			else{
				timeVelocity = 0;
				motor.movement.velocity.y = velocity.Evaluate (timeVelocity);
			}
		}
		//Get back to Normal Values
		else {
			
			//FieldOfView
			if(timeFieldOfView>0){
				timeFieldOfView -= Time.deltaTime;
				if(timeFieldOfView<0)
					timeFieldOfView=0;
				playerCamera.fieldOfView = fieldOfView.Evaluate (timeFieldOfView);	
			}			
			//Gravity
			if(timeGravity>0){
				timeGravity -= Time.deltaTime;
				if(timeGravity<0)
					timeGravity=0;
				motor.movement.gravity = gravity.Evaluate (timeGravity);	
			}
			//Velocity
			if(timeVelocity>0){
				timeVelocity -= Time.deltaTime;
				if(timeVelocity<0)
					timeVelocity=0;
				motor.movement.velocity.y = velocity.Evaluate (timeVelocity);	
			}
			
		}
	}	
}
