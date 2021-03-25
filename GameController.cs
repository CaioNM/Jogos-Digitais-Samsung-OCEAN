using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
	public GameObject ship;
	public Transform spawn;
	private int socre;
	public Text scoreText;

	void Start(){
		SpawnShip();
		ResetScore();
	}

	void SpawnShip(){
		Instantiate(ship, transform.position, transform.rotation);
	}
	public void Respawn(){
		StartCoroutine(Respawning());
	}

	IEnumerator Respawning(){
		yield return new WaitForSeconds(2);
		SpawnShip();
	}

	public void Score(int newScore){
		score += newScore;
		scoreText.text = score.ToString();
	}

	public void ResetScore ()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

}