using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Collections;
public class MyLevelSceneScriptManager : MonoBehaviour {
	 GameObject bushes;
    public GameObject won, lost;
	private GameObject[] Enemies,kanfouds;
	private  Vector3 v3;
    public Text mytext;
    bool messageNotShown;
    
	// Use this for initialization
	void Start () {
        messageNotShown = true;
        mytext.text = "X " +MyScoreManager.totalScore+"";
        bushes = transform.GetChild(0).gameObject;
        bushes.SetActive (false);
}


	// Update is called once per frame
	void Update () {
          mytext.text ="X  " +MyScoreManager.totalScore ;
        ///   mytext.text = Input.GetTouch(0).position.ToString();
            Enemies = GameObject.FindGameObjectsWithTag ("enemy");
			kanfouds = GameObject.FindGameObjectsWithTag ("9anfoud");
	    	if (Enemies.Length == 0 && messageNotShown) 
            { // pop success window 
            won =Instantiate(won);
            messageNotShown = false;
            }
			if (kanfouds.Length == 0 && Enemies.Length > 0 && messageNotShown) 
			{    //show failed message : 
           lost= Instantiate(lost);
            ShowAd();
            messageNotShown = false;
             }






		if (Input.touchCount == 1) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;

			if (touch.phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (pos);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

				if (hit != null) {
					if ((hit.collider.name == "levels")) {
						levelChooser ();
					}
                    if ((hit.collider.name == "replay"))
                    {
                        replayScene();
                    }
                    if ((hit.collider.name == "nextLevel"))
                    {
                        nextLevel();

                    }
                    if ((hit.collider.name == "objective"))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    if ((hit.collider.name == "fbShare"))
                    {
               
             //           FB.ShareLink(uri, "9anfoud Fury Game", "My totat sum of coins so far = "+MyScoreManager.totalScore, null, null);
                    }
                    if (hit.collider.tag == "arnab") {

						GameObject go = hit.collider.gameObject;
						Destroy (go,3f); 
						go.GetComponent<Animator> ().SetBool ("dragged", true);
						go.GetComponent<Rigidbody2D>().velocity= 50 * Vector2.right; 
					
					
					}


				}
			}
		}
	}

	private void replayScene(){
		chargeScene.sceneName = SceneManager.GetActiveScene().name;
		bushes.SetActive (true);

	}
	private void levelChooser(){
		chargeScene.sceneName = "LevelChooser";
		bushes.SetActive (true);
	}

    private void nextLevel() {
        ShowAd();
       string sceneNumber= SceneManager.GetActiveScene().name.Substring(5);
        int nextlevel= int.Parse(sceneNumber) + 1;
        MyScoreManager.lastUnlockedLevel = nextlevel;
        chargeScene.sceneName = "Level"+nextlevel ;
        MyScoreManager.saveAll();
        bushes.SetActive(true);


    }


    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

}