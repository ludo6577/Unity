using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CameraJoystickRight: MonoBehaviour
{
    public CNJoystick joystick;
    public float rotateSpeed = 6f;
	public bool actionned = false;

    private CharacterController characterController;
    private Camera mainCamera;
	private Vector3 totalRotate;

    // This variable is only valuable if you're using Mouse as input
    // if you use only Touch input, feel free to remove this variable
    // and it's usage from this code
    private bool tweakedLastFrame;

    void Awake()
    {
        joystick.JoystickMovedEvent += JoystickMovedEventHandler;
        joystick.FingerLiftedEvent += StopMoving;
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        totalRotate = Vector3.zero;
        tweakedLastFrame = false;
    }

    /** 
     * This function is called when player lifts his finger
     */
    private void StopMoving()
    {
		totalRotate = Vector3.zero;
		actionned = false;
    }

    void Update()
    {
		if(!tweakedLastFrame)
		{
			totalRotate = Vector3.zero;
			actionned = false;
		}

		characterController.transform.Rotate(new Vector3(0f, totalRotate.y, 0f));
		mainCamera.transform.Rotate(new Vector3(totalRotate.x, 0f, 0f));
		//On est aller trop haut ou trop bas
		if (mainCamera.transform.rotation.x < -0.5f || mainCamera.transform.rotation.x > 0.5f)
			mainCamera.transform.Rotate (new Vector3(-totalRotate.x, 0f, 0f));
        tweakedLastFrame = false;
    }

    private void JoystickMovedEventHandler(Vector3 dragVector)
    {
		actionned = true;
		totalRotate.x = -dragVector.y * rotateSpeed;
		totalRotate.y = dragVector.x * rotateSpeed;
        tweakedLastFrame = true;
    }
}
