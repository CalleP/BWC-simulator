using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 playerPos = GameObject.Find("Player").transform.position;





		Quaternion playerRotation = GameObject.Find("topdownknight").transform.rotation;

		transform.position = playerPos;
		transform.rotation = playerRotation;

	}
}
