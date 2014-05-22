using UnityEngine;
using System.Collections;

//This class spawns and controls parts of the LineAdjustor class to properly position and rotate the line through mouse input 
public class lineSpawner : MonoBehaviour
{

    private int amountSpawned = 0;
    private bool firstClick = true;
    private Vector3 oldMousePos;

    private LineAdjustor latestScript;
    private GameObject latestClone;

    void Start()
    {
        oldMousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
    }

    void Update()
    {
        //If the mouse is being held in it will scale the linerenderer between the clicked position and the current position of the mouse
        if (Input.GetKey(KeyCode.Mouse0) && firstClick)
        {
            firstClick = false;
            latestClone = (GameObject)Instantiate(Resources.Load("Waller"));
            latestScript = (LineAdjustor)latestClone.GetComponent("LineAdjustor");
            oldMousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
            latestScript.OldMousePos = oldMousePos;
            amountSpawned++;
            latestClone.name = amountSpawned.ToString();
        }

        //If the the button is released it will communicate with the WallAdjustor and cause it to construct its Collider amongst other things
        else if (Input.GetKeyUp(KeyCode.Mouse0) && !firstClick)
        {
            firstClick = true;
            latestScript.Adjusting = false;
            latestScript.Finished = true;
            
            //If the mouse is not dragged but just clicked it will delete the created object to prevent the creation of collision objects with very small sizes
            if (oldMousePos.Equals(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f)))
            {
                Destroy(latestClone);
                amountSpawned--;
            }
        }
        
        //Destroy the latest wall if the right mouse button is clicked
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Destroy(GameObject.Find(amountSpawned.ToString()));
        }
    }
}
