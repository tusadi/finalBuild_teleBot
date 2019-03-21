using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CameraRig : MonoBehaviour {
	public GameObject pole, platform; //pole = vertical axis, platoform = horizontal axis
	float  hz, vt;

	SteamVR_TrackedObject obj;

	public dataSender sender;
	// Use this for initialization
	void Start () {

		obj = GetComponent <SteamVR_TrackedObject> ();
	}

	// Update is called once per frame
	void Update () {

		//pole.transform.Rotate (Vector3.up * hz*Time.deltaTime*360);

	//	platform.transform.Rotate (Vector3.right*-vt*Time.deltaTime*360);

	//	pole.transform.RotateAround (gameObject.transform.position, Vector3.up, obj.transform.rotation.y);
	//	platform.transform.RotateAround (gameObject.transform.position, Vector3.left, Mathf.Clamp (obj.transform.rotation.x, -20, 20));

		int x= Mathf.RoundToInt(obj.transform.rotation.eulerAngles.x);
		int y = Mathf.RoundToInt(obj.transform.rotation.eulerAngles.y);

		if (x > 90) {
			x = 360 - x;
		} else {
			x = -x;
		}
		x = x + 90;

		if (y > 180) {
			y = 360 - y;
		}

		sender.x = x;
		sender.y = y;

		//Debug.Log(pole.transform.rotation)


	}
}
