using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSC : MonoBehaviour {

    TextMesh textTimer;
    public float timeLimit = 60f;
    int seconds = 3;
    public GameObject roomLight;
    public int jewelryCount;

    public GameObject dowsingHand;
    bool gameclear = false;

	// Use this for initialization
	void Start () {
        textTimer = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

        timeLimit -= Time.deltaTime;
        seconds = seconds > 0 ? (jewelryCount >= 7 ? seconds :(int)timeLimit) : 0;
        textTimer.text = "Timer\n" + seconds;

        if (seconds == 0)
        {
            textTimer.text = "Timer\n" + seconds + "\nGameOver";
            textTimer.color = Color.white;
            roomLight.GetComponent<Light>().enabled = false;
        }

        if (jewelryCount == 7)
        {
            textTimer.text = "Timer\n" + seconds + "\nGameClear!!";
            if (!gameclear)
            {
                gameclear = true;
                GetComponent<AudioSource>().Play();
                GameObject.Find("BGMPlayer").GetComponent<AudioSource>().mute = true;
            }
        }
    }

    public void JewelryCount()
    {
        jewelryCount++;
        Debug.Log("jewelryCount = " + jewelryCount);
        GreenDowsingSC.Green_bool = false;
        DowsingSC.red_bool = false;
        DowsingSC.dow_bool = true;
        dowsingHand.GetComponent<Renderer>().material.color = Color.white;
    }


}
