using UnityEngine;
using System.Collections;

public class SwitchTarget : MonoBehaviour {

	public Transform switchToTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")){
			GetComponent<Follow>().target = switchToTarget;
		}
	}
}
