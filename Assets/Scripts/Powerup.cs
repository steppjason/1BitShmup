using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] Vector3 direction = new Vector3(0,-1,0);

    private void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player"){
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<Player>().SetPowerLevel(collision.gameObject.GetComponent<Player>().GetPowerLevel() + 1);
        }

        if(collision.gameObject.tag == "Bounds"){
            this.gameObject.SetActive(false);
        }
    }
}
