using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Rigidbody2D projectilePrefab;
	public float attackSpeed = 0.5f;
	float cooldown;

	// Use this for initialization
	void Start () {
		//if(Time.time >= cooldown){
			if(Input.GetKey(KeyCode.Space)){
				Fire();
			}
		//}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fire(){

		Rigidbody2D prefabProj = Instantiate (projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
		prefabProj.AddForce (new Vector3 (50f, 50f, 50f));
	}
}	
	
