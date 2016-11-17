using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject bushes;
	void Start () {
		bushes.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;

			if (touch.phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (pos);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
				Debug.Log ("clicked ");
				if (hit != null) {
					if ((hit.collider.name == "play")) {
						chargeScene.sceneName = "Scene0";
						bushes.SetActive (true);
					//	SceneManager.LoadScene (1);


					}
				}
			}

		}



	
	}
}
