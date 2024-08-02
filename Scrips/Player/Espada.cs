using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public int damage = 1; 
    private BoxCollider2D colEspada;
    private Animator animator;
    public bool isGrounded;

    private void Awake()
    {
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Enemy"))
        {
            Destroy(otro.gameObject);
        }
    }

    private void Attack()
    {
        animator.Play("Attack");
        GetComponent<Collider2D>().enabled = true;
        Invoke("DisableAttack",0.5f);
    }

    private void DisableAttack()
    {
        GetComponent<Collider2D>().enabled = false;
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("Muere");
        }
    }
    
}


