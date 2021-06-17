using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyObject enemy;
    
    protected GameObject player;

    private int fireCount = 0;
    private Vector2 origin;

    public virtual void Logic()
    {
        return;
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Logic();
    }

    private void OnEnable()
    {
        //transform.position = new Vector2(2, 15);
    }

}
