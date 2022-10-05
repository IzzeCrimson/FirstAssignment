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
    Vector3 smoothVector;
    Vector3 velocity;
    Vector3 moveVector;

    [Header("Rotation")]
    [SerializeField] float rotationSpeed;

    [Header("Jumping and Gravity")]
    [SerializeField] float gravityValue;
    [SerializeField] float jumpValue;
    [SerializeField] bool isPlayerGrounded;

    [Header("Bool")]
    [SerializeField] public bool isCharatcerActive;

    [Header("Weapon")]
    [SerializeField] private Weapon weapon;

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

        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (isCharatcerActive)
        {
            MoveCharacterWithKeyboard();
            Jump();
            Rotate();
            Shoot();

        }

    }

    void MoveCharacterWithKeyboard()
    {
        inputValue = myInputManager.PlayerControlls.Movement.ReadValue<Vector2>();

        moveVector = new Vector3(inputValue.x, 0, inputValue.y);

        moveVector = moveVector.x * cameraTransform.right.normalized + moveVector.z * cameraTransform.forward.normalized;
        moveVector.y = 0;

        smoothVector = Vector3.SmoothDamp(smoothVector, moveVector, ref velocity, smoothInputSpeed);

        transform.position += smoothVector * movementSpeed * Time.fixedDeltaTime;
    }

    void Jump()
    {
        if (myInputManager.PlayerControlls.Jump.triggered && isPlayerGrounded)
        {
            isPlayerGrounded = false;

            _rigidbody.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);

        }

    }

    void Shoot()
    {
        if (myInputManager.PlayerControlls.Shoot.triggered)
        {
            weapon.Shoot();

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