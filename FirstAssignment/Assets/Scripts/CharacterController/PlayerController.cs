using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //USED FOR MOVING
    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _smoothInputSpeed;
    private Vector2 _inputValue;
    private Vector3 _smoothVector;
    private Vector3 _velocity;
    private Vector3 _moveVector;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed;

    [Header("Jumping and Gravity")]
    [SerializeField] private float _gravityValue;
    [SerializeField] private float _jumpValue;
    [SerializeField] private bool _isPlayerGrounded;

    [Header("Bool")]
    public bool isCharacterBlue;
    public bool isCharatcerActive;

    [Header("Weapon")]
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private Weapon[] _weapons;
    private float _scrollValue;
    private int _currentWeapon;

    private Rigidbody _rigidbody;
    private InputManager _myInputManager;
    private Transform _cameraTransform;
    private Quaternion _cameraRotation;

    void Awake()
    {
        _myInputManager = new InputManager();
        _rigidbody = GetComponent<Rigidbody>();

        _isPlayerGrounded = true;
        _cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;

        _currentWeapon = 0;
        _weapons[_currentWeapon].transform.position = _weaponTransform.position;
    }


    void Update()
    {
        if (isCharatcerActive)
        {
            if (TurnTime.isTurnRunning || TurnTime.isTurnEnding)
            {
                MoveCharacterWithKeyboard();
                Jump();

            }

            if (TurnTime.isTurnRunning)
            {
                SwapWeapon();
                Shoot();

            }

            Rotate();
            OpenMenu();

        }

    }

    void MoveCharacterWithKeyboard()
    {
        _inputValue = _myInputManager.PlayerControlls.Movement.ReadValue<Vector2>();

        _moveVector = new Vector3(_inputValue.x, 0, _inputValue.y);

        _moveVector = _moveVector.x * _cameraTransform.right.normalized + _moveVector.z * _cameraTransform.forward.normalized;
        _moveVector.y = 0;

        _smoothVector = Vector3.SmoothDamp(_smoothVector, _moveVector, ref _velocity, _smoothInputSpeed);

        transform.position += _smoothVector * _movementSpeed * Time.fixedDeltaTime;
    }

    void Jump()
    {
        if (_myInputManager.PlayerControlls.Jump.triggered && _isPlayerGrounded)
        {
            _isPlayerGrounded = false;

            _rigidbody.AddForce(Vector3.up * _jumpValue, ForceMode.Impulse);

        }

    }

    void Shoot()
    {
        if (_myInputManager.PlayerControlls.Shoot.triggered)
        {
            _weapons[_currentWeapon].Shoot();
            TurnTime.EndTurnTimer();
        }
    }

    void Rotate()
    {
        _cameraRotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, _cameraRotation, _rotationSpeed);

    }

    void SwapWeapon()
    {
        _scrollValue = _myInputManager.PlayerControlls.SwapWeapon.ReadValue<float>();

        if (_scrollValue < 0)
        {
            _weapons[_currentWeapon].transform.position = new Vector3(0, -200, 0);
            _currentWeapon = (_currentWeapon + 1) % _weapons.Length;
            _weapons[_currentWeapon].transform.position = _weaponTransform.position;
        }

        if (_scrollValue > 0)
        {
            _weapons[_currentWeapon].transform.position = new Vector3(0, -200, 0);
            _currentWeapon = (_currentWeapon - 1) % _weapons.Length;
            if (_currentWeapon < 0)
            {
                _currentWeapon += _weapons.Length;
            }
            _weapons[_currentWeapon].transform.position = _weaponTransform.position;
        }
    }

    void OpenMenu()
    {
        if (_myInputManager.PlayerControlls.OpenMenu.triggered)
        {
            ButtonsScript.ToggleMainMenu();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isPlayerGrounded = true;
        }


    }



    private void OnEnable()
    {

        _myInputManager.Enable();

    }

    private void OnDisable()
    {

        _myInputManager.Disable();

    }
}
