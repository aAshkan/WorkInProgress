using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class subParticleScript : MonoBehaviour {
    
    public ParticleSystem m_currentParticleEffect;
	public GameObject flyHere;
    Vector3 dir = Vector3.zero;
    Vector3 destination = Vector3.zero;

    void Start() {
		//Debug.Log(camPos);
		destination = flyHere.transform.position;
//		Debug.Log ("Destination: " + destination);
		destination.x += 1.0f;
		destination.y = 10.5f;
    }
	void Update() {
	}
    void LateUpdate() {
        //need to find the screen to world position of te progress bar
		destination += new Vector3(0.05f, 0, 0);

        ParticleSystem.Particle[] ParticleList = new ParticleSystem.Particle[m_currentParticleEffect.particleCount];
        m_currentParticleEffect.GetParticles(ParticleList);
        for (int i = 0; i < ParticleList.Length; ++i){
            //calculate the particles current position to destination -> vector dir
            dir = destination - ParticleList[i].position;

            //if the particle is already near/on the destination then dont bother editing position

            if(dir.magnitude > 0.02){
                //normalize dir and multiply it by .05f
                //dir.Normalize();
                dir *= 0.5f;

                //add dir to current pos of particles
                ParticleList[i].position += dir;
            }

        }

        //set the particles
        m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);
        
    }
}   
