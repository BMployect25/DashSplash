using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour
{

    public float velocidadEnemigo = 1f;
    public Transform Player;
    public Animator ani;
    private bool objetivoDetectado;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();   
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            collision.transform.GetComponent<Respawn>().PlayerDamaged();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, Player.transform.position.y),velocidadEnemigo * Time.deltaTime);
        
    }

    public void Final_Ani()
    {
        ani.SetBool("Attack", false);
    }
}
