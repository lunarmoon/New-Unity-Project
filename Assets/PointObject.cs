using UnityEngine;
using System.Collections;

public class PointObject : MonoBehaviour {

    public float liveTime;
	public float rotateTime;
	public float rotateAmount;
	public Sprite secondSprite;

    float remainingTime;
	float rotationRemainingTime;
	float sprite2Time;
	Vector3 direction;
	bool stateOne;
	bool stateThree;
	float timeToRevert = .3f;

	// Use this for initialization
	void Start () {
        remainingTime = liveTime;
		rotationRemainingTime = rotateTime;
		sprite2Time = Random.value * liveTime;
		direction = new Vector3 (0, 0, 1);
		stateOne = true;
		stateThree = false;
	}
	
	// Update is called once per frame
	void Update () {
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0)
            Destroy(this.gameObject);
		if (stateOne && remainingTime <= sprite2Time) {
			Sprite temp = GetComponent<SpriteRenderer> ().sprite;
			GetComponent<SpriteRenderer> ().sprite = secondSprite;
			secondSprite = temp;
			stateOne = false;
		}
		if (!stateOne && !stateThree) {
			timeToRevert -= Time.deltaTime;
			if (timeToRevert <= 0) {
				GetComponent<SpriteRenderer> ().sprite = secondSprite;
				stateThree = true;
			}
		}
	}

	void FixedUpdate() {
		Quaternion fromAngle = transform.rotation;
		Quaternion toAngle = Quaternion.Euler (transform.eulerAngles + (direction * rotateAmount));

		if (rotationRemainingTime > 0) {
			rotationRemainingTime -= Time.deltaTime;
			transform.rotation = Quaternion.Lerp (fromAngle, toAngle, rotationRemainingTime);
		}

		else {
			rotationRemainingTime = rotateTime;
			direction = new Vector3(direction.x, direction.y, direction.z * -2);
		}
	}
}
