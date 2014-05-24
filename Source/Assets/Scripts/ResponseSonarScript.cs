using UnityEngine;
using System.Collections;

public class ResponseSonarScript : MonoBehaviour {

	// Use this for initialization
    private bool alreadyPlayed = false;
    void Start () {
        transform.LookAt(GameObject.Find("Player 1").transform);
        particleSystem.startSpeed = Vector3.Distance(GameObject.Find("Player 1").transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (!SonarController.response && !alreadyPlayed)
	    {
            particleSystem.Play();
            alreadyPlayed = true;
	    }

	}
}
