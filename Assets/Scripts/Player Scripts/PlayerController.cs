using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] private float movementSpeed; // Player's movement speed.
    public float horizontalInput; // Player's horizontal input.

    [Header("Ground & Wall Checks")]
    public bool groundCheck; // Checks if the player is grounded.
    public Vector2 posOfGCB; // Position of Ground Check Box.
    public Vector2 dimsOfGCB; // Dimensions of Ground Check Box.

    public float wallCheck; // Checks if player is holding the wall; +1 is right wall and -1 is left wall.
    public Vector2 posOfWCB; // Position of Wall Check Box.
    public Vector2 dimsOfWCB; // Dimensions of Wall Check Box.

    [SerializeField] float yGizmoDisplacement; // Edits the y-axis of the player's ground checker gizmo.

    // Start is called before the first frame update
    void Start()
    {
        posOfGCB = new Vector2(transform.position.x, transform.position.y - yGizmoDisplacement);
        dimsOfGCB = new Vector2(1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput(); // Inputs are counted by frame.
        groundCheck = Physics2D.OverlapBox(posOfGCB, dimsOfGCB, 0f);
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
    }

    // PlayerMovement detects when players are moving
    void PlayerMovement()
    {
        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * movementSpeed);
    }

    // Gizmos will be drawn to test the ground checker
    private void OnDrawGizmos()
    {        
        Gizmos.color = Color.green;
        Gizmos.DrawCube(posOfGCB, dimsOfGCB);
    }
}