using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector2 _inputValue;
    private Vector3 _moveVector;
    private Vector3 _smoothVector;
    private Vector3 _velocity;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _smoothValue;
    [SerializeField] private float _rotationSpeed;
    private Transform _cameraTransform;
    [SerializeField] public bool isCharatcerActive;
    private Quaternion _cameraRotation;
    //[SerializeField] private Weapon weapon;




    void Awake()
    {

        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }


    void FixedUpdate()
    {

        if (isCharatcerActive)
        {

            _moveVector = new Vector3(_inputValue.x, 0, _inputValue.y);

            //Player movement relative to camera direction
            _moveVector = _moveVector.x * _cameraTransform.right.normalized + _moveVector.z * _cameraTransform.forward.normalized;
            _moveVector.y = 0;

            _smoothVector = Vector3.SmoothDamp(_smoothVector, _moveVector, ref _velocity, _smoothValue);
            _characterController.Move(_smoothVector);

            //Rotating player based on camera rotation
            _cameraRotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, _cameraRotation, _rotationSpeed);

        }


    }

    //public void Shoot(InputAction.CallbackContext context)
    //{

    //    if (context.phase != InputActionPhase.Performed)
    //    {

    //        return;

    //    }

    //    weapon.Shoot();

    //}

    public void Move(InputAction.CallbackContext context)
    {

        //Debug.Log("move");
        _inputValue = context.ReadValue<Vector2>() * _movementSpeed;


    }
}
