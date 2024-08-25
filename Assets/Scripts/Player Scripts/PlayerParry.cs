using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerHitbox; // The hitbox of the player.    

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


}
