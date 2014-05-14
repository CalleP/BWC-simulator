using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;





public class ClientServerTest : MonoBehaviour {
    public string address = "ws://127.0.0.1:8934";
	// Use this for initialization
    WebSocketServer server;

	List<string> queue = new List<string>();
	PlayerControls other;
	int frameCount = 0;
	float mainCurrentTime = Time.time;

	void Start () {



       
 
        
        
        var server = new WebSocketServer(80);
        server.KeepClean = false;
        server.AddWebSocketService<WebServer>("/Simulator");
        server.Start();
       
        
		//server = new Server();
        //server = new WebServer();
		Debug.Log("Stack constructed");
		GameObject go = gameObject;
	    other = (PlayerControls) go.GetComponent(typeof(PlayerControls));
		//,new WebtestClient("80");
        

        
        //new testclient


	}
	int forwardCount = 0;
	int backwardsCount = 0;


	private float timer = 0.4f;
	private string previousCommand = "none"; 

	private int previousListSize = 0;

	//server controls this variable
	public static float timeOfLastCommand;
	// Update is called once per frame
	void Update () {


		if (WebServer.list.Count != 0) 
		{
			string command = WebServer.list[WebServer.list.Count-1];


			if(command == "forward" && timeOfLastCommand > Time.time)
			{
				other.Forward();
				other.Forward();
			}
			if(command == "back" && timeOfLastCommand > Time.time)
			{
				other.Backward();
				other.Backward();
			}
			if(command == "left" && timeOfLastCommand > Time.time)
			{
				other.Left();
			}
			if(command == "right" && timeOfLastCommand > Time.time)
			{
				other.Right();
			}
            if (command == "exit" && server != null)
            {
                Debug.Log("server stoppping");
                
            }

			Debug.Log("listCount"+ WebServer.list.Count.ToString());
			if(previousListSize != WebServer.list.Count)
			{
				timeOfLastCommand = Time.time+0.3f; 
			}
			previousListSize = WebServer.list.Count;

		}
	}

}
