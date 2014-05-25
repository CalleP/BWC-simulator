using UnityEngine;
using System.Collections;

public class SonarColliderController : MonoBehaviour {

    private ParticleSystem particleSystem;
    private float timer = 0;
    private Vector3 originalScale;

	void Start () 
    {
        particleSystem = (ParticleSystem)transform.parent.GetComponent("ParticleSystem");
        timer = Time.time + 1.15f;
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(particleSystem.isStopped)
        {
            timer = Time.time + 1.15f;
            transform.localScale = originalScale;
        }
    }
}
