using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {
	public Text scoreText,scoreTextBG;
	public GameObject restartMessage,winMessage,knifeSelector,gunSelector,endSection;
	int currentScore=0;
	static GameManager myslf;
	public bool gameOver=false;
	int enemyCount;
	public GameObject gameMenu, player_go;
	void Awake(){
		myslf = this;

	}
	// Use this for initialization
	void Start () {
		gameMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver && Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if(!gameOver && Input.GetKeyDown(KeyCode.Escape)){
			Time.timeScale  = 0;
			
			gameMenu.SetActive(true);
			player_go.SetActive(false);
		}

	}
	public static void AddScore(int pointsAdded){
		myslf.currentScore += pointsAdded;
		myslf.scoreText.text = myslf.currentScore.ToString ();
		myslf.scoreTextBG.text = myslf.currentScore.ToString ();
		myslf.scoreText.transform.localScale = Vector3.one * 2.5f;
		iTween.Stop (myslf.scoreText.gameObject);
		iTween.ScaleTo (myslf.scoreText.gameObject, iTween.Hash ("scale", Vector3.one, "time", 0.25f, "delay", 0.1f, "easetype", iTween.EaseType.spring));
	}
	public static void RegisterPlayerDeath(){
		myslf.restartMessage.SetActive (true);
		myslf.restartMessage.transform.localScale = Vector3.one *2.0f;
		iTween.Stop (myslf.restartMessage.gameObject);
		iTween.ScaleTo (myslf.restartMessage, iTween.Hash ("scale", Vector3.one, "time", 0.5f, "delay", 0.1f, "easetype", iTween.EaseType.spring));
		myslf.gameOver = true;
	}
	public static void SelectWeapon(PlayerWeaponType weaponType){
		switch (weaponType) {
			case PlayerWeaponType.KNIFE:
				myslf.knifeSelector.SetActive(true);
				myslf.gunSelector.SetActive(false);
			break;
			case PlayerWeaponType.PISTOL:
				myslf.knifeSelector.SetActive(false);
				myslf.gunSelector.SetActive(true);
			break;
		}

	}
	public static void AddToEnemyCount(){
		myslf.enemyCount++;
		//Debug.Log("Registered enemies: " + myslf.enemyCount);
	}
	public static void RemoveEnemy(){
		myslf.enemyCount--;
		if (myslf.enemyCount <= 0) {
			myslf.endSection.SetActive(true);

			myslf.winMessage.SetActive (true);
			myslf.winMessage.transform.localScale = Vector3.one *2.0f;
			iTween.Stop (myslf.winMessage.gameObject);
			iTween.ScaleTo (myslf.winMessage, iTween.Hash ("scale", Vector3.one, "time", 0.5f, "delay", 0.1f, "easetype", iTween.EaseType.spring));
		}

	}
}

