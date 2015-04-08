using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public bool soundVol = false;
	// Use this for initialization
	void Start () {

		StartCoroutine("DespawnExplosion");
		gameObject.GetComponent<AudioSource>().volume = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay (Collider col)
	{


		if(col.gameObject.tag == "Combustible")
		{
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<PlayerMovement>().alive = false;
			col.gameObject.transform.position = new Vector3(transform.position.x,transform.position.y-50,transform.position.z);
		}
		if(col.gameObject.tag == "Player2")
		{
			col.gameObject.GetComponent<P2Movement>().alive2 = false;
			col.gameObject.transform.position = new Vector3(transform.position.x,transform.position.y-100,transform.position.z);
		}

	}
	


	IEnumerator DespawnExplosion (){

		yield return new WaitForSeconds(1.5f);
		GameObject.Destroy(this.gameObject);
	}
}
