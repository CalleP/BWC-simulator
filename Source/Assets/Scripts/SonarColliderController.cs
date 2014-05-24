using UnityEngine;
using System.Collections;

public class SonarColliderController : MonoBehaviour {

    private ParticleSystem particleSystem;
    private float timer = 0;
    private Vector3 originalScale;

	void Start () {
        particleSystem = (ParticleSystem)transform.parent.GetComponent("ParticleSystem");
        timer = Time.time + 1.15f;
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!(timer <= Time.time) && particleSystem.isPlaying)
	    {
            transform.localScale = new Vector3(
            transform.localScale.x + (0.023f * 0.95f),
            transform.localScale.y + (0.076f * 0.95f),
            0f);
	    }

        else if(particleSystem.isStopped)
        {
            timer = Time.time + 1.15f;
            transform.localScale = originalScale;
            
            Debug.Log("Response");
            //transform.localScale = transform.localScale - new Vector3(0, 3f, 0);
        }


    }


    void OnCollisionEnter2D(Collision2D col)
    {
        


    }
}
