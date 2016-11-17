using UnityEngine;
using System.Collections;

public class particleColliderManager : MonoBehaviour {
	private ParticleSystem part;
	public ParticleCollisionEvent[] collisionEvents;
	//public GameObject deathCloud,sickCloud;

	// Use this for initialization
	void Start () {
		part = GetComponent<ParticleSystem>();
		collisionEvents = new ParticleCollisionEvent[16];

	}


	void OnParticleCollision(GameObject other) {


		int safeLength = part.GetSafeCollisionEventSize();
		if (collisionEvents.Length < safeLength)
			collisionEvents = new ParticleCollisionEvent[safeLength];

		int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
		Rigidbody rb = other.GetComponent<Rigidbody>();
		int i = 0;
		while (i < numCollisionEvents) {
			if (rb) {
				Vector3 pos = collisionEvents[i].intersection;
				Vector3 force = collisionEvents[i].velocity * 1000;
				rb.AddForce(force);
			}
			i++;
		}
	

		if (other.tag == "enemy") {
			other.transform.GetChild (0).gameObject.SetActive (true);
			Destroy (other,0.5f);
				}

	
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
