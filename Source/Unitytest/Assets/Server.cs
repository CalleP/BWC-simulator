using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

using System.Collections.Generic;
using UnityEngine;


	class Server
	{
		private TcpListener tcpListener;
		private Thread listenThread;
		public List<string> list = new List<string>();
		
		public Server()
		{

		this.tcpListener = new TcpListener(IPAddress.Any, 8934);
			this.listenThread = new Thread(new ThreadStart(ListenForClients));
			this.listenThread.Start();
			
		}
		private void ListenForClients()
		{
			this.tcpListener.Start();
			
			while (true)
			{
				//blocks until a client has connected to the server
				TcpClient client = this.tcpListener.AcceptTcpClient();
				
				//create a thread to handle communication 
				//with connected client
				Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
				clientThread.Start(client);
			}
		}

		private void HandleClientComm(object client)
		{
			TcpClient tcpClient = (TcpClient)client;
			NetworkStream clientStream = tcpClient.GetStream();
			
			byte[] message = new byte[4096];
			int bytesRead;
			
			while (true)
			{
				bytesRead = 0;
				
				try
				{
					Debug.Log("waiting for message: "+message);
					//blocks until a client sends a message
					bytesRead = clientStream.Read(message, 0, 4096);
					Debug.Log("Messagggee: "+message);
					
				}
				catch
				{
				Debug.Log("Debug: socket errror has occured");
			
			//a socket error has occured
					break;
				}
				
				if (bytesRead == 0)
				{
				Debug.Log("Debug: client has disconnected");
					//the client has disconnected from the server
					break;
				}
				
				//message has successfully been received
				
				ASCIIEncoding encoder = new ASCIIEncoding();
				Debug.Log("Debug: " + encoder.GetString(message, 0, bytesRead));
				System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));

			List<string> lillist = new List<string>{"right","forward","back","left","laser","speaker","rocket"};

			if(lillist.Contains(encoder.GetString(message, 0, bytesRead))) list.Add(encoder.GetString(message, 0, bytesRead));

				

				
			}
		Debug.Log("Debug: closing");
		clientStream.Close ();
		tcpClient.Close();
		tcpListener.Stop ();
		Debug.Log("Finished closing");	
		}
}
