using UnityEngine;
using System.Collections;
using System;

public class TouchManager : MonoBehaviour {

    public int score;
    private bool[] swipeable = { true, true };
    public GameObject clickObject;
    public GameObject swipeObject;

    // Update is called once per frame
    void Start () {
        score = 0;
    }

    void Update () {
        handleTouch(0);
        handleTouch(1);
    }

    private void handleTouch(int touchNumber)
    {
        if (Input.touchCount > touchNumber && Input.GetTouch(touchNumber).phase == TouchPhase.Began)
        {
            //Create crosshair
            //GameObject crosshair = (GameObject)Instantiate(Resources.Load("Crosshair"));
            //crosshair.transform.position = Vector2.zero;

            //Delete Crosshair
            Vector2 posWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchNumber).position);
            Vector2 pos = new Vector2(posWorld.x, posWorld.y);
            Vector2 dir = Vector2.zero;

            RaycastHit2D hit = Physics2D.CircleCast(pos, .5f, dir, 0, LayerMask.GetMask("pointLayer"));
            if (hit.collider != null && hit.collider.name == clickObject.name)
            {
                score++;
                Destroy(hit.collider.gameObject);
                swipeable[touchNumber] = false;
            }
        }

        if (Input.touchCount > touchNumber && Input.GetTouch(touchNumber).phase == TouchPhase.Moved)
        {
            //Create crosshair
            //GameObject crosshair = (GameObject)Instantiate(Resources.Load("Crosshair"));
            //crosshair.transform.position = Vector2.zero;

            //Delete Crosshair
            Vector2 posWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchNumber).position);
            Vector2 pos = new Vector2(posWorld.x, posWorld.y);
            Vector2 dir = Vector2.zero;

			GameObject trail = GameObject.Find ("Trail" + touchNumber);
			trail.transform.position = pos;

            RaycastHit2D hit = Physics2D.CircleCast(pos, .5f, dir, 0, LayerMask.GetMask("swipeLayer"));
            if (hit.collider != null && hit.collider.name == swipeObject.name && swipeable[touchNumber])
            {
                Destroy(hit.collider.gameObject);
                swipeable[touchNumber] = false;
            }
        }

        if (Input.touchCount > touchNumber && Input.GetTouch(touchNumber).phase == TouchPhase.Ended)
        {
            swipeable[touchNumber] = true;
        }

        //else if (Input.GetMouseButtonUp(0))
        //{
        //    //Create crosshair
        //    //GameObject crosshair = (GameObject)Instantiate(Resources.Load("Crosshair"));
        //    //crosshair.transform.position = Vector2.zero;

        //    //Delete Crosshair
        //    Vector2 posWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 pos = new Vector2(posWorld.x, posWorld.y);
        //    Vector2 dir = Vector2.zero;

        //    RaycastHit2D hit = Physics2D.Raycast(pos, dir);
        //    if (hit != null && hit.collider != null)
        //    {
        //        Debug.Log("Item Detected");
        //        Destroy(hit.collider.gameObject);
        //    }
        //}
    }

    public GUIStyle menuStyle;
    void OnGUI()
    {
        menuStyle.fontSize = Convert.ToInt32(Screen.width * .1f);
        GUI.Label(new Rect(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * .5f, Screen.height * .8f)), new Vector2(100f, 100f)), 
                                                            "Score: " + score, menuStyle);
    }
}
