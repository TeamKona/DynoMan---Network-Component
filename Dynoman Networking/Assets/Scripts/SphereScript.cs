using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		Debug.Log("Entered");
		Vector3 newCol = new Vector3(0, 0 ,1);
		networkView.RPC("SetColor", RPCMode.AllBuffered, newCol);
	}

	[RPC]
	void SetColor(Vector3 col){
		renderer.material.color = new Color(col.x, col.y, col.z, 1);
	}
}
