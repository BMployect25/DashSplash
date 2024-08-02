using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
