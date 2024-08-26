using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerController))]

public class PlayerAnims : MonoBehaviour
{
    [SerializeField] private PlayerController pC;
    [SerializeField] private PlayerParry pP;
    [SerializeField] private GameManager gM;
    [SerializeField] Animator m_Animator;
    [SerializeField] SpriteRenderer sR;
    public bool isGrounded, isMoving, isOnWall, isParrying;

    [Header("GM References")]
    public string characterState;

    [Header("SFX")]
    [SerializeField] AudioSource runSFX; // Run SFX

    // Start is called before the first frame update
    void Start()
    {
        pC = gameObject.GetComponent<PlayerController>();
        m_Animator = gameObject.GetComponent<Animator>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        pP = gameObject.GetComponent<PlayerParry>();
        gM = GameObject.FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
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
        isParrying = gameObject.CompareTag("Parrying Player");

        switch (isGrounded) 
        {
            case true:
                m_Animator.SetBool("isGrounded", isGrounded);
                sR.flipX = pC.horizontalInput < 0;

                gM.UpdateCSI();

                break;
            case false:
                m_Animator.SetBool("isGrounded", isGrounded);
                if (runSFX.isPlaying) 
                {
                    runSFX.Stop();
                }

                gM.UpdateCSI();

                break;
        }
        
        switch (isMoving) 
        {            
            case true:
                m_Animator.SetBool("isMoving", isMoving);
                sR.flipX = pC.horizontalInput < 0;
                if (m_Animator.GetBool("isGrounded") && !m_Animator.GetBool("isOnWall") && !runSFX.isPlaying)
                {
                    runSFX.Play();
                    characterState = "Moving";
                }

                gM.UpdateCSI();
                
                break;
            case false:
                m_Animator.SetBool("isMoving", isMoving);
                runSFX.Stop();
                characterState = "Idle";

                gM.UpdateCSI();

                break;
        }

        switch (isOnWall) 
        {
            case true:
                m_Animator.SetBool("isOnWall", isOnWall);
                sR.flipX = pC.wallCheck < 0;
                runSFX.Stop();

                gM.UpdateCSI();

                break;
            case false:
                m_Animator.SetBool("isOnWall", isOnWall);

                gM.UpdateCSI();

                break;
        }

        switch (isParrying) 
        {
            case true:
                m_Animator.SetBool("isParrying", isParrying);
                runSFX.Stop();
                characterState = "Parrying";

                gM.UpdateCSI();

                break;
            case false:
                m_Animator.SetBool("isParrying", isParrying);

                gM.UpdateCSI();

                break;
        }

    }
}
