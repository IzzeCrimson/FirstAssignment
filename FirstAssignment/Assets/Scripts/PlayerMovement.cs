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
    Vector2 inputValue;
    Vector2 smoothValue;
    Vector2 velocity;
    Vector3 moveVector;

    [Header("Rotation")]
    [SerializeField] float rotationSpeed;

    [Header("Jumping and Gravity")]
    [SerializeField] float gravityValue;
    [SerializeField] float jumpValue;
    [SerializeField] bool isPlayerGrounded;

    [Header("Bool")]
    [SerializeField] public bool isCharatcerActive;

    Rigidbody _rigidbody;
    InputManager myInputManager;
    private Transform cameraTransform;
    Quaternion cameraRotation;

    void Awake()
    {
        myInputManager = new InputManager();
        _rigidbody = GetComponent<Rigidbody>();

        isPlayerGrounded = true;
        cameraTransform = Camera.main.transform;
    }


    void Update()
    {
        if (isCharatcerActive)
        {
            MoveCharacterWithKeyboard();
            Jump();
            Rotate();

        }

    }

    void MoveCharacterWithKeyboard()
    {
        inputValue = myInputManager.PlayerControlls.Movement.ReadValue<Vector2>();
        moveVector = new Vector3(inputValue.x, 0, inputValue.y);
        moveVector = moveVector.x * cameraTransform.right.normalized + moveVector.z * cameraTransform.forward.normalized;
        //smoothValue = Vector2.SmoothDamp(smoothValue, moveVector, ref velocity, smoothInputSpeed);
        playerPosition = new Vector3(moveVector.x, 0, moveVector.y);
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

    void Rotate()
    {
        cameraRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, rotationSpeed);
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
