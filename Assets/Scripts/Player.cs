using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    public float pixPerUnit = 16;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0){
            transform.position = new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y);
        }

        if(Input.GetAxisRaw("Vertical") != 0){
            transform.position = new Vector2(transform.position.x, transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        }

    }
}
