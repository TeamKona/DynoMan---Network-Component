using UnityEngine;
using System.Collections;

public class BombAmount : MonoBehaviour {

	public GUIText bombAmount;


	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		if (networkView.isMine)
			bombAmount.text = "Bombs: " + GameObject.FindWithTag("Player").GetComponent<SpawnBomb>().amount;

	}
}
