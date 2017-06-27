using UnityEngine;
using System.Collections;

public class StockArea : MonoBehaviour {

	public int amountToStock;
	public bool stockFinished;

	private StockManager stockManager;
//	private GameObject lastBlock;
//
//	public bool autoAttach = true;
//	public float attachSpeed;
//	public float attachRotationSpeed;

	void Awake(){
		stockManager = FindObjectOfType<StockManager> ();
	}

	void Update(){

		if (amountToStock == 0) {
			stockFinished = true;
		}
		else if(amountToStock > 0){
			stockFinished = false;
		}

//		if (stockFinished) {
//			if (lastBlock != null) {		
//
//				if (autoAttach) {
//					lastBlock.transform.position = Vector3.Lerp (lastBlock.transform.position, transform.position, attachSpeed * Time.deltaTime);		
//					lastBlock.transform.rotation = Quaternion.Lerp (lastBlock.transform.rotation, Quaternion.identity, attachRotationSpeed * Time.deltaTime);
//					lastBlock.GetComponent<Rigidbody2D> ().isKinematic = true;	
//				}					
//			}
//		}
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Block")) {
		//	lastBlock = other.gameObject;
			amountToStock--;		
			stockManager.CheckStocks ();	
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Block")) {
		//	lastBlock = null;
			amountToStock++;		
			stockManager.CheckStocks ();
		}
	}
}
