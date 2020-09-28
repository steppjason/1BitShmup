using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotSpeed = 2f;

    private const float DRONE_ROTATION = 90f;

    private GameObject player;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){

        if(player.activeInHierarchy){

            //Get the player's current position
            target = player.transform.position;

            //Use Slerp to rotate towards the player's position
            transform.rotation = Quaternion.Slerp(
                    transform.rotation, 
                    Quaternion.Euler(new Vector3(0, 0, 
                        Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg + DRONE_ROTATION)), 
                    rotSpeed * Time.deltaTime);
        }

        transform.position += transform.rotation * Vector3.down * speed * Time.deltaTime;
    }


    private void RotateGameObject(Vector3 target, float RotationSpeed, float offset)
    {
        //https://www.youtube.com/watch?v=mKLp-2iseDc
        //get the direction of the other object from current object
        Vector3 dir = target - transform.position;
        //get the angle from current direction facing to desired target
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //set the angle into a quaternion + sprite offset depending on initial sprite facing direction
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        //Roatate current game object to face the target using a slerp function which adds some smoothing to the move
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }

   
}
