using UnityEngine;
using System.Collections;

public class lineSpawner : MonoBehaviour {

    
    bool firstClick = true;

    Vector3 oldMousePos;
    LineAdjustor latestScript;
    GameObject latestClone;
	// Use this for initialization
	void Start () {
        oldMousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
	}
	
	// Update is called once per frame
    
	void Update () {
        
        if(Input.GetKey(KeyCode.Mouse0) && firstClick)
        {
            
            firstClick = false;
            latestClone = (GameObject)Instantiate(Resources.Load("Waller"));
            latestScript = (LineAdjustor)latestClone.GetComponent("LineAdjustor");
            oldMousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
            latestScript.oldMousePos = oldMousePos;
           
            
            
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0) && !firstClick)
        {
            firstClick = true;
            latestScript.adjusting = false;
            Debug.Log("Adjusting");
            latestScript.finished = true;
            if (oldMousePos.Equals(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f)))
            {
                Destroy(latestClone);
            }
            
            
        }

	}
}
