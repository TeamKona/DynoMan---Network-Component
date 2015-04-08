using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 500;
	private GameObject p8;
	private Vector3 p8position = new Vector3(0, 0, 0);
	public bool isMoving = false;
	public bool canTurn = true;
	public bool isTurning = false;

	public bool alive = true;
	public bool respawning = false;

	private Vector3 vNorth = new Vector3(0, 0, 1);
	private Vector3 vSouth = new Vector3(0, 0, -1);
	private Vector3 vEast = new Vector3(1, 0, 0);
	private Vector3 vWest = new Vector3(-1, 0, 0);

	public bool canMove = true;

	// Use this for initialization
	void Start () {
		p8 = GameObject.Find("P8");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving && Input.GetKey(KeyCode.W) && canMove){
			isMoving = true;
			canTurn = false;
			p8position = p8.transform.position;
			StartCoroutine("MoveForwards");
		}

		if (canTurn && !isMoving && Input.GetKey(KeyCode.A) || (Input.GetKeyDown(KeyCode.A) && canTurn)){
			StartCoroutine("RotateLeft");
		}

		if (canTurn && !isMoving && Input.GetKey(KeyCode.D) || (Input.GetKeyDown(KeyCode.D) && canTurn)){
			StartCoroutine("RotateRight");
		}

		if (!alive){

			StartCoroutine("Respawn");
		}

	}

	IEnumerator Respawn () {
		if(!respawning){

			respawning = true;
			GameObject.Find("Level").GetComponent<Score>().scoreNum++;
			yield return new WaitForSeconds(3);
			alive = true;
			transform.position = new Vector3(0,0,0);
			respawning = false;

		}
	}


	IEnumerator MoveForwards () {

		switch((int)transform.forward.z){
		case 1:
			//Debug.Log("North");
			do{
				rigidbody.velocity = (transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.z <= p8position.z);
			break;
		case -1:
			//Debug.Log("South");
			do{
				rigidbody.velocity = (transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.z >= p8position.z);
			break;
		default:	
			break;
		}
		switch((int)transform.forward.x){
		case 1:
			//Debug.Log("East");
			do{
				rigidbody.velocity = (transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.x <= p8position.x);
			break;
		case -1:
			//Debug.Log("West");
			do{
				rigidbody.velocity = (transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.x >= p8position.x);
			break;
		default:	
			break;
		}
		//Movement is finished by this point

		//Stop all motion
		rigidbody.velocity = new Vector3(0, 0, 0);
		//'Normalize'
		transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));

		isMoving = false;
		canTurn = true;
	}

	IEnumerator RotateLeft () {
		if (!isTurning){
			isTurning = true;
			canTurn = false;
			for (int i = 0; i < 90; i+=3){
				transform.Rotate(new Vector3 (0, -3, 0));
				yield return null;
			}
			canTurn = true;
			isTurning = false;
		}
	}

	IEnumerator RotateRight () {
		if (!isTurning){
			isTurning = true;
			canTurn = false;
			for (int i = 0; i < 90; i+=3){
				transform.Rotate(new Vector3 (0, 3, 0));
				yield return null;
			}
			canTurn = true;
			isTurning = false;
		}
	}
}
