using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public GameObject pellet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (networkView.isMine){
			if (Input.GetKey(KeyCode.W))
				rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
			
			if (Input.GetKey(KeyCode.S))
				rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
			
			if (Input.GetKey(KeyCode.D))
				rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
			
			if (Input.GetKey(KeyCode.A))
				rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);

			if (Input.GetKey(KeyCode.Space))
				networkView.RPC("CreatePellet", RPCMode.AllBuffered, transform.position);
		}
		else {
			enabled = false;
		}
	}
	
	[RPC]
	void CreatePellet(Vector3 playerPos){
		Instantiate(pellet, playerPos, Quaternion.identity);
	}
}
