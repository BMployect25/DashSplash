using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovimiento : MonoBehaviour
{   [SerializeField] private GameObject padre;

    public Animator ani;
    public GameObject target;
    public bool atacando;
    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;


    bool invincible;
    float InvincibilityTime = 0.8f;
    float blinkTime = 0.1f;

    public float knockbackStrength = 1f;
    float knockbackTime = 0.5f;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator Invincibility()
    {
        invincible = true;
        float auxTime = InvincibilityTime;

        while (auxTime > 0)
        {
            yield return new WaitForSeconds(blinkTime);
            auxTime -= blinkTime;
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
        spriteRenderer.enabled = true;
        invincible = false;
    }
    IEnumerator Knockback(Vector3 hitPosition)
    {
        if(knockbackStrength <= 0) yield break;

        rigidBody.velocity = (transform.position-hitPosition).normalized * knockbackStrength;
        yield return new WaitForSeconds(knockbackTime);
        rigidBody.velocity = Vector3.zero;
    }


    // Start is called before the first frame update

    public void Final_Ani()
    {
        ani.SetBool("Attack", false);
        atacando = false;     
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            collision.transform.GetComponent<Respawn>().PlayerDamaged();
        }
    }

    public void Muere()
    {
        Destroy(padre);
    }
}
