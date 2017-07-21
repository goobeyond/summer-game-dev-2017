using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGrab : MonoBehaviour {

    // Use this for initialization
    public AudioSource CoinSound;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collected");
        CoinSound.Play();
        gameObject.SetActive(false);
        other.gameObject.GetComponent<player>().Score += 1;
        
    }
  
}
