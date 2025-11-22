using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float upBoundPadding;
    [SerializeField] float downBoundPadding;

    [Header("Movement Settings")]
    [SerializeField] float acceleration = 10f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float linearDrag = 2f;
    [SerializeField] float brakingDrag = 6f;
    [SerializeField] float rotationSpeed = 300f;

    private Rigidbody2D rb2d;
    Shooter playerShooter;
    InputAction fireAction;
    InputAction moveAction;
    Vector3 moveVector;

    Vector2 minBounds;
    Vector2 maxBounds;
    
    Camera mainCamera;

    void Start()
    {
        playerShooter = GetComponent<Shooter>();

        rb2d = GetComponent<Rigidbody2D> ();
        rb2d.gravityScale = 0f;
        rb2d.linearDamping = linearDrag; 

        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");

        mainCamera = Camera.main;

    }

    void Update()
    {
        //MovePlayer();
        moveVector = moveAction.ReadValue<Vector2>();
        FireShooter();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer() 
    {
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        if (moveVector.x != 0)
        {
            float rotationAmount = -moveVector.x * rotationSpeed * Time.fixedDeltaTime;
            rb2d.MoveRotation(rb2d.rotation + rotationAmount);
        }

        float thrust = Mathf.Max(0, moveVector.y); 
        
        if (thrust > 0)
        {
            rb2d.linearDamping = linearDrag; 
            rb2d.AddForce(transform.up * thrust * acceleration);
        }
        else if (moveVector.y < 0) 
        {
            rb2d.linearDamping = brakingDrag;
        }
        else
        {
            rb2d.linearDamping = linearDrag; 
        }

        if (rb2d.linearVelocity.magnitude > maxSpeed)
        {
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * maxSpeed;
        }

        Vector2 pos = rb2d.position;
        pos.x = Mathf.Clamp(pos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        pos.y = Mathf.Clamp(pos.y, minBounds.y + downBoundPadding, 1000);

        rb2d.position = pos;
    }

    void FireShooter() 
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }

}
