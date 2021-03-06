﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [SerializeField] EnemyObject enemy;
    [SerializeField] int health = 1;

    // Start is called before the first frame update
    private void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int dmg){
        health -= dmg;
        if(health <= 0){
            Kill();
        }
        
    }

    public void Kill(){
        gameObject.SetActive(false);

        if(gameObject.name == "Player"){
            gameObject.GetComponent<Player>().OnDeath();
        }

        var explosion = ExplosionController.GetAvailble();
        explosion.gameObject.SetActive(true);
        explosion.gameObject.transform.position = transform.position;
    }

    
}
