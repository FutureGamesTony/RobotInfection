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
	private GameObject _player;
	private GameObject _rnaBullet;
	private GameObject _heathDrop;
	private float _sineCurveDistance = 5;
	private ObjectMovement _objectMovement;
	private ObjectRotation _objectRotation;
	private State _state;
	private float _deltaTime;
	private Vector2 _movement;
	private Vector2 _position;
	private float _movementSpeed = 1f;
	private float _x;
	private float _y;
	private float _distanceToTarget = 4;
	private float _fireRate = .3f;
	private float _timer;
	private Vector3 _playerPosition;
	//This enemy were supposed to have different behaviour based on attack. Fire was a must, to then do damage and ice would double the HP (one time) and cannon kills it.
	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		_rnaBullet = Resources.Load<GameObject>("Prefabs/RNABullet");

		_movement = new Vector2(1f, 1f);
		_objectMovement = GetComponent<ObjectMovement>();
		_objectRotation = GetComponent<ObjectRotation>();
		_state = State.MOVING;
		_playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
		_heathDrop = Resources.Load<GameObject>("Prefabs/PickUp");
	}
	private void Update()
	{
		/*
		 * This code is based on a sample from a friend
		 * he is a much better coder than I am, so it is 
		 * basically me trying to improve. 
		 */
		_deltaTime = Time.deltaTime;

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
		PlayerPosition();
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
		if (Mathf.Pow((Mathf.Pow(_x, 2) + Mathf.Pow(_y, 2)), 0.5f) < _distanceToTarget)
		{
			_state = State.ATTACKING;
		}
		_objectRotation.FollowGameObject(_player);
		_objectMovement.Movement(_movement.x, _movement.y, _deltaTime, _movementSpeed);
	}
	private void Attacking()
	{
		PlayerPosition();
		_timer += _deltaTime;
		if (_timer > _fireRate)
		{
			_objectRotation.FollowGameObject(_player);
			Instantiate(_rnaBullet, transform.position, gameObject.transform.rotation);
			_timer = 0;
		}
		if (Mathf.Pow((Mathf.Pow(_x, 2) + Mathf.Pow(_y, 2)), 0.5f) > _distanceToTarget)
		{
			_state = State.MOVING;
		}
	}
	private void PlayerPosition()
	{
		_playerPosition = _player.transform.position;
		_x = _playerPosition.x - transform.position.x;
		_y = _playerPosition.y - transform.position.y;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Bullet")
		{
			int rand = Random.Range(1, 100);
			if (rand < 50)
			{
				Instantiate(_heathDrop);
				_heathDrop.GetComponent<PickUp>().SetHealth(20);
			}
			Destroy(gameObject);
		}
	}
}
