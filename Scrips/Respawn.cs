using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Respawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    public Animator animator;
    
    public event EventHandler MuerteJugador;

    [SerializeField] private GameOver gameOver;

    void Start()
    {
        life = hearts.Length;
    }

    private void CheckLife()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);

        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");
        }
         else if (life < 4)
        {
            Destroy(hearts[3].gameObject);
            animator.Play("Hit");
        }
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
    }
}
