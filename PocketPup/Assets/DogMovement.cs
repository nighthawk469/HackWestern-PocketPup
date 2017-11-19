using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour {
	public Transform[] target;
	public float speed;

	private int current;

	// Use this for initialization
	void Start () {
		Vector3 direction = target[current].position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (direction);
		GetComponent<Rigidbody> ().MoveRotation (rotation);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position != target[current].position)
		{
			Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed);
			GetComponent<Rigidbody>().MovePosition(pos);
		}
		else
		{

			current = (current + 1) % target.Length;

			Vector3 direction = target[current].position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (direction);
			GetComponent<Rigidbody> ().MoveRotation (rotation);


		
		}
	}
}
