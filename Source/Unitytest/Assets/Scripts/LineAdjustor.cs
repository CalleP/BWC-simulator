using UnityEngine;
using System.Collections;

public class LineAdjustor : MonoBehaviour
{

    // Use this for initialization




    CapsuleCollider capsule;


    LineRenderer lineRenderer;

    public Vector3 oldMousePos;
    public bool adjusting = true;
    public bool finished = false;

    BoxCollider2D Collider;
    void Start()
    {
        lineRenderer = (LineRenderer)GetComponent("LineRenderer");
        oldMousePos = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition)).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
        lineRenderer.SetPosition(1, oldMousePos);
        lineRenderer.renderer.enabled = false;
        lineRenderer.material.SetColor(0, Color.green);
        //Collider = (BoxCollider2D)GetComponent("BoxCollider2D");

    }

    // Update is called once per frame

    BoxCollider2D collider;
    void Update()
    {
        //Debug.Log(adjusting.ToString());
        //Debug.Log("finished"+finished.ToString());
        //Debug.Log("settingspos");
        var newMousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
        if (adjusting)
        {

            
            lineRenderer.SetPosition(0, newMousePos);
            lineRenderer.renderer.enabled = true;
            



            //RaycastHit hit;
            //if (Physics.Raycast(oldMousePos, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f) - oldMousePos, out hit))
            //{
            //    switch (hit.transform.gameObject.name)
            //    {
            //        case "Waller":
            //            //hit.rigidbody.
            //            //Output message

            //            break;
            //    }
            //}

        }

        //transform.FindChild("Collider").transform.localPosition = transform.position;
        if (finished && transform.FindChild("Collider").GetComponent("BoxCollider2D") == null)
        {


            var collider = (BoxCollider2D)transform.FindChild("Collider").gameObject.AddComponent("BoxCollider2D");
            //  collider.size = new Vector2(Vector2.Distance(oldMousePos, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f)), 1);

        }

        if (transform.FindChild("Collider").GetComponent("BoxCollider2D") != null)
        {
            if (finished && GetComponent("BoxCollider2D") == null)
            {
                
                var collider = (BoxCollider2D)gameObject.AddComponent("BoxCollider2D");
                collider.enabled = false;
                collider.size = new Vector2((Vector3.Distance(
                oldMousePos, newMousePos)),
                1);
                var collider2 = (BoxCollider2D)transform.FindChild("Collider").GetComponent("BoxCollider2D");
                collider2.size = collider.size;
                collider2.transform.position = new Vector3(collider.center.x, collider.center.y);

                var dir = newMousePos - collider2.transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                collider2.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                 
            }
            else if (GetComponent("BoxCollider2D") != null && finished)
            {
            }
        }
    }
}