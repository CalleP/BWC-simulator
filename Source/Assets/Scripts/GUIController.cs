using UnityEngine;
using System.Collections;

//This class handles the gui
public class GUIController : MonoBehaviour
{

    public static string ConnectionStatus = "No connection";
    public static string CommandString = "no commands";

    void Update()
    {
        string commandString2 = "";
        
        //Iterates through the commands that have been sent to the server and displays it on the GUI
        for (int i = WebServer.List.Count - 1; i > WebServer.List.Count - 30; i--)
        {
            if (i >= 0) commandString2 = commandString2 + WebServer.List[i] + "\n";
        }

        CommandString = commandString2;
    }

    void OnGUI()
    {
        //Displays text labels on the screen for user feedback
        GUI.Label(new Rect(0, 20, Screen.width, Screen.height), ConnectionStatus);
        GUI.Label(new Rect(0, 40, Screen.width, Screen.height), CommandString);
    }
}
