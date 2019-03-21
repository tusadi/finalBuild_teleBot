using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ArmRig : MonoBehaviour {

	public GameObject platform, arm;
	float hz, vt;
	Vector3 initialOrientation;

	public SteamVR_Action_Single thumbstickPos;
	public SteamVR_Action_Boolean grabGrip;
	SteamVR_TrackedObject obj;
	Vector3 temp;

	bool clampState;

	public dataSender sender;
	float f,g;
	// Use this for initialization
	void Start () {
		obj = GetComponent <SteamVR_TrackedObject> ();
	}


	void Update()
	{
		//hz = Input.GetAxis ("Horizontal_arrow");
		//vt = Input.GetAxis ("Vertical_arrow");

		//platform.transform.Rotate (Vector3.up * hz*Time.deltaTime*360);
		//arm.transform.Rotate (Vector3.right*vt*Time.deltaTime*360);


		if (thumbstickPos.GetAxis (SteamVR_Input_Sources.RightHand)==0) {
			initialOrientation = obj.transform.rotation.eulerAngles;
			//Debug.Log (initialOrientation);
			return;
		}

		clampState = grabGrip.GetState (SteamVR_Input_Sources.Any);

		if (clampState) {
			Debug.Log ("inside");
			sender.grip = 0;
		} else if (!clampState) {
			sender.grip = 100;
		}
 
		if (thumbstickPos.GetAxis (SteamVR_Input_Sources.RightHand)!=0) 
		{
			//joystick.setActiv
			//Debug.Log (thumbstickPos.GetAxis (SteamVR_Input_Sources.Any));
			Vector3 delta = initialOrientation - obj.transform.rotation.eulerAngles;
			//joystick.transform.rotation = Quaternion.Euler (delta - initialOrientation);
			//robot.transform.Translate (new Vector3(0, 0, (delta.x)/360)*Time.deltaTime);


			if (delta.x > 180) {
				platform.transform.Rotate (new Vector3 (0, (delta.x-360), 0) * Time.deltaTime);
				f = 360 - delta.x;
			} else {
				platform.transform.Rotate (new Vector3 (0, (delta.x), 0) * Time.deltaTime);
				f = delta.x;
			}

			Debug.Log (delta);

			if (delta.z > 180) {
				arm.transform.Rotate (new Vector3 (0, (delta.z-360), 0) * Time.deltaTime);
				g = delta.z - 360;

				//Debug.Log (180+delta.x);
			} else {
				arm.transform.Rotate (new Vector3 (0, (delta.z), 0) * Time.deltaTime);
				g = delta.z;
			}
		}
		//Debug.Log (joystick.transform.rotation.eulerAngles);

		sender.f = (int)f;
		sender.g = (int)g;
	}
}
