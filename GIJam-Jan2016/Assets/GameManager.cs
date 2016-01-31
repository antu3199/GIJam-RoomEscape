using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {

public	List<GameObject> Spawners = new List<GameObject>();

	public static int Level = 1;

	public GameObject Portal;


	// Use this for initialization
	void Start () {
		Portal.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}





}
