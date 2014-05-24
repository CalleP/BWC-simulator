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
        foreach (var obstacle in obstacles)
        {
            int count = 0;
            foreach (var particle in particles)
            {
                
                //var collider = (PolygonCollider2D)GameObject.Find("sonarColliderAux").GetComponent("PolygonCollider2D");

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
            

        }
        
        string test = "";
        // foreach (var item in newParticles)
        //{
        //    test += item.lifetime.ToString();

        //}
         Debug.Log(setParticles.ToString());

        if(setParticles)particleSystem.SetParticles(newParticles, 3000);
	}
    
    private static ParticleSystem.Particle[] GetInterval(ParticleSystem.Particle[] particles, int first, int last)
    {
        ParticleSystem.Particle[] returnedParticles = new ParticleSystem.Particle[(last-first)+1];
        int count = 0;

        foreach (var item in particles)
        {
            if (count >= first && count <= last)
            {
                returnedParticles[count] = item;
            }

            count++;
        }



        return returnedParticles;
    }
    
}
