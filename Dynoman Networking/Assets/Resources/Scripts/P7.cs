using UnityEngine;
using System.Collections;

public class P7 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Deny player movement if detects obstacle
	void OnTriggerStay (Collider other){
		if (other.gameObject.name == "Wall"){
			GameObject.Find("Player2").GetComponent<P2Movement>().canMove = false;
		}
	}
	
	//Allow player movement otherwise
	void OnTriggerExit (Collider other){
		GameObject.Find("Player2").GetComponent<P2Movement>().canMove = true;
	}


}
