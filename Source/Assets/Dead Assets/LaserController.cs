using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	// Use this for initialization
    public float rotationSpeed;
    //BoxCollider2D collider;
    bool isCollding = false;
	void Start () {
    //    collider = (BoxCollider2D)GetComponent("BoxCollider2D");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
        collider.transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
        if (isCollding) {
            transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
            collider.transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
            //Debug.Log("iscolliding");
        }
        

        isCollding = false;
	}

    //void OnCollisionEnter2D()
    //{
    //    isCollding = true;
    //}

    //void OnCollisionExit2D()
    //{
    //    isCollding = false;
    
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    isCollding = true;
    //    Debug.Log(other.GetInstanceID());
    //}
    //void OnTriggerExit2D(Collider2D other)
    //{
      
    //    Debug.Log(other.GetInstanceID());
    //    isCollding = false;
    //} 

    void OnTriggerStay2D(Collider2D other)
    {

        Debug.Log(other.GetInstanceID());
        isCollding = true;
    } 
}
