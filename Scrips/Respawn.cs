using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    public Animator animator;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
