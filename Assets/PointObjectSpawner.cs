using UnityEngine;
using System.Collections;

public class PointObjectSpawner : MonoBehaviour
{

    public float spawnTime;
    public GameObject toSpawn;
    private float timeRemaining;
	public bool spawnOn;
    GameObject gameOver;
    Vector2[] bounds = { Vector2.zero, Vector2.zero };

    // Use this for initialization
    void Start()
    {
        timeRemaining = spawnTime;
        gameOver = GameObject.Find("DeathZone");

        bounds[0] = Camera.main.ScreenToWorldPoint(new Vector2(0f, gameOver.transform.position.y));
        bounds[1] = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (spawnOn && timeRemaining < 0)
        {
            //Debug.Log("Spawning");
            timeRemaining = spawnTime;
            GameObject spawned = (GameObject)Instantiate(toSpawn);
            spawned.name = toSpawn.name;
            Vector2 newPos = new Vector2(Random.Range(bounds[0].x + .5f, bounds[1].x - .5f), 
                                            Random.Range(bounds[0].y + 1.5f, bounds[1].y - .5f));


            spawned.transform.position = newPos;
        }
    }
}
