using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using UnityEngine;

using System.Collections.Generic;

using WebSocketSharp;
using WebSocketSharp.Server;

 class WebtestClient
{

     WebSocket client;
	public WebtestClient(string port)
	{

        client = new WebSocket(@"ws://127.0.0.1:"+port+"/Simulator");
        client.Connect();
        client.OnError += (sender, e) =>
              Debug.Log("error: "+e.Message.ToString());


        client.OnClose += (sender, e) =>
            Debug.Log("client on closing");
		
		//client.Connect();





        delayedMessage("forward", 100);
        
		
		

		//clientStream.Flush();
	}

	public void delayedMessage(string command, int delay)
	{
		var t = new Thread(() => realDelayMessage(command, delay));
		t.Start();
	}

	public void realDelayMessage(string command, int delay)
	{
            System.Threading.Thread.Sleep(delay);
            Debug.Log("delayed Message!");
            client.Send(command);
            if (command == "exit") { client.Close(); Debug.Log("client closing"); }
        
            
	}

     

    


	
}
