using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathZoneManager : MonoBehaviour
{
	public Text resultText;
	public EnemyAI enemy;

	bool hasEnded;

	float t;

	private void Start()
	{
		hasEnded = false;
		t = 0;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Destroy(collision.gameObject);
			Debug.Log("Destroyed: " + collision.transform.name);

			if (collision.transform.name.Equals("Player") && hasEnded == false)
			{
				Debug.Log("You Lose!");
				resultText.text = "You Lose!";
				hasEnded = true;
				EnemyAI.decreaseDifficulty();
			}
			else if (collision.transform.name.Equals("Enemy") && hasEnded == false)
			{
				Debug.Log("You Win!");
				resultText.text = "You Win!";
				hasEnded = true;
				EnemyAI.increaseDifficulty();
			}
		}

		if (hasEnded)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

}
