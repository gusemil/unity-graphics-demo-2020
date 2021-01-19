using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject frostEffectPreFab;

    private List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();
    private Vector3 offset;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle collided!");

        ParticlePhysicsExtensions.GetCollisionEvents(particles, other, particleCollisionEvents);

        for(int i=0; i < particleCollisionEvents.Count; i++)
        {
            SpawnEffect(particleCollisionEvents[i]);
        }
    }

    private void SpawnEffect(ParticleCollisionEvent collision)
    {
        GameObject effect = Instantiate(frostEffectPreFab);
        effect.transform.position = collision.intersection;
        effect.transform.forward = collision.normal * 1f;
    }

}
