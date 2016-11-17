using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuSceneControlerScript : MonoBehaviour {
    public Text mytext;
    public Sprite on, off;
	public GameObject bushes;
	private GameObject[] Enemies,kanfouds;
	private  Vector3 v3;
    public GameObject quitMessage;
	// Use this for initialization
	void Start () {
		bushes.SetActive (false);
        MyScoreManager.initializing();

    }

	// Update is called once per frame
	void Update () {
        mytext.text = "X  " + MyScoreManager.totalScore;

		if (Input.touchCount == 1) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;

			if (touch.phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (pos);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

			//	if (hit != null) {
					if ((hit.collider.name == "play")) {
						chargeScene.sceneName = "LevelChooser";
						bushes.SetActive (true);
					}
					if ((hit.collider.name == "exit")) {

                    Instantiate(quitMessage);

					}
					if ((hit.collider.name == "music")) {
                    Sprite sp;
						AudioListener.pause = ! AudioListener.pause;
                    if (AudioListener.pause) sp = off; else sp = on;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite=sp;;


                }
					if ((hit.collider.name == "settings")) {
						chargeScene.sceneName = "SettingsScene";
						bushes.SetActive (true);
					}
				//}
			}

			if (touch.phase == TouchPhase.Moved) {

			}


		}
	}




}