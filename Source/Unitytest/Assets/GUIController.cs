using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

    public static string connectionStatus = "No connection";
    public static string commandString = "no commands";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        string commandString2 = "";
        for (int i = WebServer.list.Count-1; i > WebServer.list.Count - 30; i--)
        {
            if (i >= 0) commandString2 = commandString2 + WebServer.list[i] + "\n";
        }
        //for (int i = 0; i < 10; i++)
        //{
            
        //    if (WebServer.list.Count > i) 
        //    Debug.Log(commandString2);
        //}
        commandString = commandString2;
        
	}



    void OnGUI()
    {
        GUI.Label(new Rect(0, 20, Screen.width, Screen.height), connectionStatus);
        GUI.Label(new Rect(0, 40, Screen.width, Screen.height), commandString);
      
            
        
    }
}
