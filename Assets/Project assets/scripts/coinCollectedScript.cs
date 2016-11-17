using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class coinCollectedScript : MonoBehaviour {

    // Use this for initialization
    public GameObject coinScore;
    void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "9anfoud")
        {
            coinScore.GetComponent<AudioSource>().Play();
             MyScoreManager.totalScore++;
                Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update () {
	
	}
}
