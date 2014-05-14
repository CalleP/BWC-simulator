using UnityEngine;
using System.Collections;

public class wallSpawner : MonoBehaviour {


    bool secondClick;
    GameObject clone;
    wallAdjustor script;
	// Use this for initialization
	void Start () {
        clone = (GameObject)Instantiate(Resources.Load("LongWall"), new Vector3(3000,3000,0), Quaternion.identity);
        script = (wallAdjustor)clone.GetComponent("wallAdjustor");
	}
	
	// Update is called once per frame
	void Update () {

        
        spawnWall();
    }


    void spawnWall()
    {

            if (Input.GetMouseButtonDown(0))

            {
                if (!secondClick)
                {
                    var mousePos = Input.mousePosition;

                    mousePos.z = 10f;

                    var worldPos = camera.ScreenToWorldPoint(mousePos);

                    Debug.Log("Mouse pos: " + mousePos + "   World Pos: " + worldPos + "   Near Clip Plane: " + camera.nearClipPlane);

                    clone = (GameObject)Instantiate(Resources.Load("LongWall"), worldPos, Quaternion.identity);
                    secondClick = true;
                    var script = (wallAdjustor)clone.GetComponent("wallAdjustor");
                    script.pointA = worldPos;
                    
                }
                else 
                {
                    var script = (wallAdjustor)clone.GetComponent("wallAdjustor");
                    script.rotateable = false;
                    secondClick = false;
                }
            }
            else if (Input.GetMouseButtonDown(1) && !clone.Equals(null))
            {
                Destroy(clone);
                secondClick = false;
            }
    }
}

