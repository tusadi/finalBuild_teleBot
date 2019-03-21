using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System.Threading;

public class dataSender : MonoBehaviour {

	public int x, y, a, b, f,g, grip; //x,y  head
						  //a, b  robot
						  //f,g arm

	private WebSocket ws;
	float time=0;

	void Start () {


		ws = new WebSocket("ws://localhost:10000/");
		time = System.DateTime.Now.Millisecond;

		ws.OnOpen += OnOpenHandler;
		//ws.OnMessage += OnMessageHandler;
		ws.OnClose += OnCloseHandler;

		ws.ConnectAsync(); 
	}
	private void OnOpenHandler(object sender, System.EventArgs e) {
		Debug.Log("WebSocket connected!");
		//Thread.Sleep(3000);
		ws.SendAsync("connected!", OnSendComplete);
	}
	private void OnCloseHandler(object sender, CloseEventArgs e) {
		Debug.Log("WebSocket closed with reason: " + e.Reason);
	}

	private void OnSendComplete(bool success) {
		//Debug.Log("Message sent successfully? " + success);
	}

	void Update(){
		string s= (x.ToString()+","+y.ToString()+","+f.ToString()+","+g.ToString()+","+grip.ToString());
		//Debug.Log(pole.transform.rotation);
//		Debug.Log(s);
		ws.SendAsync(s,OnSendComplete);
	}

}
