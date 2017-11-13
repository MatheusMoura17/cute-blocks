using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int itemsToWin=3;
	private TargetArea[] targetAreas;

	// Use this for initialization
	void Start () {
		targetAreas = FindObjectsOfType<TargetArea> ();
		foreach (TargetArea area in targetAreas)
			area.onLinkItem = OnLinkItem;
	}


	void OnLinkItem(){
		int linkedItemsCount = 0;
		foreach (TargetArea area in targetAreas)
			linkedItemsCount+=area.linkedItems.Count;

		if (itemsToWin <= linkedItemsCount)
			SetGameWin ();
	}

	private void SetGameWin(){
		print ("Você ganhou!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
