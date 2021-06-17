using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Enemy")]
public class EnemyObject : ScriptableObject
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float orientationRotation;
    
    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }
    }

    public float OrientationRotation
    {
        get
        {
            return orientationRotation;
        }
    }
}
