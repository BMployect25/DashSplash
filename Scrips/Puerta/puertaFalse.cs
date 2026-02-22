using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaFalse : MonoBehaviour
{
    private bool playerVivo;
    public Hud hud;

    private void OnCollisionEnter2D( Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            PlayerContoler playerScr = Collision.gameObject.GetComponent<PlayerContoler>();
            playerScr.Damage(1);
            playerVivo = !playerScr.muerte;

            if (playerVivo == false)
            {
                Destroy(Collision.gameObject);
            }
        }
    }

    void Awake()
    {
        if (hud == null)
            hud = FindObjectOfType<Hud>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hud?.QuitarVida();
        }
    }
}
