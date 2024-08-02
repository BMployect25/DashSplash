using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemys : MonoBehaviour
{
   public int damage = 1;

    void OnTriggerEnter2D(Collider2D coll)
    {
       if (coll.CompareTag("Player"))
        {
            print("Sufres Daño");
        }
    }

}