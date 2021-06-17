using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] GameObject enemy;

    private GameObject powerBar;
    private Vector3 direction;

    private DestructibleObject destructible;


    // Start is called before the first frame update
    void Start()
    {
        powerBar = GameObject.Find("PowerBar");
        destructible = gameObject.GetComponent<DestructibleObject>();
    }

    // Update is called once per frame
    void Update()
    {

        //Get normalized direction vector and move the player
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);        
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
  

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

    public void OnDeath(){
        powerBar.GetComponent<PowerBar>().UpdateDisplay(0);
        gameObject.GetComponent<Weapon>().SetPowerLevel(0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Enemy>()){
            destructible.Kill();
        }
    }

}
