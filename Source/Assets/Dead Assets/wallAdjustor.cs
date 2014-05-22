using UnityEngine;
using System.Collections;

public class wallAdjustor : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {
        oldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        spriteRenderer = (SpriteRenderer)GetComponent("SpriteRenderer");


    }

    public Vector2 pointA;
    public Vector2 pointB;
    Vector3 oldPosition;
    public bool rotateable = true;
    public bool once = true;

    SpriteRenderer spriteRenderer;



    public bool updatePrevent = false;
    // Update is called once per frame
    void Update()
    {



        if (rotateable)
        {
            if (once)
            {
                OnceSetup();
                once = false;
            }
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);








            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
            pointB = mousePos;

            if (!updatePrevent)
            {

            }



            transform.localScale = new Vector3(transform.localScale.x, Vector2.Distance(pointA, pointB), transform.localScale.z);

            Vector3 temp = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z);
            transform.position = oldPosition;
            oldPosition = temp;


            //transform.position = Directional vector * height/2;
            transform.position = (transform.position.normalized * renderer.bounds.size.y / 2);

        }

    }

    void OnceSetup()
    {
        // pointA = pointA + pointA;
    }


    void OnGUI()
    {

        GUI.Label(new Rect(0, 20, Screen.width, Screen.height), "oldpos " + oldPosition.ToString());
        GUI.Label(new Rect(0, 40, Screen.width, Screen.height), "currentpos " + transform.position.ToString());



    }
}
