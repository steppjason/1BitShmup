using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] int explosionCount = 0;
    
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject explosionParent;

    private static GameObject[] explosionPool;
    private static int seconds = 1;

    // Start is called before the first frame update
    void Start()
    {
        explosionPool = new GameObject[explosionCount];
        for(int i = 0; i < explosionPool.Length; i++){
            explosionPool[i] = Instantiate(explosion, new Vector3(-25,0,0), Quaternion.identity);
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

    public static IEnumerator SetInactive(GameObject explosion, GameObject source){
        yield return new WaitForSeconds(seconds);
        explosion.SetActive(false);
        source.SetActive(false);
    }
}
