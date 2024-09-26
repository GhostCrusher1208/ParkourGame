using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed = 5f;
    public float sprintSpeed=10f;

    public float groundDrag=5f;

    public float jumpForce = 8f;
    public float jumpCooldown=0.25f;
    public float airMultiplier = 0.5f;
    bool readytoJump;

    bool sprintActive=false;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;


    [Header("Ground Check")]
    public float playerHeight=2f;
    public LayerMask whatIsground;
    bool grounded;

    [Header("Crouching")]
    public float crouchingspeed;
    public float crouchYscale;
    public float startYscale;
    private bool iscrouching = false;

    [Header("Slope")]
    public float maxSlopeAngle;
    public RaycastHit slopeHit;
    private bool exitingslope;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    // Start is called before the first frame update
    void Start()
    {
        readytoJump = true;
        rb= GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        startYscale = transform.localScale.y;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsground);

        MyInput();
        SpeedControl();
        StateHandler();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void MyInput()
    {
        if (Input.GetKeyDown(sprintKey) && Input.GetKey(KeyCode.W))
        {
            sprintActive = !sprintActive;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            sprintActive = false;
        }
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYscale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            iscrouching = true;
        }
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYscale, transform.localScale.z);
            iscrouching = false;
          
        }


        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKey(jumpKey) && readytoJump && grounded)
        {
            readytoJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);

        }


    }
    private void StateHandler()
    {
        if (Input.GetKey(crouchKey)) 
        {
            state = MovementState.crouching;
            
            moveSpeed = crouchingspeed;

        }
        if(grounded && sprintActive)
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;

        }
        else if(grounded && !iscrouching)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        else
        {
            state = MovementState.air;
        }
        rb.useGravity = !OnSlope();
    }
    private void MovePlayer()
    {

        //calculate movement direction
        moveDirection = orientation.forward*verticalInput+ orientation.right*horizontalInput;

        if (OnSlope() && !exitingslope)
        {
            rb.AddForce(GetSlopeMovmentDirection() * moveSpeed * 20f, ForceMode.Force);
            if (rb.velocity.y> 0)
            {
                rb.AddForce(Vector3.down * 80, ForceMode.Force);
            }
        }
        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized*moveSpeed * 10f, ForceMode.Force);

        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f* airMultiplier, ForceMode.Force);

    }
    private void SpeedControl()
    {
        if (OnSlope() && !exitingslope)
        {
            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limit velocity
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
       

    }
    private void Jump()
    {
        exitingslope = true;
        //reset y velocitiy
        rb. velocity= new Vector3(rb.velocity.x,0f,rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }
    private void ResetJump()
    {
        exitingslope=false;
        readytoJump = true;
    }
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }
    private Vector3 GetSlopeMovmentDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection,slopeHit.normal).normalized;
    }
}
