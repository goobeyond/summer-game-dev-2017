using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class IntroScene : MonoBehaviour {

    public GameObject AnimationOne;
    public GameObject Sleep;
    private VignetteAndChromaticAberration CameraEffect;
    [SerializeField] float TimeToNext=3;
    private float counter;
    private bool Resting = false;
    private bool Trigger1 = false;
    private float BuildUP;
    private float BuildUP2;

	// Use this for initialization
	void Start () {
        AnimationOne.SetActive(true);
        Sleep.SetActive(false);
       CameraEffect =  FindObjectOfType<Camera>().GetComponent<VignetteAndChromaticAberration>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter = counter +1 * (Time.deltaTime);
        Debug.Log(counter);
        if (counter > TimeToNext && Resting==false)
        {
            AnimationOne.SetActive(false);
            Sleep.SetActive(true);
            Trigger1 = true;
            Resting = true;
        }

        if (Trigger1 == true)
        {
            BuildUP += 0.18f * Time.deltaTime;
            CameraEffect.intensity = Mathf.Lerp(0.0f, 1.0f, BuildUP);
        }

        BuildUP2 += 0.05f * Time.deltaTime;
        CameraEffect.blur = Mathf.Lerp(0.0f, 1.0f, BuildUP2);
    }

   

    //closingTimer += Time.deltaTime / openingTime;
      //  vignetteEffect.intensity = Mathf.Lerp(0.43f , 1.0f , closingTimer);



}
