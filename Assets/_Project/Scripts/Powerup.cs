﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] Vector3 direction = new Vector3(0,-1,0);

    private GameObject powerBar;

    private void Start() {
        powerBar = GameObject.Find("PowerBar");
    }

    private void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player"){
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<Weapon>().SetPowerLevel(collision.gameObject.GetComponent<Weapon>().GetPowerLevel() + 1);
            powerBar.GetComponent<PowerBar>().UpdateDisplay(collision.gameObject.GetComponent<Weapon>().GetPowerLevel());
        }

        if(collision.gameObject.tag == "Bounds"){
            this.gameObject.SetActive(false);
        }
    }
}
