using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;


//This class instantiates the server and translates the commands it's recieving into movement for the car.
public class ServerHandler : MonoBehaviour
{

    public int Port = 80;
    private int previousListSize = 0;
    public static float TimeOfLastCommand;

    private WebSocketServer server;
    private PlayerControls playerController;

    void Start()
    {
        server = new WebSocketServer(Port);
        server.KeepClean = false;
        server.AddWebSocketService<WebServer>("/Simulator");
        server.Start();

        GameObject go = gameObject;
        playerController = (PlayerControls)go.GetComponent(typeof(PlayerControls));

        //Uncomment if you want to construct a debug class that sends commands to the server
        //var testClient = new WebtestClient("80");
        //testClient.delayedMessage("forward", 1000);
    }



    void Update()
    {
        //Checks the server for the latest command and performs that command for a specified time until a new command is given.
        if (WebServer.List.Count != 0)
        {
            string command = WebServer.List[WebServer.List.Count - 1];

            if (command == "forward" && TimeOfLastCommand > Time.time)
            {
                playerController.Forward();
                playerController.Forward();
            }

            if (command == "back" && TimeOfLastCommand > Time.time)
            {
                playerController.Backward();
                playerController.Backward();
            }

            if (command == "left" && TimeOfLastCommand > Time.time)
            {
                playerController.Left();
            }

            if (command == "right" && TimeOfLastCommand > Time.time)
            {
                playerController.Right();
            }

            if (command == "exit" && server != null)
            {
                Debug.Log("server stoppping");
            }

            if (previousListSize != WebServer.List.Count)
            {
                TimeOfLastCommand = Time.time + 0.3f;
            }

            previousListSize = WebServer.List.Count;
        }
    }

    void OnApplicationQuit()
    {
        server.Stop();
        Debug.Log("server stopped");
    }
}
