using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] int explosionCount = 10;
    
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject explosionParent;

    private Vector3 defaultPos = new Vector3(-100,0,0);
    private static GameObject[] explosionPool;
    private static int seconds = 1;

    // Start is called before the first frame update
    void Start(){
        InstantiateExplosions();
    }

    private void InstantiateExplosions(){
        explosionPool = new GameObject[explosionCount];
        for(int i = 0; i < explosionPool.Length; i++){
            explosionPool[i] = Instantiate(explosion, defaultPos, Quaternion.identity);
            explosionPool[i].transform.parent = explosionParent.transform;
            explosionPool[i].gameObject.SetActive(false);
        }
    }

    public static GameObject GetAvailble(){

        for(int i = 0; i < explosionPool.Length; i++){
            if(!explosionPool[i].gameObject.activeInHierarchy){
                return explosionPool[i];
            }
        }
        return null;
    }

    
}
