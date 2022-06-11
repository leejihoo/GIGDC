using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHairBall : MonoBehaviour
{
    int a;
    public CatHairBall()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        var particleSystem = gameObject.GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        var particleSystem = gameObject.GetComponent<ParticleSystem>();
        ParticleSystem.Particle[] particle = new ParticleSystem.Particle[particleSystem.main.maxParticles];

        a = particleSystem.GetParticles(particle);
        
        
    }
}
