using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class ScoreTaken : MonoBehaviour {

    public Text ScoreText;
    private int ScoreNumber;
    private VignetteAndChromaticAberration CameraEffect;
    float buildUp;
    public GameObject Canvas;
    public GameObject Sleep;
    public GameObject WakeUp;
    float Counter;


    // Use this for initialization
    void Start () {
        CameraEffect = FindObjectOfType<Camera>().GetComponent<VignetteAndChromaticAberration>();
        Canvas.SetActive(false);
        Sleep.SetActive(true);
        WakeUp.SetActive(false);
        CameraEffect = FindObjectOfType<Camera>().GetComponent<VignetteAndChromaticAberration>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ScoreText != null)
        {
            ScoreNumber = PlayerPrefs.GetInt("Score");
            ScoreText.text = "Total Coins Collected: " + ScoreNumber + " / 7";
        }

        NewMethod();

        if (Counter < 20)
        {
            Counter += 1 * Time.deltaTime;

            if(Counter> 2.5 && Counter < 3.5)
            {
                Sleep.SetActive(false);
                WakeUp.SetActive(true);
            }
            if (Counter > 5)
            {
                Canvas.SetActive(true);

            }



        }


    }

    private void NewMethod()
    {
        buildUp += 0.5f * Time.deltaTime;
        CameraEffect.intensity = Mathf.Lerp(1.0f, 0.0f, buildUp);
    }
}
