using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float upBoundPadding;
    [SerializeField] float downBoundPadding;

    public float speed;
    private Rigidbody2D rb2d;
    Shooter playerShooter;
    InputAction fireAction;
    InputAction moveAction;
    Vector3 moveVector;

    // Controle para o player não sair da janela de visualização
    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        playerShooter = GetComponent<Shooter>();

        rb2d = GetComponent<Rigidbody2D> ();
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");

        InitBounds();

    }

    // Update is called once per frame
    void Update()
    {
        //MovePlayer();
        moveVector = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        FireShooter();
    }

    void MovePlayer() 
    {
        //moveVector = moveAction.ReadValue<Vector2>();

        // Movimento sem Rigidbody2D
        //Vector3 newPos = transform.position + moveVector * speed * Time.deltaTime;
        //newPos.x = Mathf.Clamp(newPos.x, minBounds.x, maxBounds.x);
        //newPos.y = Mathf.Clamp(newPos.y, minBounds.y, maxBounds.y);
        //transform.position = newPos;
        
        Vector3 newPos = new Vector3(rb2d.position.x, rb2d.position.y, 0) + moveVector * speed * Time.fixedDeltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + downBoundPadding, maxBounds.y - upBoundPadding);

        // Movimento com Rigidbody2D
        //rb2d.AddForce (newPos);
        rb2d.MovePosition(newPos);

        RotateTowardsMovement();
    }

    void RotateTowardsMovement()
    {
        if (moveVector.sqrMagnitude <= Mathf.Epsilon)
        {
            return;
        }

        float angle = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg - 90f;
        rb2d.MoveRotation(angle);
    }

    void ClampPositionToBounds()
    {
        // pega posição atual do rigidbody
        Vector2 pos = rb2d.position;

        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);

        // MovePosition é o jeito "correto" pra mexer em Dynamic Rigidbody2D
        rb2d.MovePosition(pos);
    }

    void InitBounds() 
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void FireShooter() 
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }

}
