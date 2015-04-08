using UnityEngine;
using System.Collections;

public class DeMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( (Input.GetAxis("Horizontal") * 5 * Time.deltaTime), 0, 0);

		if (Input.GetKeyDown(KeyCode.E)){
			GameObject.Find("Main Camera").GetComponent<Camera>().orthographic = false;
		}
	}
}
