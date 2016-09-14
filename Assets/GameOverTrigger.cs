using UnityEngine;
using System.Collections;

public class GameOverTrigger : MonoBehaviour {

    public GameObject killerObject;
	public bool noDeath;
	public bool menuDisplayed;
	private bool highScore = false;

	public GameObject canvas;
	// Use this for initialization
	void Start () {
		canvas.SetActive(false);
        Vector3[] positions = { Camera.main.ScreenToWorldPoint(new Vector3(0f, 0, 0f)),
                                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0f))};
        positions[0].z = 0f;
        positions[1].z = 1f;
        positions[0].y = 0f;
        positions[1].y = 0f;
        GetComponent<LineRenderer>().SetPositions(positions);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
		if (!menuDisplayed && coll.gameObject.name == killerObject.name && !noDeath) {
			displayMenu();
		}
			//UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }

	void displayMenu()
	{
		menuDisplayed = true;
		SpawnObject leftSpawner = GameObject.Find("SpawnerLeft").GetComponent<SpawnObject>();
		SpawnObject rightSpawner = GameObject.Find("SpawnerRight").GetComponent<SpawnObject>();
		PointObjectSpawner pointSpawner = GameObject.Find("PointSpawner").GetComponent<PointObjectSpawner>();

		leftSpawner.spawnOn = false;
		rightSpawner.spawnOn = false;
		pointSpawner.spawnOn = false;

		int score = GameObject.Find ("TouchManager").GetComponent<TouchManager>().score;

		int[] highScores = PlayerPrefsX.GetIntArray("highScores");
		highScores = binaryInsert(highScores, score);

		PlayerPrefsX.SetIntArray ("highScores", highScores);
		canvas.SetActive(true);
	}

	int[] binaryInsert(int[] highScores, int score)
	{
		if (score > highScores[0]) {
			highScores = new int[]{score, highScores[0], highScores[1]};
		}
		else if (score > highScores[1]) {
			highScores = new int[]{highScores[0], score, highScores[1]};
		}
		else if (score > highScores[2]) {
			highScores = new int[]{highScores[0], highScores[1], score};
		}

		return highScores;

		//binaryInsert(highScores, score, 0, 2);
	}

	void binaryInsert(int[] array, int value, int low, int high)
	{
		//To be implemented
	}
}
