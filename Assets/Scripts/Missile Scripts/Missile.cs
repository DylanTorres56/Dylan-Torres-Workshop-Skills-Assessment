using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] Collider2D hitbox;
    [SerializeField] Animator m_Animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float xVel;
    [SerializeField] AudioSource missileSFX; // Sound that plays when missile explodes.
    [SerializeField] AudioSource parrySFX; // Sound that plays when parry is successful.

    private enum MissileState 
    {
        Intact,
        Burst
    }
    [SerializeField] private MissileState stateOfMissile;

    [Header("HITSTOP REFERENCES")]    
    //[SerializeField] ScreenHitStop sHS; // Script that causes hitstop upon a successful parry.
    [Range(0.12f, 0.5f)] [SerializeField] float missileHSD; // Hit Stop Duration variable of the missile.

    // Start is called before the first frame update
    void Start()
    {
        hitbox = gameObject.GetComponent<Collider2D>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        stateOfMissile = MissileState.Intact;
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        if (stateOfMissile != MissileState.Burst)
        {
            rb.velocity = new Vector2(xVel, 0f);
        }
        else 
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_Animator.SetBool("hitsSurface", true); // When a missile hits another collider, play the burst animation.
        stateOfMissile = MissileState.Burst;
        hitbox.enabled = false;
        missileSFX.Play();

        if (collision.CompareTag("Parrying Player"))
        {
            parrySFX.Play();
            FindObjectOfType<ScreenHitStop>().HitStop(missileHSD);            
        }

        Invoke("DeleteMissile", 0.5f);

    }

    void DeleteMissile() 
    {
        Destroy(this.gameObject);
    }

}
