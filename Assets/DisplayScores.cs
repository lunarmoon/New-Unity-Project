using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] highScores = PlayerPrefsX.GetIntArray("highScores");
		transform.Find("Score1").gameObject.GetComponent<Text>().text = highScores[0].ToString();
		transform.Find("Score2").gameObject.GetComponent<Text>().text = highScores[1].ToString();
		transform.Find("Score3").gameObject.GetComponent<Text>().text = highScores[2].ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
