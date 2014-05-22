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

        else if (Input.GetKeyUp(KeyCode.Mouse0) && !firstClick)
        {
            firstClick = true;
            latestScript.Adjusting = false;
            latestScript.Finished = true;
            if (oldMousePos.Equals(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f)))
            {
                Destroy(latestClone);
                amountSpawned--;
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Destroy(GameObject.Find(amountSpawned.ToString()));
        }
    }
}
