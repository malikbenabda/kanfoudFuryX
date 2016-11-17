using UnityEngine;
using System.Collections;

public class destroywhenCollided : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.transform.GetComponent<Rigidbody2D> ().AddForce 
	//	(gameObject.transform.InverseTransformDirection(gameObject.transform.loca)* 555f, ForceMode2D.Impulse);

		Destroy (gameObject, 2.5f);

	}
	


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (!coll.gameObject.tag.Equals ("needles") && !coll.gameObject.tag.Equals ("9anfoud"))
		Destroy (gameObject,0.1f);


	}




}
