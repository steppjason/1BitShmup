using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player"){
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<Player>().SetPowerLevel(collision.gameObject.GetComponent<Player>().GetPowerLevel() + 1);
        }
    }
}
