using UnityEngine;
using System.Collections;

//This class adjusts the line created by lineSpawner to scale and follow your mouse position
public class LineAdjustor : MonoBehaviour
{

    private CapsuleCollider capsule;
    private LineRenderer lineRenderer;

    public Vector3 OldMousePos;
    public bool Adjusting = true;
    public bool Finished = false;

    void Start()
    {
        lineRenderer = (LineRenderer)GetComponent("LineRenderer");
        OldMousePos = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition)).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
        lineRenderer.SetPosition(1, OldMousePos);
        lineRenderer.renderer.enabled = false;
        lineRenderer.material.SetColor(0, Color.green);
    }



    void Update()
    {
        
        var newMousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, 0f);
        if (Adjusting)
        {
            //Causes one of the positional vectors of the linerenderer to follow the current mouse position.
            lineRenderer.SetPosition(0, newMousePos);
            lineRenderer.renderer.enabled = true;
        }

        //Adds collision detection once the wall has been succesfully spawned
        if (Finished && transform.FindChild("Collider").GetComponent("BoxCollider2D") == null)
        {
            var collider = (BoxCollider2D)transform.FindChild("Collider").gameObject.AddComponent("BoxCollider2D");
        }

        //
        if (transform.FindChild("Collider").GetComponent("BoxCollider2D") != null)
        {
            if (Finished && GetComponent("BoxCollider2D") == null)
            {
                var collider = (BoxCollider2D)gameObject.AddComponent("BoxCollider2D");
                collider.enabled = false;
                
                //Causes the scale of the collider to be the same as the Lines
                collider.size = new Vector2((
                    Vector3.Distance(OldMousePos, newMousePos)),
                    1);
                    
                var collider2 = (BoxCollider2D)transform.FindChild("Collider").GetComponent("BoxCollider2D");
                collider2.size = collider.size;
                collider2.transform.position = new Vector3(collider.center.x, collider.center.y);
                
                //Rotates the collider to be parallel with the line
                var dir = newMousePos - collider2.transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                collider2.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}
