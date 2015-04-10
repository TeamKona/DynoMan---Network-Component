using UnityEngine;
using System.Collections;

public class PowerUpChecker : MonoBehaviour {

	public GameObject bomb;
	public GameObject bombEx;
	public GameObject explosion;
	public GameObject silentexplosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (networkView.isMine){
		transform.position = GameObject.FindWithTag("Player").transform.position;
		}
	}

	void OnTriggerStay(Collider col){
		if (networkView.isMine){
			if(col.gameObject.name == "PowerUpBombEx"){
				
				Debug.Log("Power Up Collected");
				GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnBomb>().canBombEx = true;
			}
			
			if(col.gameObject.name == "PowerUpBombAmtEx")
			{
				Debug.Log("Power Up Collected");
				GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnBomb>().maxAmt = 5;
			}
			
			if(col.gameObject.name == "SilentBomb")
			{
				Debug.Log("Power Up Collected");
				bomb.GetComponent<Bomb>().silBombEnabled = true;
			}
			
			if(col.gameObject.name == "SpeedReduce")
			{
				Debug.Log("Power Down Collected");
				StartCoroutine("SpeedDown");
				
			}
			
			if(col.gameObject.name == "ExplosionReduction")
			{
				Debug.Log("Power Down Collected");
				StartCoroutine("SmallExplosion");
			}
			
			if(col.gameObject.name == "SoundIncrease")
			{
				Debug.Log("Power Down Collected");
				StartCoroutine("SoundInc");
			}
		}

	}

	IEnumerator SoundInc (){
		
		explosion.GetComponent<AudioSource>().maxDistance = 100f;
		silentexplosion.GetComponent<AudioSource>().maxDistance = 100f;
		yield return new WaitForSeconds(5.5f);
		explosion.GetComponent<AudioSource>().maxDistance = 5f;
		silentexplosion.GetComponent<AudioSource>().maxDistance = 5f;
	}
	
	IEnumerator SmallExplosion (){
		
		bomb.GetComponent<Bomb>().expAreaNorm = 1;
		
		bombEx.GetComponent<BombEx>().expArea = 1;

		yield return new WaitForSeconds(5.5f);

		bomb.GetComponent<Bomb>().expAreaNorm = 3;
		bombEx.GetComponent<BombEx>().expArea = 4;

	}

	IEnumerator SpeedDown (){
		if (networkView.isMine){
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed = 150f;
			yield return new WaitForSeconds(5.5f);
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed = 400f;
		}
	}

}
