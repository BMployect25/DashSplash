using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;


public class Hud : MonoBehaviour
{
    public TextMeshProUGUI vidaTexto;
    public GameObject[] vidas;
    public GameObject muerto;
    int vidasActuales;

    // nuevo: guarda el último valor de puntos para detectar decrementos
    int lastPuntos = -1;

    void Start()
    {
        vidasActuales = vidas != null ? vidas.Length : 0;
        if (muerto != null) muerto.SetActive(false);
        ActualizarTextoVidas();

        // inicializa lastPuntos si existe GameManager
        if (GameManager.Instance != null)
            lastPuntos = GameManager.Instance.puntos;
    }

    void Update()
    {
        // si hay GameManager, detecta si los puntos bajaron
        if (GameManager.Instance != null)
        {
            int currentPuntos = GameManager.Instance.puntos;
            // actualiza el texto de puntos (si lo quieres mostrar)
            if (vidaTexto != null)
                vidaTexto.text = currentPuntos.ToString();

            if (lastPuntos == -1) lastPuntos = currentPuntos;

            if (currentPuntos < lastPuntos)
            {
                int diff = lastPuntos - currentPuntos;
                for (int i = 0; i < diff; i++)
                    QuitarVida();
            }

            lastPuntos = currentPuntos;
        }
    }

    public void Actualizarvida(int puntos)
    {
        vidaTexto.text = puntos.ToString();
    }
    
    public void DesactivarVida(int vidasRestantes)
    {
        if (vidasRestantes >= 0 && vidasRestantes < vidas.Length)
        {
            Destroy(vidas[vidasRestantes]);
        }
    }

    public void QuitarVida()
    {
        if (vidas == null || vidas.Length == 0) return;

        // Busca la última vida no destruida en el array (de derecha a izquierda)
        for (int i = vidas.Length - 1; i >= 0; i--)
        {
            if (vidas[i] != null)
            {
                Destroy(vidas[i]);
                vidas[i] = null; // marca como eliminada
                vidasActuales = Mathf.Max(0, vidasActuales - 1);
                ActualizarTextoVidas();

                if (vidasActuales == 0 && muerto != null)
                {
                    muerto.SetActive(true);
                }
                break;
            }
        }
    }

    void ActualizarTextoVidas()
    {
        if (vidaTexto != null)
            vidaTexto.text = vidasActuales.ToString();
    }

}
