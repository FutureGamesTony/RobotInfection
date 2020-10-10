using UnityEngine;

[RequireComponent(typeof(ObjectRotation))]
[RequireComponent(typeof(ObjectMovement))]
public class TVirus : MonoBehaviour
{
	enum State { MOVING, ATTACKING };
	/*
	 * t-virus has an ice shield, 
	 * it needs to be destroyed 
	 * before damage can be done 
	 * to the enemy. 
	 * The enemy will move in a 
	 * sine curve, then circulate 
	 * the player and then spiral 
	 * in towards the player.
	 */
	public GameObject _player;
	public float _sineCurveDistance;

	private ObjectMovement _objectMovement;
	private ObjectRotation _objectRotation;
	private State _state;
	public float _deltaTime;
	public Vector2 _movement;
	public Vector2 _position;
	public float _movementSpeed = 1f;
	private float _x;
	private float _y;
	public float _distanceToTarget;
	private Vector3 _playerPosition;

	private void Start()
	{
		_movement = new Vector2(1f, 1f);
		_objectMovement = GetComponent<ObjectMovement>();
		_objectRotation = GetComponent<ObjectRotation>();
		_state = State.MOVING;
		_playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
	}
	private void Update()
	{
		/*
		 * This code is based on a sample from a friend
		 * he is a much better coder than I am, so it is 
		 * basically me trying to improve. 
		 */
		switch (_state)
		{
			case State.MOVING:
				UpdateMovement();
				break;
			case State.ATTACKING:
				Attacking();
				break;
		}
	}
	private void UpdateMovement()
	{
		//_deltaTime = Time.deltaTime;
		//_position.y = _player.transform.position.y - transform.position.y;
		//_position.x = _player.transform.position.x - transform.position.x;
		//_position.x = Mathf.Cos(_position.x);
		//_position.y = Mathf.Sin(_position.y);
		//if (_position.y > _sineCurveDistance && _movement.y > 0)
		//{
		//	_movement.y *= -1;
		//}
		//if (_position.y < _sineCurveDistance && _movement.y < 0)
		//{
		//	_movement.y *= -1;
		//}
		//if (_position.x < 0 && _movement.x > 0)
		//{
		//	_position.x *= -1;
		//}
		//if (_position.x > 0 && _movement.x < 0)
		//{
		//	_position.x *= -1;
		//}
		//_objectMovement.Movement(_movement.x, _movement.y, _deltaTime, _movementSpeed);
		_deltaTime = Time.deltaTime;
		_playerPosition = _player.transform.position;
		_x = _playerPosition.x - transform.position.x;
		_y = _playerPosition.y - transform.position.y;
		if (_x < 0)
		{
			_movement.x = -0.1f;
		}
		if (_x > 0)
		{
			_movement.x = 0.1f;
		}
		if (_y + _sineCurveDistance < 0)
		{
			_movement.y = -0.1f;
		}
		if (_y - _sineCurveDistance > 0)
		{
			_movement.y = 0.1f;
		}
		if (Mathf.Sqrt( Mathf.Pow(_x,2) + Mathf.Pow(_y, 2)) < _distanceToTarget)
		{
			_state = State.ATTACKING;
		}
		_objectRotation.FollowGameObject(_player);
		_objectMovement.Movement(_movement.x, _movement.y, _deltaTime, _movementSpeed);
	}
	private void Attacking()
	{
		Debug.Log("Attacking");
	}
}
