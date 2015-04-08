using UnityEngine;
using System.Collections;

public class p8 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	//Deny player movement if detects obstacle
	void OnTriggerStay (Collider other){
		if (networkView.isMine){
			if (other.gameObject.name == "Wall" || other.gameObject.name == "Cube1"){
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().canMove = false;
			}
		}
	}

	//Allow player movement otherwise
	void OnTriggerExit (Collider other){
		if (networkView.isMine){
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().canMove = true;
		}
	}

}
