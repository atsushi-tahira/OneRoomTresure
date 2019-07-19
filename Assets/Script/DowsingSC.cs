using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowsingSC : MonoBehaviour {

    public float red_interval = 0.3f;
    public static bool red_bool = false;
    public static bool dow_bool = true;
    void Start () {
    }


    IEnumerator RedBlink(Material hand_mat,AudioSource hand_se)
    {
        while (red_bool && dow_bool) {
            dow_bool = false;
            hand_se.pitch = 1.0f;
            hand_se.Play();
            hand_mat.color = Color.red;
            yield return new WaitForSeconds(red_interval);
            hand_mat.color = Color.white;
            yield return new WaitForSeconds(red_interval);
            dow_bool = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "dowsing")
        {
            red_bool = true;
            GreenDowsingSC.Green_bool = false;
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "dowsing")
        {
            var hand_mat = other.gameObject.GetComponent<Renderer>().material;
            var hand_se = other.gameObject.GetComponent<AudioSource>();
            StartCoroutine(RedBlink(hand_mat,hand_se));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "dowsing")
        {
            red_bool = false;
            GreenDowsingSC.Green_bool = true;
        }
    }
}
