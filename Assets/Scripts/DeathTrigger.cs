using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

	public bool hasLost = false;
	private StockManager stockManager;

	void Start()
	{
		stockManager = FindObjectOfType<StockManager> ();
	}

	void OnTriggerEnter2D() {
		if (!stockManager.stockCompleted || !stockManager.stockFail) {
			hasLost = true;
			StartTrigger ();
		}
	}

	private void StartTrigger() {
		if(hasLost) {
			stockManager.HasLost ();
		}
	}
}
