﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Invoke("GravityOff", 2);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }
    }

    void GravityOff()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
