using UnityEngine;
using System.Collections;

public class CreateBoxBorders : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject border = (GameObject)Instantiate(Resources.Load("BoxBorder"));
        border.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
        border.GetComponent<BoxCollider2D>().size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2;
        border.GetComponent<BoxCollider2D>().offset = new Vector2((border.GetComponent<BoxCollider2D>().size.x/2) * -1, 0f);

        GameObject border2 = (GameObject)Instantiate(Resources.Load("BoxBorder"));
        border2.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
        border2.GetComponent<BoxCollider2D>().size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2;
        border2.GetComponent<BoxCollider2D>().offset = new Vector2(0f, (border2.GetComponent<BoxCollider2D>().size.y / 2) * -1);

        GameObject border3 = (GameObject)Instantiate(Resources.Load("BoxBorder"));
        border3.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        border3.GetComponent<BoxCollider2D>().size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2;
        border3.GetComponent<BoxCollider2D>().offset = new Vector2((border3.GetComponent<BoxCollider2D>().size.x / 2), 0f);

        GameObject border4 = (GameObject)Instantiate(Resources.Load("BoxBorder"));
        border4.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
        border4.GetComponent<BoxCollider2D>().size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2;
        border4.GetComponent<BoxCollider2D>().offset = new Vector2(0f, (border2.GetComponent<BoxCollider2D>().size.y / 2) * 1);

    }
}
