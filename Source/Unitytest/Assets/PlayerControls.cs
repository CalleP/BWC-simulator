using UnityEngine;
using System.Collections;



public class PlayerControls : MonoBehaviour {

	public float accelerationRate = 100f;
	public float deAccelerationRate = 100f;

	public float maxVelocity = 30f;
//	public float currentVelocity = 30f;

    private float currentVelocity;
    public float CurrentVelocity
    {
        get { return currentVelocity; }
        set { if(!colliding) currentVelocity = value; }
    }

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	private Vector2 direction;
	private bool rotating = false;

    

	float Speed;
	

	// Use this for initialization
	void Start () {
		moveUp = KeyCode.W;
		moveDown = KeyCode.S;
		moveLeft = KeyCode.A;
		moveRight = KeyCode.D;




	}
	
	// Update is called once per frame
	void Update () {
		direction = transform.up;

		rotating = false;



		transform.rotation = transform.rotation;
		if (Input.GetKey (moveLeft)) {
			Left();
		}
		if (Input.GetKey (moveRight)) {
			Right();
		}

	




		if (Input.GetKey (moveUp) && !rotating) 
		{

			Forward();

		} 
		else if (Input.GetKey (moveDown) && !rotating) 
		{

			Backward();

		} 
		else
		{	
			if(currentVelocity > -1 && currentVelocity < 1)	currentVelocity = 0;

			
			
			if(currentVelocity < 0) currentVelocity = currentVelocity + ((deAccelerationRate * Time.deltaTime));
			else if (currentVelocity > 0) currentVelocity = currentVelocity - ((deAccelerationRate * Time.deltaTime));
			
			
		}

		if (currentVelocity < maxVelocity * -1) currentVelocity = maxVelocity * -1;
		if (currentVelocity > maxVelocity) currentVelocity = maxVelocity;


        

	}
	void FixedUpdate(){
	
		rigidbody2D.AddForce (direction*(currentVelocity*10));



	}
	void OnGUI(){
		GUI.Label (new Rect (0, 0, Screen.width, Screen.height), currentVelocity.ToString()+"  "+(direction).ToString());
        
	}

	public void Forward()
	{
		if (!rotating) 
		{
			if(currentVelocity == 0) currentVelocity = accelerationRate/3;
			currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);	
		}

	}

	public void Backward()
	{
		if (!rotating) 
		{
			if(currentVelocity == 0) currentVelocity = (accelerationRate/3)*-1;
			currentVelocity = currentVelocity - (accelerationRate * Time.deltaTime);
		}
	}

	public void Left()
	{
		rotating = true;
		rigidbody2D.velocity = transform.forward * 0.1f;
		transform.Rotate (Vector3.forward * 1);
	}

	public void Right()
	{
		rotating = true;
		rigidbody2D.velocity = new Vector2 (0, 0);
		transform.Rotate (Vector3.forward * -1);
	}

	public void Forward(float duration){
		//var timer =- Time.deltaTime;

	}


    bool colliding = false;
    void OnCollisionEnter2D(Collision2D col)
    {
        colliding = true;
        currentVelocity = 0;

        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        colliding = false;
        
        
    }


}
