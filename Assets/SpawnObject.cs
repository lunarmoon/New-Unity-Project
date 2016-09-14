using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

    public float spawnTime;
    public float offset;
    public GameObject toSpawn;
	public bool spawnOn;
    private float timeRemaining;

	// Use this for initialization
	void Start () {
        timeRemaining = offset;
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        if (spawnOn && timeRemaining < 0)
        {
            //Debug.Log("Spawning");
            timeRemaining = spawnTime;
            GameObject spawned = (GameObject)Instantiate(toSpawn);
            spawned.name = toSpawn.name;
            spawned.transform.position = transform.position;
        }
	}
}
