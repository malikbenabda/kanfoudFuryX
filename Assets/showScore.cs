using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class showScore : MonoBehaviour {
	public Canvas mycanvas; 
	 Text mytxt;
	// Use this for initialization
	void Start () {
		mycanvas= Instantiate (mycanvas);
		mytxt = mycanvas.GetComponentInChildren<Text> ();
		mytxt.text = "X "+MyScoreManager.totalScore;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
