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
    [SerializeField] bool isGrounded, isMoving, isOnWall, isParrying;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs used to switch between idle animation and moving animation.
        bool hasHorizontalInput = !Mathf.Approximately(pC.horizontalInput, 0f);
        bool movementCheck = hasHorizontalInput;

        isMoving = hasHorizontalInput;

        if (isGrounded) 
        {
            m_Animator.SetBool("isMoving", isMoving);
        }
    }
}
