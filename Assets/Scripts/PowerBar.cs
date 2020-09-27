using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    public void UpdateDisplay(int index){
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }
}
