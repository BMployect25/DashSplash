using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;   
    public Animator animator; 
    public int Lifes = 1;

    private void Start()
    {
    }

    public void TomarDaño(float daño)
    {
      vida -= daño;

      if(vida <= 0)
      {
        Muerte();
      }
    }

     public void PlayerDamaged()
    {
      animator.Play("Hit");
    }


    private void Muerte()
    {
      animator.SetTrigger("Muerte");
    }


}
