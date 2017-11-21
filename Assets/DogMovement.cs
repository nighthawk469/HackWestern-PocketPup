using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour {
	public Transform[] target;
	public float speed;

	private int current;

	public EffectInstantiate effectted;
	Animator anim;

	//int idleHash = anim.StringToHash("walkToIdle");


	// Use this for initialization
	void Start () {
		effectted = FindObjectOfType (typeof(EffectInstantiate)) as EffectInstantiate;
		Vector3 direction = target[current].position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (direction);
		GetComponent<Rigidbody> ().MoveRotation (rotation);
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		if (transform.position != target[current].position) {
			Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed);
			GetComponent<Rigidbody>().MovePosition(pos);
		} else {

			current = (current + 1) % target.Length;

			Vector3 direction = target[current].position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (direction);
			GetComponent<Rigidbody> ().MoveRotation (rotation);



			//// Trying to rotate the dog more smoothly

//			if (transform.position != target[current].position) {
//				Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed);
//				GetComponent<Rigidbody>().MovePosition(pos);
//			} else {
//				//find rotation between objects
//				Vector3 direction = target[current].position - transform.position;
//				Debug.Log ("UPDATE " + direction);
//				Quaternion rotation = Quaternion.LookRotation (direction);
//
//				if (transform.rotation != rotation) {
//					Quaternion q = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
//
//
//					transform.rotation = q;
//				}
//				else 
//					current = (current + 1) % target.Length;
//				
		}
	}
}