using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] Collider2D hitbox;
    [SerializeField] Animator m_Animator;
    
    // Start is called before the first frame update
    void Start()
    {
        hitbox = gameObject.GetComponent<Collider2D>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_Animator.SetBool("hitsSurface", true); // When a missile hits another collider, play the burst animation.
        hitbox.enabled = false;
    }

}
