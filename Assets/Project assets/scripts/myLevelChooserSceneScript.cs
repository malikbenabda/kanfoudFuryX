using UnityEngine;
using System.Collections;

public class myLevelChooserSceneScript : MonoBehaviour {


	GameObject bushes;
    public int lastUnlocked;
    
	// Use this for initialization
	void Start () {
        lastUnlocked = MyScoreManager.lastUnlockedLevel;
        bushes = transform.GetChild(0).gameObject;
        bushes.SetActive (false);
        MyScoreManager.saveAll();
        for (int i = 1; i <= lastUnlocked; i++)
        {
            GameObject.Find("pad" + i).gameObject.SetActive(false);
        }

	}

	// Update is called once per frame
	void Update () {

		if (Input.touchCount == 1) {
			Touch touch = Input.touches [0];
			Vector3 pos = touch.position;

			if (touch.phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (pos);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

                //		if (hit != null) {
                int score = MyScoreManager.totalScore;
					string x = hit.collider.name;
					switch (x) {
					case "0"    :	{goToLevel ("Level",x);  break;}
					case "1" 	:	{goToLevel ("Level",x);  break;}
					case "2" 	:	{goToLevel ("Level",x);  break;}
					case "3"	:	{goToLevel ("Level",x);  break;}
					case "4" 	:   { if (score > 40) goToLevel ("Level",x);  break;}
					case "5" 	:	{   if (score>50)goToLevel ("Level",x);  break;}
					case "6" 	:	{    if (score>60) goToLevel ("Level",x);  break;}
				//	case "7" 	:	{goToLevel ("Level",x);  break;}
				//	case "8"	:	{goToLevel ("Level",x);  break;}
				//	case "9" 	:	{goToLevel ("Level",x);  break;}
				//	case "10" 	:	{goToLevel ("Level",x);  break;}
					case "back" :	{ redirect("MainMenuScene");  break;	}
					case "exit" :	{ redirect("MainMenuScene");  break;	}
						
					default		:	break;
					}
			//	}
			}




		}
	}
    private void redirect(string level) {
        chargeScene.sceneName =level; bushes.SetActive(true);
    }

    private void goToLevel(string s,string lvlnbr ){
        int nbr = int.Parse(lvlnbr);
        if (nbr <= lastUnlocked)
        { chargeScene.sceneName = s + lvlnbr; bushes.SetActive(true); }
        else
        {
            //show message that level is still locked
        }

	}


}