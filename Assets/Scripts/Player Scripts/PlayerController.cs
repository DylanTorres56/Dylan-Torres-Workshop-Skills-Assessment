using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement")]
    public Rigidbody2D rb; // Player's 2D RB.
    [SerializeField] private float movementSpeed; // Player's movement speed.
    public float horizontalInput; // Player's horizontal input.
    public float jumpHeight; // Controls the height of the player's jump.

    [Header("Ground Check")]
    public LayerMask groundMask; // Determines which layer is a ground layer.    
    [SerializeField] private Vector2 posOfGCB; // Position of Ground Check Box.
    [SerializeField] private Vector2 dimsOfGCB; // Dimensions of Ground Check Box.
    [SerializeField] float yGizmoDisplacement; // Edits the y-axis of the player's ground checker gizmo.
    public bool isAtopGround; // Visually displays in the editor if the player is grounded.

    [Header("Wall Check")]
    public float wallCheck; // Visually displays if player is holding the wall; +1 is right wall and -1 is left wall.
    [SerializeField] private Vector2 posOfLWCB; // Position of Left Wall Check Box.
    [SerializeField] private Vector2 posOfRWCB; // Position of Right Wall Check Box.
    [SerializeField] private Vector2 dimsOfWCB; // Dimensions of Wall Check Box.
    [SerializeField] float xGizmoDisplacement; // Edits the x-axis of the player's wall checker gizmo.

    public bool GroundCheck() // Checks if the player is grounded.
    {
        posOfGCB = new Vector2(transform.position.x, transform.position.y - yGizmoDisplacement);
        dimsOfGCB = new Vector2(1f, 0.2f);
        isAtopGround = Physics2D.OverlapBox(posOfGCB, dimsOfGCB, 0f, groundMask);
        return isAtopGround;
    }

    public bool WallCheck() 
    {
        posOfLWCB = new Vector2(transform.position.x - xGizmoDisplacement, transform.position.y);
        posOfRWCB = new Vector2(transform.position.x + xGizmoDisplacement, transform.position.y);
        dimsOfWCB = new Vector2(0.2f, 2.4f);

        if (Physics2D.OverlapBox(posOfLWCB, dimsOfWCB, 0f, groundMask))
        {
            wallCheck = -1;
        }
        else if (Physics2D.OverlapBox(posOfRWCB, dimsOfWCB, 0f, groundMask))
        {
            wallCheck = 1;
        }
        else 
        {
            wallCheck = 0;
        }
        return wallCheck != 0;
    }

    // Awake is called on the first active frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput(); // Inputs are counted by frame.
        GroundCheck(); // Checks if player is grounded.
        WallCheck(); // Checks if player is holding a wall.
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        PlayerMovement(); // Movement is controlled by physics, so it goes in FixedUpdate.
    }

    // PlayerInput detects when players press inputs
    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Sets the player's horizontal move input.
        
        // If Spacebar is pressed, call code to jump.
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck()) 
        {
            Jump();
        }
    }

    // PlayerMovement detects when players are moving and not parrying.
    void PlayerMovement()
    {
        if (transform.tag == "Player") 
        {
            transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * movementSpeed);
        }
    }

    // Gizmos will be drawn to test the ground and wall checkers
    private void OnDrawGizmosSelected()
    {        
        // Floor Checker Gizmo:
        Gizmos.color = Color.green;
        Gizmos.DrawCube(posOfGCB, dimsOfGCB);

        // Wall Checker Gizmos:
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(posOfLWCB, dimsOfWCB); // Left Wall
        Gizmos.DrawCube(posOfRWCB, dimsOfWCB); // Right Wall
    }

    void Jump() 
    {
        rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
    }
}