using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WMRInput : MonoBehaviour
{
 
	public GameObject joystick;
	public GameObject robot;
	Vector3 initialOrientation;

	public SteamVR_Action_Single thumbstickPos;
	SteamVR_TrackedObject obj;
	Vector3 temp;
 

    /*
     * NOTE 
     * 
     * RIGHT HAND IS FOR SCALE 
     * LEFT HAND IS FOR TIME
     * 
     * */
	void Start(){
		obj = GetComponent <SteamVR_TrackedObject> ();
		//initialOrientation = obj.transform.rotation.eulerAngles;
	}
   

    // Update is called once per frame
    void Update()
    {
		if (thumbstickPos.GetAxis (SteamVR_Input_Sources.LeftHand)==0) {
			initialOrientation = obj.transform.rotation.eulerAngles;
			//Debug.Log (initialOrientation);
			return;
		}

		if (thumbstickPos.GetAxis (SteamVR_Input_Sources.LeftHand)!=0) 
		{
			//joystick.setActiv
			//Debug.Log (thumbstickPos.GetAxis (SteamVR_Input_Sources.Any));
			Vector3 delta = initialOrientation - obj.transform.rotation.eulerAngles;
			//joystick.transform.rotation = Quaternion.Euler (delta - initialOrientation);
			//robot.transform.Translate (new Vector3(0, 0, (delta.x)/360)*Time.deltaTime);


			if (delta.x > 180) {
				robot.transform.Translate (new Vector3(0, 0, (delta.x-360)/10)*Time.deltaTime);
				//Debug.Log (180+delta.x);
			} else {
				robot.transform.Translate (new Vector3(0, 0, (delta.x)/10)*Time.deltaTime);

			}

			Debug.Log (delta);

			if (delta.z > 180) {
				robot.transform.Rotate (new Vector3 (0, (delta.z-360), 0) * Time.deltaTime);
				//Debug.Log (180+delta.x);
			} else {
				robot.transform.Rotate (new Vector3 (0, (delta.z), 0) * Time.deltaTime);

			}
		}
		//Debug.Log (joystick.transform.rotation.eulerAngles);
    }
}
