using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController: MonoBehaviour
{
    [SerializeField] int powerupCount = 5;
    [SerializeField] Powerup powerup;
    [SerializeField] GameObject powerupParent;

    private Vector3 defaultPos = new Vector3(-100,0,0);
    private static Powerup[] powerupPool;

    void Start()
    {
        CreatePool();
    }

    private void CreatePool(){
        powerupPool = new Powerup[powerupCount];
        for(int i = 0; i < powerupPool.Length; i++){
            powerupPool[i] = Instantiate(powerup, defaultPos, Quaternion.identity);
            powerupPool[i].transform.parent = powerupParent.transform;
            powerupPool[i].gameObject.SetActive(false);
        }
    }

    public static Powerup GetAvailble(){
        for(int i = 0; i < powerupPool.Length; i++){
            if(!powerupPool[i].gameObject.activeInHierarchy){
                return powerupPool[i];
            }
        }
        return null;
    }
}
