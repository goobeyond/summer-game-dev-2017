using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithCoin : MonoBehaviour {

    GameObject coin;

	// Use this for initialization
	void Start () {
        coin = transform.Find("coin").gameObject;
	}
	
	void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit the box");
        InvokeRepeating("moveTheCoin", 0, 0.01f);
        
    }

    void moveTheCoin()
    {
        if (!coin)
        {
            return;
        }

        if (coin.transform.position.y >= 50f){
            CancelInvoke("moveTheCoin");
            DestroyObject(coin);
        }
       
        coin.transform.Translate(new Vector3(0, 1));
    }

}
