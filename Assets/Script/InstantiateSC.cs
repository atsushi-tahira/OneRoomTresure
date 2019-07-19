using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSC : MonoBehaviour {

    [SerializeField]
    private GameObject jewelry;
    Vector3 inst_trans;
    public TimerSC timerSC;

	void Start () {
        inst_trans = this.gameObject.transform.position;
	}

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "hand" || collision.gameObject.tag == "dowsing")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(this.gameObject);
                Instantiate(jewelry, inst_trans, Quaternion.identity);
                timerSC.JewelryCount();
            }

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                Debug.Log("右人差し指トリガーを押した");
                Destroy(this.gameObject);
                Instantiate(jewelry, inst_trans, Quaternion.identity);
                timerSC.JewelryCount();
            }
        }
    }
}
