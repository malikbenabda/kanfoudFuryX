using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myNeddleThrower : MonoBehaviour {
	public GameObject needle;
public float speed;
	Vector2 direction;
	// Use this for initialization
	void Start () {
		

	}
		

	void Update(){
		if (Input.GetButtonDown ("Fire1")) {
		
			explode ();
		
		
		}
	
	
	
	
	}




	public void explode() {
		for (int angle = 0; angle < 80; angle+=10) {


			direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad));
			GameObject canon =(GameObject)  Instantiate (needle, transform.position, Quaternion.identity);
			canon.GetComponent<Rigidbody2D> ().AddForce (direction*speed, ForceMode2D.Impulse);
			Destroy (canon, 1.2f);
		}

	
	
	
	
	}

}
