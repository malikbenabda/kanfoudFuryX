using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
    public float speed=3f;
    GameObject[] knafed;
	AudioSource audio1,audio2;
	// Use this for initialization
	void Start () {
		AudioSource[] X =GetComponents<AudioSource> ();
		audio1 = X [0]; 
		audio2 = X [1] ;
	}
	
	// Update is called once per frame
	void Update () {
        
        knafed = GameObject.FindGameObjectsWithTag("9anfoud");

        if (knafed[0].transform.position.x > gameObject.transform.position.x)
        {
            Quaternion reverse = transform.rotation;
            reverse.y = 180f;
		
           
           transform.rotation = reverse;
        }
        else
        {
            Quaternion reverse = transform.rotation;
            reverse.y = 0f;
            transform.rotation = reverse;
        }



        transform.position = Vector3.MoveTowards(transform.position, knafed[0].transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
		
        if (coll.gameObject.tag == "9anfoud") {
            coll.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			audio1.Play ();
			coll.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

			Destroy(coll.gameObject, 0.5f);
			transform.GetChild (0).gameObject.SetActive (true);
			Destroy(gameObject,0.5f);

         

        }
         
		if ( coll.gameObject.tag=="needles") {
			transform.GetChild (0).gameObject.SetActive (true);
			audio2.Play ();	
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

			Destroy(gameObject,0.5f);
		}
	}






}
