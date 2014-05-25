using UnityEngine;
using System.Collections;
using System.Linq;

public class SonarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //transform.localScale = new Vector3(4f, 0, 50);
	}

    public static bool response;
	// Update is called once per frame
	void Update () {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[3000];

        var i = particleSystem.GetParticles(particles);

        var y = "FF";

        var newParticles = new ParticleSystem.Particle[particles.Length];

        var obstacles = GameObject.FindGameObjectsWithTag("obstacle");

        bool setParticles = false;
        int count = 0;
        foreach (var particle in particles)
        {
                
            var polyCollider = (PolygonCollider2D)GameObject.Find("sonarColliderAux").GetComponent("PolygonCollider2D");

            var colliders = Physics2D.OverlapPointAll(particle.position);


            newParticles[count] = particle;

            foreach (var collider in colliders)
	        {
		        if (collider.tag == "obstacle")
                {
                    if (!response)
                    {
                        response = true;
                        Instantiate(Resources.Load("ResponseSonar"), particle.position, Quaternion.identity);
                    }
                    var particle2 = particle;
                    particle2.lifetime = -1;
                    newParticles[count] = particle2;
                    setParticles = true;

                }
	        }



            count += 1;
        }


        if(setParticles)particleSystem.SetParticles(newParticles, 3000);

    }
        

}
    

    

