using UnityEngine;
using System.Collections;

public class InitializeGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] highScores = PlayerPrefsX.GetIntArray("highScores");
		if (highScores.Length == 0) {
			PlayerPrefsX.SetIntArray("highScores", new int[] {0, 0, 0});
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
