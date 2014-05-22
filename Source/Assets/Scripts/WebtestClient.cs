using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using UnityEngine;

using System.Collections.Generic;

using WebSocketSharp;
using WebSocketSharp.Server;

//A class for debugging the server, it sends commands to the server on given timings
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
	}

    //delay is in milliseconds
	public void delayedMessage(string command, int delay)
	{
		var t = new Thread(() => realDelayMessage(command, delay));
		t.Start();
	}

	private void realDelayMessage(string command, int delay)
	{
            System.Threading.Thread.Sleep(delay);
            client.Send(command);
            if (command == "exit") { client.Close(); Debug.Log("client closing"); }           
	}
}
