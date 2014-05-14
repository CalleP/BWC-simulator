using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using UnityEngine;



using System.Collections.Generic;

 class testClient
{
	TcpClient client;
	public testClient()
	{
		client = new TcpClient();
		
		IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8934);
		
		client.Connect(serverEndPoint);
		
	
		
	

	
		delayedMessage ("forward", 1000);

		delayedMessage ("back", 1800);

		
		

		//clientStream.Flush();
	}

	public void delayedMessage(string command, int delay)
	{
		var t = new Thread(() => realDelayMessage(command, delay));
		t.Start();
	}

	public void realDelayMessage(string command, int delay)
	{
		System.Threading.Thread.Sleep (delay);
		byte[] buffer = new ASCIIEncoding().GetBytes(command);
		Debug.Log("delayed Message!");
		
		NetworkStream clientStream = client.GetStream();
		clientStream.Write(buffer, 0 , buffer.Length);
		clientStream.Flush ();
	}

	
}
