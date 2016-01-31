using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

public	List<GameObject> Spawners = new List<GameObject>();

	public static int Level = 1;
	public static float TotalCash = 100.0f;
	public static float Cash = 100.0f;
	public static float CashIncrease = 200.0f;
	public static float CashIncreaseIncrease = 50.0f;

	public static bool FinishedRound;
	public static bool StopAllBullets;
	public static bool WinLevel = false;



	public GameObject Portal;


	public float timeLimit;

	public float LevelTimeLimit;

	public Text timerText;

	private int priorTime;
	public Text criticalText;

	bool TimerActive = true;

	public float  increaseTimer = 0.0f;
	public float increaseInterval = 100.0f; 
	public float nextIncrease = 100.0f;

	int MaxCount = 0;
	int MaxEnemies = 10;


	public Text LevelText;

	// Use this for initialization
	void Start () {
		WinLevel = false;
		Portal.SetActive (false);
		if (Level == 1) {
			TotalCash = 100.0f;
			Cash = 100.0f;
			CashIncrease = 200.0f;
			timeLimit = 10.0f;
		} else if (Level == 2) {
			timeLimit = 15.0f;
		} else if (Level == 3) {
			timeLimit = 20.0f;
		} else {
			timeLimit = LevelTimeLimit;
		}
			
		StopAllBullets = false;
		FinishedRound = false;
		PlayerScript.Dead = false;
		LevelText.text = "FLOOR: " + Level;

		/*
		while (Cash >= 100.0f) {
			int RandTurret;
			if (Cash < 500.0f) {
				RandTurret = 0;

				Cash = 0.0f;

				Debug.Log (Cash);
			} else {
				RandTurret =  Random.Range (0, 1);

				if (RandTurret == 1) {
					Cash -= 500.0f;
				}

			}
		
			int SpawnDirection = Random.Range (0, 3);
			SpawnDirection = 1;

			Spawners [SpawnDirection].GetComponent<TurretSpawner> ().Spawn (RandTurret); 
			Debug.Log (Cash);

			if (Cash < 500.0f) {
				Cash = 0.0f;
			}




		}
		*/
	//	Spawners [2].GetComponent<TurretSpawner> ().Spawn (1); 

		while (Cash > 0) {
			int RandTurret = 0;
			RandTurret =  Random.Range (0, 2);

			if (RandTurret == 0) {
				Cash -= 100; 
			} else if (RandTurret == 1 && Cash >= 500) {
				Cash -= (500 + 50* Level);
			} else {
				RandTurret = 0;
				Cash -= 400;

			}
			int SpawnDirection = Random.Range (0, 4);
			if (MaxCount < MaxEnemies || Level >= MaxEnemies) {
				MaxCount++;
				Spawners [SpawnDirection].GetComponent<TurretSpawner> ().Spawn (RandTurret); 
			}

		}

		//MakeEnemies (Cash);


	}

	int test = 0;
	void MakeEnemies (float cash){

	//	Debug.Log (cash);
		int RandTurret;
		if (cash < 500) {
			cash = 0;
			RandTurret = 0;
		} else {
			RandTurret =  Random.Range (0, 2);

			if (RandTurret == 1) {
				cash -= 500.0f;
			} else if (RandTurret == 0) {
				cash -= 100.0f;
			}
		}
		int SpawnDirection = Random.Range (0, 4);
		//SpawnDirection = 1;
		test++;

	Spawners [SpawnDirection].GetComponent<TurretSpawner> ().Spawn (RandTurret); 

		if (cash >= 500) {
			MakeEnemies (Cash);
			Debug.Log (test);
		} else {
			cash = 0;
			Cash = 0;


		}


//		Debug.Log (cash);
	}

	
	// Update is called once per frame
	void Update () {
		

//		Debug.Log (Cash);


	

		if (TimerActive == true && PlayerScript.Dead == false) {



			if (timeLimit >= -1) {
				timerText.text = Mathf.Ceil (timeLimit).ToString ();
				if (timeLimit <= 10.0f) {
					timerText.color = new Color (1, 0, 0);
					Color myColor = criticalText.color;
					if (myColor.a > 0) {
						myColor.a = Mathf.Max (0, myColor.a - 2.0f * Time.deltaTime);
					}
					if (Mathf.Ceil (timeLimit) < priorTime) {
						myColor.a = 1.0f;

					}
			
				} 

				priorTime = (int)Mathf.Ceil (timeLimit);
				timeLimit -= Time.deltaTime;
			}
			if (timeLimit < 0) {
				timerText.text = "0";

				Portal.SetActive (true);
				Portal.GetComponent<PortalScript> ().CutsceneFadeIn ("White");
				TimerActive = false;
				FinishedRound = true;
				StopAllBullets = true;

				//	Application.LoadLevel ("MainMenu");
			}
		}


	}





}
