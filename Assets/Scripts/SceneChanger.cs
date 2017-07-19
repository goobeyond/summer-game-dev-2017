using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

    private bool start = false;
    private string _scenename;
    private float Counter;
     


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        if (start == true)
        {
            Counter += 1*Time.deltaTime;
            if (Counter > 1.5)
            {
                Application.LoadLevel(_scenename);
            }
        }
    }

    public void OnClickChange(string scenename)
    {
        _scenename = scenename;
        start = true;
    }
}
