using UnityEngine;
using System.Collections;

public class SpawnBomb : MonoBehaviour {


	public bool canBomb = true;
	public bool canBombEx = false;
	public GameObject bomb;
	public GameObject BombEx;
	public int amount = 0;
	public int maxAmt = 3;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)){
			
			SpawnBomber();

		}

	}

	void SpawnBomber()
	{
		if (amount <= maxAmt && canBomb)
		{
			if(!canBombEx){

				Instantiate(bomb,transform.position, transform.rotation);
			}

			else if(canBombEx){
			
				Instantiate(BombEx,transform.position, transform.rotation);
			}

			amount++;
			canBomb = false;
			StartCoroutine("BombCooldown");

		}
		else if (amount > maxAmt)
		{
			Debug.LogWarning("Too many bombs");
		}
	}


	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2 - 300, Screen.width / 2 - 400, 50, 30), amount.ToString());
	}


	IEnumerator BombCooldown (){

		yield return new WaitForSeconds(0.75f);
		canBomb = true;
	}

	

}
