using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerContoler : MonoBehaviour
{
    [SerializeField] private float velocidad;
    
    private Rigidbody2D Rig;
    private Animator animator;
    private SpriteRenderer spritePersonaje;
    public bool isGrounded;
    public float speed;
    Vector2 direction;

    public int Daño;
    public int vida = 4;

    void Update()
    {
        Attack();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
       if (coll.CompareTag("Enemy"))
        {
            print("haces Daño");
        }
        if (coll.gameObject.tag == "Enemigo")
        {
            vida-=1;
        }
    }



    private void Awake()
    {
        Rig = GetComponent<Rigidbody2D>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Attack",true);
        }
        else
        {
            animator.SetBool("Attack",false);
        }
    }


    private void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Rig.velocity = new Vector2(hor, ver) * velocidad;

        if (hor != 0 || ver != 0)
        {
            animator.SetFloat("Horizontal", hor);
            animator.SetFloat("Vertical", ver);
            animator.SetFloat("Speed", 1);

            Vector3 direction = (Vector3.up * ver + Vector3.right * hor).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed", 0);

        }
    }


    
}


    


