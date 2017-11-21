using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public Camera view;
	public GameObject bone;
	public float strength;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Vector3 rayOrigin = view.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, view.nearClipPlane));
			RaycastHit hit;
			Physics.Raycast(rayOrigin, view.transform.forward, out hit);
			GameObject go = Instantiate(bone, rayOrigin, Quaternion.identity);
			Vector3 direction = (hit.point-rayOrigin);
			direction.Normalize();
			go.GetComponent<Rigidbody> ().AddForce (direction * strength);
		}
	}


}
