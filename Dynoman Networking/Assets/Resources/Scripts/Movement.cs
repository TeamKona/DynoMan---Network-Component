using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 500;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (networkView.isMine){
			if (Input.GetKey(KeyCode.W)){
				rigidbody.AddForce(transform.forward*speed*Time.deltaTime);
			}
			
			if (Input.GetKeyDown(KeyCode.A)){
				StartCoroutine("RotateLeft");
			}
			
			if (Input.GetKeyDown(KeyCode.D)){
				StartCoroutine("RotateRight");
			}
		}
	}

	IEnumerator RotateLeft (){
	
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3(0, -3, 0));
			yield return null;
		}
	}

	IEnumerator RotateRight (){
		
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3(0, 3, 0));
			yield return null;
		}
	}
}
