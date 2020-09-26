using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0){
            transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if(Input.GetAxisRaw("Vertical") != 0){
            transform.position = new Vector3(transform.position.x, transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, transform.position.z);
        }

        if(Input.GetButtonDown("Fire1")){
            gameObject.GetComponent<Weapon>().Fire();
        }

        if(Input.GetButtonDown("Fire2")){
            enemy.SetActive(true);
            enemy.transform.position = new Vector3(0,5,0);
        }

        if(Input.GetButtonDown("Jump")){
            var powerup = PowerupController.GetAvailble();
            powerup.gameObject.SetActive(true);
            powerup.transform.position = new Vector3(Random.Range(-10,10),10,0);
        }
        

    }

}
