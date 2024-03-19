using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _playerRb;
	private Animator _animator;
	private PhotonView _view;
	private SkinnedMeshRenderer _skinnedMeshRenderer;

	private float _horizontalInput;
	private float _verticalInput;
	private Vector3 _direction;
	private const float _rotationSpeed = 1000f;
	private const float _moveForce = 50f;
	private const float _maxSpeed = 3f;

	private void Start()
	{
		_skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
		_skinnedMeshRenderer.material.color = Random.ColorHSV();

		_playerRb = GetComponent<Rigidbody>();
		_animator = GetComponent<Animator>();
		_view = GetComponent<PhotonView>();
	}

	private void Update()
	{
		UpdatePlayerMovement();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log(_playerRb.velocity.magnitude);
		}
	}

	private void FixedUpdate()
	{
			PlayerMove();
	}


	private void UpdatePlayerMovement()
	{
		if (_view.IsMine)
		{
			_horizontalInput = Input.GetAxis("Horizontal");
			_verticalInput = Input.GetAxis("Vertical");
			_direction = new Vector3(_horizontalInput, 0, _verticalInput);

			if (_horizontalInput != 0 || _verticalInput != 0)
			{
				float angle = Mathf.Atan2(_horizontalInput, _verticalInput) * Mathf.Rad2Deg;

				Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
			}
		}
	}



	private void PlayerMove()
	{
		if (_view.IsMine)
		{
			if (_direction.magnitude > 0.05f)
			{
				_animator.SetBool("IsRunning", true);

				_playerRb.AddForce(_direction.normalized * _moveForce, ForceMode.Impulse);

				if (_playerRb.velocity.magnitude >= _maxSpeed)
				{
					_playerRb.velocity = _playerRb.velocity.normalized * _maxSpeed;
				}
			}
			else if(_playerRb.velocity.magnitude < 2.5f)
			{
				_playerRb.velocity = Vector3.zero;
				_animator.SetBool("IsRunning", false);
			}
		}
	}
}



