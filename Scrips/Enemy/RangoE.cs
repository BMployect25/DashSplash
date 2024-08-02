using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoE : MonoBehaviour
{
    public Animator ani;
    public EnemyMovimiento enemigo;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
           ani.SetBool("Run", false);
           ani.SetBool("Attack", true);
           enemigo.atacando = true;
           GetComponent<BoxCollider2D>().enabled = false;            
        }
    }
}
