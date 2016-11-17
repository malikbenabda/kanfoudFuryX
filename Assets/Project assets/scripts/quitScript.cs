using UnityEngine;
using System.Collections;

public class quitScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider.name.Equals("quitYes")) {
                    MyScoreManager.saveAll();
                    Application.Quit(); }
                if (hit.collider.name.Equals("quitNo")) { Destroy(gameObject); }

            }


        }
    }
}