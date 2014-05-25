using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

//Server utilizing the Websocket-sharp library
public class WebServer : WebSocketService
{

    public static List<string> List = new List<string>();

    public WebServer()
    {
        Debug.Log("webserver created");
    }

    protected override void OnOpen()
    {
        GUIController.ConnectionStatus = "Client Connected";
    }

    protected override void OnError(ErrorEventArgs e)
    {
        Debug.Log("server error: " + e.ToString());
        Debug.Log("server error: " + e.Message);
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        GUIController.ConnectionStatus = "Message recieved";
        var msg = e.Data;
        List.Add(msg);
        Debug.Log(msg);
        
        if (msg == "GetSonar")
        {
            delayedSonarMessage(1000);
        }

    }

    protected override void OnClose(CloseEventArgs e)
    {
        Debug.Log(e.Reason);
        GUIController.ConnectionStatus = "Client Disconnected";
        base.OnClose(e);
    }

    public void delayedSonarMessage(int delay)
    {
        var t = new Thread(() => realDelayMessage(delay));
        t.Start();
    }

    private void realDelayMessage(int delay)
    {
        Debug.Log("delayed");
        System.Threading.Thread.Sleep(delay);
        Send(ResponseSonarScript.latestDistance.ToString());
        
    }
}


