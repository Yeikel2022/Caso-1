using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
	/*Código para caminar al player: */
	//Movimiento básico:
	[SerializeField]
	float moveSpeed;

	[SerializeField]
	float rotationSpeed;

	[SerializeField]
	float jumpForce;

	[SerializeField]
	Transform _groundCheck;

	[SerializeField]
	LayerMask whatIsWalkable;

	[SerializeField]
	float gravityMultiplier;

	CharacterController _characterController;

	float _gravityY;
	float _velocityY;

	float _inputX;
	float _inputZ;

	bool _isJumpPressed;
	bool _isGrounded;

	Camera _mainCamera;

	Vector3 _direction;

	//=====================================================================================================================================================================================================================================//

	//Va a buscar el primer rigidbody que encuentre y lo captura.
	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
		_mainCamera = Camera.main;
		_gravityY = Physics.gravity.y;
	}


	private void Start()
	{
		_isGrounded = IsGrounded();
		if (!_isGrounded)
		{
			StartCoroutine(WaitForGroundedCoroutine());
		}
	}


	//Para capturar input X y Z:
	//Solo para lógica.
	private void Update()
	{
		HandleGravity();
		HandleMovement();
	}


	//Para que pueda saber el personaje cuando toca -
	//el suelo y pueda brincar.
	private void HandleGravity()
	{
		if (_isGrounded)
		{
			if(_velocityY < -1.0F)
			{
				_velocityY = -1.0F;
			}
			
			HandleJump();
			
			if (_isJumpPressed)
			{
				Jump();
			}

		}
		else
		{
			_velocityY += _gravityY * gravityMultiplier * Time.deltaTime;
		}
	}


	private void HandleMovement()
	{
		_inputX = Input.GetAxisRaw("Horizontal");
		_inputZ = Input.GetAxisRaw("Vertical");
	}

	//Solo para la parte física (movimiento al objeto):
	private void FixedUpdate()
	{
		Rotate();
		Move();
	}

	private bool IsMove()
	{
		return (_inputX != 0.0F || _inputZ != 0.0F);
	}

	private void Move()
	{
		_direction.y = _velocityY;
		_characterController.Move(_direction * moveSpeed * Time.fixedDeltaTime);
	}

	private void Rotate()
	{
		if (!IsMove())
		{
			_direction = Vector3.zero;
			return;
		}

		_direction = Quaternion.Euler(0.0F, _mainCamera.transform.eulerAngles.y, 0.0F)
		* new Vector3(_inputX, 0.0F, _inputZ);
		Quaternion targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
		transform.rotation =
		Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
	}

	private void HandleJump()
	{
		_isJumpPressed = Input.GetButton("Jump");
	}

	private void Jump()
	{
		_velocityY = jumpForce;

		_isGrounded = false;
		StartCoroutine(WaitForGroundedCoroutine());
	}


	private bool IsGrounded()
	{
		return _characterController.isGrounded;
	}


	private IEnumerator WaitForGroundedCoroutine()
	{
		yield return new WaitUntil(() => !IsGrounded());
		Debug.Log($"IsGrounded: FALSE");
		yield return new WaitUntil(() => IsGrounded());
		Debug.Log($"IsGrounded: TRUE");
		_isGrounded = true;
	}







}
