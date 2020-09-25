using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Projectile[] projectiles;
    [SerializeField] int numberOfProjectiles = 20;
    [SerializeField] GameObject parentProjectile;
    [SerializeField] int currentPowerLevel = 0;

    private Projectile[,] bulletList;
    private int nextBullet = 0;

    private void Start() {
        InstantiateBullets();
    }

    private void InstantiateBullets(){
        bulletList = new Projectile[projectiles.Length, numberOfProjectiles];
        for(int i = 0; i < numberOfProjectiles; i++){
            for(int j = 0; j < projectiles.Length; j++){
                bulletList[j,i] = Instantiate(projectiles[j], new Vector3(-25,0,0), Quaternion.identity);
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

    public void Fire(){

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

    public void Fire(GameObject target){

        switch(currentPowerLevel){
            
            //Single shot
            case 0:
            case 2:
                SetNextBullet();
                bulletList[currentPowerLevel, nextBullet].transform.position = transform.position;
                bulletList[currentPowerLevel, nextBullet].SetDirection((target.transform.position - transform.position).normalized);
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
                bulletList[currentPowerLevel, nextBullet].SetDirection((target.transform.position - transform.position).normalized);
                bulletList[currentPowerLevel, nextBullet].gameObject.SetActive(true);
                break;
        }

    }

    public int GetPowerLevel(){
        return currentPowerLevel;
    }

    public void SetPowerLevel(int powerLevel){
        currentPowerLevel = powerLevel;
        if(currentPowerLevel > projectiles.Length - 1){
            currentPowerLevel = projectiles.Length - 1;
        }
    }
}
