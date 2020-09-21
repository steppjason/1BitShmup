using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 0;



    [SerializeField] Projectile enemyProjectile;

    [SerializeField] GameObject parentProjectile;

    [SerializeField] int numberOfProjectiles = 20;
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] Vector3 projectileDirection = new Vector3(0,-1,0);


    private Projectile[] bulletList;
    private int nextBullet = 0;

    private int fireCount = 0;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        bulletList = new Projectile[numberOfProjectiles];
        for(int i = 0; i < numberOfProjectiles; i++){

                bulletList[i] = Instantiate(enemyProjectile, new Vector3(-25,0,0), Quaternion.identity);
                bulletList[i].transform.parent = parentProjectile.transform;
                bulletList[i].gameObject.SetActive(false);
            
        }
        
        player = GameObject.Find("Player");

        InvokeRepeating("Fire", 3f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy();
    }

    private void Destroy(){
        gameObject.SetActive(false);

        var explosion = ExplosionController.GetAvailble();
        explosion.gameObject.SetActive(true);
        explosion.gameObject.transform.position = transform.position;
    }

    private void Fire(){

        SetNextBullet();
        bulletList[nextBullet].transform.position = transform.position;
        bulletList[nextBullet].SetDirection((GameObject.Find("Player").transform.position - transform.position).normalized);
        bulletList[nextBullet].gameObject.SetActive(true);
 
    }


    void SetNextBullet(){
        for(int i = 0; i < bulletList.Length; i++){
            if(!bulletList[i].gameObject.activeInHierarchy){
                nextBullet = i;
                return;
            }
        }
    }

    
}
