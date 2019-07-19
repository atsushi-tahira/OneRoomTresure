using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDowsingSC : MonoBehaviour {

    public float green_interval = 0.6f;
    public static bool Green_bool = false;

    void Start()
    {
        //dowSC = GameObject.Find("RedDowsing").GetComponent<DowsingSC>();
    }


    IEnumerator GreenBlink(Material hand_mat,AudioSource hand_se)
    {
        //while (green_bool)
        while (Green_bool && DowsingSC.dow_bool)
        //while (green_bool && !dowSC.red_bool && dowSC.dow_bool)
        {
            DowsingSC.dow_bool = false;
            hand_se.pitch = 0.7f;
            hand_se.Play();
            hand_mat.color = Color.green;
            yield return new WaitForSeconds(green_interval);
            hand_mat.color = Color.white;
            yield return new WaitForSeconds(green_interval);
            DowsingSC.dow_bool = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "dowsing")
        {
            Green_bool = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "dowsing")
        {
            var hand_mat = other.gameObject.GetComponent<Renderer>().material;
            var hand_se = other.gameObject.GetComponent<AudioSource>();
            StartCoroutine(GreenBlink(hand_mat,hand_se));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "dowsing")
        {
            Green_bool = false;
        }
    }
}
