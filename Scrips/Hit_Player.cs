using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Player : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            coll.GetComponent<Vida_Enemigo>().Vida -= damage;
            coll.GetComponent<Vida_Enemigo>().cronometro = 2f;
        }
    }
    
}
