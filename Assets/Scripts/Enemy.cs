using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 0;
    [SerializeField] Projectile projectile;

    

    // Start is called before the first frame update
    void Start()
    {
        
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
}
