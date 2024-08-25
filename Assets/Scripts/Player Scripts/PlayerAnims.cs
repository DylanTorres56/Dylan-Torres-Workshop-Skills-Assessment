using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerController))]

public class PlayerAnims : MonoBehaviour
{
    [SerializeField] private PlayerController pC;
    [SerializeField] Animator m_Animator;
    [SerializeField] SpriteRenderer sR;
    [SerializeField] bool isGrounded, isMoving, isOnWall, isParrying;

    // Start is called before the first frame update
    void Start()
    {
        pC = gameObject.GetComponent<PlayerController>();
        m_Animator = gameObject.GetComponent<Animator>();
        sR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs used to switch between idle animation and moving animation.
        bool hasHorizontalInput = !Mathf.Approximately(pC.horizontalInput, 0f);
        bool movementCheck = hasHorizontalInput;

        isGrounded = pC.isAtopGround;
        isMoving = movementCheck;
        isOnWall = pC.WallCheck();

        switch (isGrounded) 
        {
            case true:
                m_Animator.SetBool("isGrounded", isGrounded);
                sR.flipX = pC.horizontalInput < 0;
                break;
            case false:
                m_Animator.SetBool("isGrounded", isGrounded);
                break;
        }
        
        switch (isMoving) 
        {            
            case true:
                m_Animator.SetBool("isMoving", isMoving);
                sR.flipX = pC.horizontalInput < 0;
                break;
            case false:
                m_Animator.SetBool("isMoving", isMoving);
                break;
        }

        switch (isOnWall) 
        {
            case true:
                m_Animator.SetBool("isOnWall", isOnWall);
                sR.flipX = pC.wallCheck < 0;
                break;
            case false:
                m_Animator.SetBool("isOnWall", isOnWall);
                break;
        }

    }
}
