using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int fireCount = 0;
    private Vector2 origin;
    


    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //InvokeRepeating("Fire", 3f, 0.7f);
        //origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnEnable() {
        transform.position = new Vector2(2,15);
    }

    void Fire(){
        if(player.activeInHierarchy && gameObject.activeInHierarchy){
            gameObject.GetComponent<Weapon>().Fire(player);
        }
    }
}
