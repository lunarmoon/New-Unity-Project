using UnityEngine;
using System.Collections;

public class SpawnedObject : MonoBehaviour {

    public Vector2 velocity;
	public Vector3 rotation;
	public float checkDistance;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value, Random.value);
        GetComponent<Rigidbody2D>().velocity *= 16;
        GetComponent<Rigidbody2D>().velocity -= new Vector2(4f, 4f);
		rotation = new Vector3 (0f, 0f, 1f);
		checkDistance = .3f;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate() {
        velocity = GetComponent<Rigidbody2D>().velocity;
        if (velocity.x < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, checkDistance, LayerMask.GetMask("borderCollisions"));
            if (hit.transform != null)
            { 
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * -1, velocity.y);
				rotation = new Vector3 (0f, 0f, rotation.z * -1);
            }
        }

        else if (velocity.x > 0)
        {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, checkDistance, LayerMask.GetMask("borderCollisions"));
            if (hit.transform != null)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * -1, velocity.y);
				rotation = new Vector3 (0f, 0f, rotation.z * -1);
            }
        }

        if (velocity.y > 0)
        {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, checkDistance, LayerMask.GetMask("borderCollisions"));
            if (hit.transform != null)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * -1);
				rotation = new Vector3 (0f, 0f, rotation.z * -1);
            }
        }

        else if (velocity.y < 0)
        {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, LayerMask.GetMask("borderCollisions"));
            if (hit.transform != null)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y * -1);
				rotation = new Vector3 (0f, 0f, rotation.z * -1);
            }
        }

		transform.rotation = Quaternion.Euler (transform.eulerAngles +
			(rotation * Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2))));
    }
}
