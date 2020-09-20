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
        var test = ExplosionController.GetAvailble();
        test.gameObject.SetActive(true);
        test.gameObject.transform.position = transform.position;
        StartCoroutine(ExplosionController.SetInactive(test));
        gameObject.SetActive(false);
    }
}
