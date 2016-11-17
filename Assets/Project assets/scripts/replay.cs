using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class replay : MonoBehaviour {
	public GameObject bushes;
	public  Text mytext;
	// Use this for initialization
	void Start () {
		bushes.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount == 1) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;

			if (touch.phase == TouchPhase.Began) {
				Debug.Log ("touched anywhere");

				Ray ray = Camera.main.ScreenPointToRay (pos);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
				Debug.Log ("clicked ");
				if (hit != null) {
					if ((hit.collider.name == "reload")) {
						chargeScene.sceneName = "Scene0";
						bushes.SetActive (true);
					

					//	SceneManager.LoadScene (1);



					}
				}
			}

		}





	}
}
