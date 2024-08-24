using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] private float movementSpeed; // Player's movement speed.
    [SerializeField] private float horizontalInput; // Player's horizontal input.
    [SerializeField] private bool groundCheck; // Checks if the player is grounded.
    [SerializeField] float yGizmoDisplacement; // Edits the y-axis of the player's ground checker gizmo.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput(); // Inputs are counted by frame.
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
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - yGizmoDisplacement), new Vector2(1f, 0.2f));
    }
}