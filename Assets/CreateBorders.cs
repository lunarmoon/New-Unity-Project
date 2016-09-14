using UnityEngine;
using System.Collections;

public class CreateBorders : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float size = 5f;

        GameObject border = (GameObject)Instantiate(Resources.Load("Border"));
        border.transform.position = Camera.main.ScreenToWorldPoint(Vector2.zero + new Vector2(Screen.width/2, Screen.height/2));
		Vector2[] arr = { Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, size)) };
        border.GetComponent<EdgeCollider2D>().points = arr;

        GameObject border2 = (GameObject)Instantiate(Resources.Load("Border"));
        border2.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height) + new Vector2(Screen.width / 2, Screen.height / 2));
		Vector2[] arr2 = { Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, size)) };
        border2.GetComponent<EdgeCollider2D>().points = arr2;

        GameObject border3 = (GameObject)Instantiate(Resources.Load("Border"));
        border3.transform.position = Camera.main.ScreenToWorldPoint(Vector2.zero + new Vector2(Screen.width / 2, Screen.height / 2));
		Vector2[] arr3 = { Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)), Camera.main.ScreenToWorldPoint(new Vector2(size, Screen.height)) };
        border3.GetComponent<EdgeCollider2D>().points = arr3;

        GameObject border4 = (GameObject)Instantiate(Resources.Load("Border"));
        border4.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f) + new Vector2(Screen.width / 2, Screen.height / 2));
		Vector2[] arr4 = { Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)), Camera.main.ScreenToWorldPoint(new Vector2(size, Screen.height)) };
        border4.GetComponent<EdgeCollider2D>().points = arr4;
    }
}
