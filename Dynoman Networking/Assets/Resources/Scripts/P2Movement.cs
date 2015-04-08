using UnityEngine;
using System.Collections;

public class P2Movement : MonoBehaviour {
	
	public float speed = 500;
	private GameObject p7;
	private Vector3 p7position = new Vector3(0, 0, 0);
	public bool isMoving = false;
	public bool canTurn = true;
	
	public bool alive2 = true;
	
	private Vector3 vNorth = new Vector3(0, 0, 1);
	private Vector3 vSouth = new Vector3(0, 0, -1);
	private Vector3 vEast = new Vector3(1, 0, 0);
	private Vector3 vWest = new Vector3(-1, 0, 0);
	
	public bool canMove = true;
	
	// Use this for initialization
	void Start () {
		p7 = GameObject.Find("P7");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving && Input.GetKey(KeyCode.I) && canMove){
			isMoving = true;
			canTurn = false;
			p7position = p7.transform.position;
			StartCoroutine("MoveForwards");
		}
		
		if (canTurn && !isMoving && Input.GetKey(KeyCode.J) || (Input.GetKeyDown(KeyCode.J) && canTurn)){
			StartCoroutine("RotateLeft");
		}
		
		if (canTurn && !isMoving && Input.GetKey(KeyCode.L) || (Input.GetKeyDown(KeyCode.L) && canTurn)){
			StartCoroutine("RotateRight");
		}
		
		if (!alive2){
			
			StartCoroutine("Respawn");
		}
		
	}
	
	IEnumerator Respawn () {
		
		yield return new WaitForSeconds(3);
		alive2 = true;
		transform.position = new Vector3(0,0,-1);
		
	}
	
	
	IEnumerator MoveForwards () {
		
		switch((int)transform.forward.z){
		case 1:
			//Debug.Log("North");
			do{
				rigidbody.velocity = (transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.z <= p7position.z);
			break;
		case -1:
			//Debug.Log("South");
			do{
				rigidbody.velocity = (transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.z >= p7position.z);
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
			}while(transform.position.x <= p7position.x);
			break;
		case -1:
			//Debug.Log("West");
			do{
				rigidbody.velocity = (transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.x >= p7position.x);
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
		canTurn = false;
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3 (0, -3, 0));
			yield return null;
		}
		canTurn = true;
	}
	
	IEnumerator RotateRight () {
		canTurn = false;
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3 (0, 3, 0));
			yield return null;
		}
		canTurn = true;
	}
}
