using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //USED FOR MOVING
    [Header("Movement")]
    [SerializeField] float movementSpeed;
    [SerializeField] float smoothInputSpeed;
    Vector3 playerPosition;
    Vector2 input;
    Vector2 currentInput;
    Vector2 velocity;

    [Header("Jumping and Gravity")]
    [SerializeField] float gravityValue;
    [SerializeField] float jumpValue;
    [SerializeField] bool isPlayerGrounded;

    [SerializeField] public bool isCharatcerActive;

    Rigidbody _rigidbody;
    InputManager myInputManager;

    void Awake()
    {
        myInputManager = new InputManager();
        _rigidbody = GetComponent<Rigidbody>();

        isPlayerGrounded = true;
    }


    void Update()
    {
        if (isCharatcerActive)
        {
        MoveCharacterWithKeyboard();
        Jump();

        }

    }

    void MoveCharacterWithKeyboard()
    {
        input = myInputManager.PlayerControlls.Movement.ReadValue<Vector2>();
        currentInput = Vector2.SmoothDamp(currentInput, input, ref velocity, smoothInputSpeed);
        playerPosition = new Vector3(currentInput.x, 0, currentInput.y);
        transform.position += playerPosition * movementSpeed * Time.deltaTime;

    }

    void Jump()
    {
        if (myInputManager.PlayerControlls.Jump.triggered && isPlayerGrounded)
        {
            isPlayerGrounded = false;

            _rigidbody.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerGrounded = true;
        }


    }



    private void OnEnable()
    {

        myInputManager.Enable();

    }

    private void OnDisable()
    {

        myInputManager.Disable();

    }
}
