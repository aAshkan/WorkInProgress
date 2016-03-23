using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]

public class ParticleMovement : MonoBehaviour
{
	ParticleSystem m_System;
	ParticleSystem.Particle[] m_Particles;
	public Vector2 target;
	public float speed;

	private void LateUpdate()
	{
		InitializeIfNeeded();

		// GetParticles is allocation free because we reuse the m_Particles buffer between updates
		int numParticlesAlive = m_System.GetParticles(m_Particles);

		// Change only the particles that are alive
		for (int i = 0; i < numParticlesAlive; i++)
		{
			m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, Camera.main.ViewportToWorldPoint(target), speed);
			if(Vector3.Distance(m_Particles[i].position, Camera.main.ViewportToWorldPoint(target)) == 0){
				m_Particles[i].lifetime = 0;
				ProgressBar.SetProgressBar(ProgressBar.barDisplay += (1.0f/120.0f));
			}
		}

		// Apply the particle changes to the particle system
		m_System.SetParticles(m_Particles, numParticlesAlive);

		if ((transform.position.x+5) <  Camera.main.ViewportToWorldPoint(new Vector2 (0, 0)).x){
		Destroy (gameObject);
		}
	}

	void InitializeIfNeeded()
	{
		if (m_System == null)
			m_System = GetComponent<ParticleSystem>();

		if (m_Particles == null || m_Particles.Length < m_System.maxParticles)
			m_Particles = new ParticleSystem.Particle[m_System.maxParticles]; 
	}
}