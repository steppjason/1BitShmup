using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    
    [SerializeField] GameObject parentProjectile;

    [SerializeField] int numberOfProjectiles = 30;
    
    [SerializeField] Projectile[] playerProjectile;
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] Vector3 projectileDirection = new Vector3(0,1,0);

    //[SerializeField] Projectile[] bulletList;

    private Projectile[,] bulletList;
    private int nextBullet = 0;

    [SerializeField] int numberOfPowerLevels = 1;

    [SerializeField] int currentPowerLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        bulletList = new Projectile[playerProjectile.Length, numberOfProjectiles];
        for(int i = 0; i < numberOfProjectiles; i++){
            for(int j = 0; j < playerProjectile.Length; j++){
                bulletList[j,i] = Instantiate(playerProjectile[j], new Vector3(-25,0,0), Quaternion.identity);
                bulletList[j,i].transform.parent = parentProjectile.transform;
                bulletList[j,i].gameObject.SetActive(false);
            }
        }
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
            var test = PowerupController.GetAvailble();
            test.gameObject.SetActive(true);
            test.gameObject.transform.position = new Vector3(0,0,0);
        }

    }

    void Fire(){

        switch(currentPowerLevel){
            case 0:
            case 2:
                SetNextBullet();
                bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
                bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
                break;
            case 1:
            case 3:
                for(int i = -1; i < 2; i++){
                    SetNextBullet();
                    bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
                    bulletList[currentPowerLevel, nextBullet].SetDirection(new Vector3(-0.25f * i,1,0));
                    bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
                }
                break;
            default:
                break;
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

    public int GetPowerLevel(){
        return currentPowerLevel;
    }

    public void SetPowerLevel(int powerLevel){
        currentPowerLevel = powerLevel;
        if(currentPowerLevel > 3){
            currentPowerLevel = 3;
        }
    }
}
