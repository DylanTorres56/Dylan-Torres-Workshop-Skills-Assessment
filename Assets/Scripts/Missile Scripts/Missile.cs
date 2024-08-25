using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] Collider2D hitbox;
    [SerializeField] Animator m_Animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float xVel; 

    private enum MissileState 
    {
        Intact,
        Burst
    }
    [SerializeField] private MissileState stateOfMissile;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = gameObject.GetComponent<Collider2D>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        stateOfMissile = MissileState.Intact;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }



}
