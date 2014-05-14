using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;
 


public class WebServer : WebSocketService{


    
	// Use this for initialization

    static WebSocketServer aServer;
    public static List<string> list = new List<string>();
	public WebServer () {
        Debug.Log("webserver created");
       
	}

    protected override void OnOpen()
    {

        GUIController.connectionStatus = "Client Connected";
        
        
    }
    protected override void OnError(ErrorEventArgs e)
    {
        Debug.Log("server error: " + e.ToString());
        Debug.Log("server error: "+e.Message);
    }
    protected override void OnMessage(MessageEventArgs e)
    {
        
        GUIController.connectionStatus = "Message recieved";
        var msg = e.Data;
        list.Add(msg);
        Debug.Log(msg);
        Send("Input next command:");
        
    }
    protected override void OnClose(CloseEventArgs e)
    {
        Debug.Log(e.Reason);
        GUIController.connectionStatus = "Client Disconnected";
        base.OnClose(e);
    }
    

 
}


