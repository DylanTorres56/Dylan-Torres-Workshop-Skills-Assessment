using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerHitbox; // The hitbox of the player.
    [SerializeField] GameManager gM; // Game Manager that holds data for screen hitstop and parry counter UI text.
    [SerializeField] ScreenHitStop sHS; // Script that causes hitstop upon a successful parry.
    public int parriesLanded;

    // Start is called before the first frame update
    void Start()
    {
        playerHitbox = transform.GetComponent<BoxCollider2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParryActivate();
        }
    }

    void ParryActivate() 
    {        
        playerHitbox.tag = "Parrying Player";
        Invoke(nameof(ParryDeactivate), 0.2f);
    }

    void ParryDeactivate() 
    {
        playerHitbox.tag = "Player";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard") && playerHitbox.CompareTag("Parrying Player")) 
        {
            parriesLanded += 1;
            gM.UpdateParryCounter();
        }
    }

}
