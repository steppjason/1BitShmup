using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private const float DRONE_ROTATION = 90f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, (Mathf.Atan2(player.transform.position.y - transform.position.y, 
            player.transform.position.x - transform.position.x) * Mathf.Rad2Deg) + DRONE_ROTATION);

        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
