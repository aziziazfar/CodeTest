using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 endPos = new Vector3(5,0,0);
		gameObject.transform.position = Vector3.MoveTowards(
			gameObject.transform.position,
			endPos,
			1.0f * 0.1f // movement speed hardcoded 
			);
	}
}
