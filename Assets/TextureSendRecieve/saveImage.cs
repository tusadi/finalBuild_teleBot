using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveImage : MonoBehaviour {

	public int resWidth = 640, resHeight = 480;

	void Start(){
		StartCoroutine (ss ());
	}
		
	IEnumerator ss(){
		while (true) {
			RenderTexture rt = new RenderTexture (resWidth, resHeight, 24);
			Camera.main.targetTexture = rt; 
			Texture2D screenShot = new Texture2D (resWidth, resHeight, TextureFormat.RGB24, false);
			Camera.main.Render ();
			RenderTexture.active = rt;
			screenShot.ReadPixels (new Rect (0, 0, resWidth, resHeight), 0, 0);
			Camera.main.targetTexture = null;
			RenderTexture.active = null; // JC: added to avoid errors
			Destroy (rt);
			byte[] bytes = screenShot.EncodeToPNG ();
			string filename = "screenshot.jpg";
			System.IO.File.WriteAllBytes (filename, bytes);
			Debug.Log (string.Format ("Took screenshot to: {0}", filename));

			yield return null;
		}
	}
}
