using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_Enemigo : MonoBehaviour
{
    public int Vida;
    public float tiempo_brillo;
    public SpriteRenderer[] spr;
    public bool cambio;
    public Color[] color_;
    public float speed_shine;
    public float cronometro;

    public void Brillo()
    {
        if(cronometro > 0)
        {
            cronometro -= 1 * Time.deltaTime;
            spr[1].sprite = spr[0].sprite;
            tiempo_brillo += speed_shine * Time.deltaTime;

            switch (cambio)
            {
                
                case true:
                    spr[1].color = color_[0];
                    break;
                case false:
                    spr[1].color = color_[1];
                    break;
            }

            if (tiempo_brillo > 1)
            {
                cambio = !cambio;
                tiempo_brillo = 0;
            }
        }

        else
        {
            cronometro = 0;
            spr[1].color = color_[0];
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Brillo();
    }
}
