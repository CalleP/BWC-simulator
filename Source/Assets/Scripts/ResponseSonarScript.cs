using UnityEngine;
using System.Collections;

public class ResponseSonarScript : MonoBehaviour {

	// Use this for initialization
    public static float latestDistance = 0f;
    private bool alreadyPlayed = false;
    private float sonarCD;
    void Start () {
        transform.LookAt(GameObject.Find("Player 1").transform);

        latestDistance = Vector3.Distance(GameObject.Find("Player 1").transform.position, transform.position);
        particleSystem.startSpeed = latestDistance-1.3f;
        sonarCD = Time.time + 1f;
	}


	// Update is called once per frame
	void Update () {

        if (sonarCD <= Time.time && !alreadyPlayed)
	    {
            SonarController.response = false;
            particleSystem.Play();
            alreadyPlayed = true;
	    }

	}
}
