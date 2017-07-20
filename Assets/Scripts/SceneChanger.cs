using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class SceneChanger : MonoBehaviour {

    private bool start = false;
    private string _scenename;
    private float Counter;
    private bool ShowOff = false;
    private VignetteAndChromaticAberration CameraEffect;
    private float BuildUP;

    // Use this for initialization
    void Start () {
        if (FindObjectOfType<Camera>().GetComponent<VignetteAndChromaticAberration>() != null)
        {
            CameraEffect = FindObjectOfType<Camera>().GetComponent<VignetteAndChromaticAberration>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (start == true)
        {
            Counter += 1*Time.deltaTime;
            if (Counter > 1.5)
            {
                Application.LoadLevel(_scenename);
            }
        }
        if (ShowOff == true)
        {
            BuildUP += 0.18f * Time.deltaTime;
            CameraEffect.intensity = Mathf.Lerp(0.0f, 1.0f, BuildUP);

            if (BuildUP > 0.9f)
            {
                _scenename = "EndScore";
                start = true;
            }
        }



    }

    public void OnClickChange(string scenename)
    {
        _scenename = scenename;
        start = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShowOff = true;
    }
}
