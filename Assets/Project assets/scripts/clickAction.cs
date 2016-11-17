using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class clickAction : MonoBehaviour {
	private GameObject cloud;
	AudioSource audio1;
	public GameObject needle;
	private  Vector3 v3;
    private Vector2 v2;
	private int cliks;
	private bool touched;
	public float speed;
	private bool moved;
	private GameObject selectedObject;
	private Ray ray;
	Touch mytoutch;
	//public Text mytext;
	// Use this for initialization
	void Start () {
	//	TT.text = "tap on the 9anfoud to destroy the sinister apples";
		selectedObject=null;

		touched = false;

	}
	
	void Update () 
	{
		

		if (Input.touchCount ==1)
		{
			mytoutch= Input.GetTouch(0);
			Vector3 pos = mytoutch.position;

			if (mytoutch.phase == TouchPhase.Began) 
			{
				 ray = Camera.main.ScreenPointToRay (pos);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
				if ((hit.collider.gameObject.Equals(gameObject)) )  {
 					// if selectedobject 9anfoud is null , excited 9anfoud 
					if (selectedObject == null) {
						selectedObject = hit.collider.gameObject;
						setTouched (true);
					} 
					else // selectedObject != null 
					{
						touched = getTouched ();
						if (touched) {
							
							selectedObject.transform.GetChild (0).gameObject.SetActive(true);

							explode (selectedObject.gameObject);
							selectedObject = null;	
							touched = false;
						}

					
					
					
					}



					// if a 9anfoud is already excited explose and destroy 


				
				} else if ( !hit.collider.tag.Equals("9anfoud") )
					{ // clicked smwhere else than 9nafed				
					try {
						setTouched (false);
						selectedObject = null;
						} catch (System.Exception ex) {	}
				
					}
			} 			
		}
	}
		
	private bool getTouched(){
		return selectedObject.GetComponent<Animator> ().GetBool ("touched");
	}
	private void setTouched(bool t ) {
		selectedObject.GetComponent<Animator> ().SetBool ("touched", t); 
	
	}
		

	public void explode(GameObject obj) {
		Vector3 p = obj.transform.position;

		for (int angle =0; angle < 360; angle +=10) {
			Vector3 direction = new Vector3 (Mathf.Cos (angle * Mathf.Deg2Rad), Mathf.Sin (angle * Mathf.Deg2Rad),p.z);
			GameObject projectile = (GameObject)Instantiate (needle, p+(direction) , Quaternion.Euler(0,0,angle));
			projectile.GetComponent<Rigidbody2D>().velocity=  direction*speed;
		}
		obj.GetComponent<AudioSource> ().Play ();
		obj.GetComponent<SpriteRenderer> ().enabled = false;
		obj.GetComponent<CircleCollider2D> ().enabled = false;
		setTouched (true);
		Destroy (obj, 0.5f);
	
	}



}