using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [SerializeField] private BoxCollider2D playerHitbox;

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
        Invoke("ParryDeactivate", 0.2f);
    }

    void ParryDeactivate() 
    {
        playerHitbox.tag = "Player";
    }
}
