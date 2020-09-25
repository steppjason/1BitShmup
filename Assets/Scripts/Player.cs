using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] float moveSpeed = 1f;


    [SerializeField] GameObject enemy;

    [SerializeField] Projectile[] playerProjectiles;
    [SerializeField] int numberOfProjectiles = 20;
    [SerializeField] GameObject parentProjectile;
    [SerializeField] int currentPowerLevel = 0;

    private Projectile[,] bulletList;
    private int nextBullet = 0;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateBullets();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0){
            transform.position = new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y);
        }

        if(Input.GetAxisRaw("Vertical") != 0){
            transform.position = new Vector2(transform.position.x, transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Fire1")){
            Fire();
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

    void Fire(){

        switch(currentPowerLevel){
            
            //Single shot
            case 0:
            case 2:
                SetNextBullet();
                bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
                bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
                break;

            //Spread shot
            case 1:
            case 3:
                for(int i = -1; i < 2; i++){
                    SetNextBullet();
                    bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
                    bulletList[currentPowerLevel, nextBullet].SetDirection(new Vector3(-0.25f * i,1,0));
                    bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
                }
                break;

            //Default to single shot
            default:
                SetNextBullet();
                bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
                bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
                break;
        }

    }


    public int GetPowerLevel(){
        return currentPowerLevel;
    }

    public void SetPowerLevel(int powerLevel){
        currentPowerLevel = powerLevel;
        if(currentPowerLevel > playerProjectiles.Length - 1){
            currentPowerLevel = playerProjectiles.Length - 1;
        }
    }

    private void InstantiateBullets(){
        bulletList = new Projectile[playerProjectiles.Length, numberOfProjectiles];
        for(int i = 0; i < numberOfProjectiles; i++){
            for(int j = 0; j < playerProjectiles.Length; j++){
                bulletList[j,i] = Instantiate(playerProjectiles[j], new Vector3(-25,0,0), Quaternion.identity);
                bulletList[j,i].transform.parent = parentProjectile.transform;
                bulletList[j,i].gameObject.SetActive(false);
            }
        }
    }

    void SetNextBullet(){
        for(int i = 0; i < bulletList.Length; i++){
            if(!bulletList[currentPowerLevel, i].gameObject.activeInHierarchy){
                nextBullet = i;
                return;
            }
        }
    }

}
