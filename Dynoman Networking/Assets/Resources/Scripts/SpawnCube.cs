using UnityEngine;
using System.Collections;

public class SpawnCube : MonoBehaviour {

	public GameObject spawnThis;
	private int cubeCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Instantiate(spawnThis, transform.position, transform.rotation);
			cubeCount++;
			Debug.Log("Cube Created");
		}
	}
}
