using UnityEngine;
using System.Collections;
[RequireComponent(typeof(ObjectMovement))]
[RequireComponent(typeof(ObjectRotation))]
public class Antibody : MonoBehaviour
{
	private GameObject _antibody;
	private GameObject _player;
	private GameObject _bullet;
	private ObjectMovement _objectMovement;
	private ObjectRotation _objectRotation;
	private SpriteRenderer _spriteRenderer;
	private Sprite _sprite;
	private Rigidbody2D _rigidbody2D;
	private float _movementX = .5f;
	private float _movementY = .5f;
	private float _time;
	private float _movementSpeed = 1f;
	private float _fireRate = .3f;
	private float _spriteSize = .5f;
	private int _hp;
	private bool _fire;

	private Vector3 _playerPosition;
	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_objectMovement = GetComponent<ObjectMovement>();
		_objectRotation = GetComponent<ObjectRotation>();
		_spriteRenderer = GetComponent<SpriteRenderer>();

		_sprite = Resources.Load<Sprite>("Sprites/Antibody");
		_spriteRenderer.sprite = _sprite;
		_spriteRenderer.flipY = true;
		_rigidbody2D.transform.localScale = new Vector3(_spriteSize, _spriteSize);
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
	}
	private void Update()
	{

		Movement();
	}
	private void Movement()
	{
		_time = Time.deltaTime;
		_playerPosition = _player.transform.position;

		if (_playerPosition.x - transform.position.x < 0)
		{
			_movementX = -.1f;
		}
		if (_playerPosition.x - transform.position.x > 0)
		{
			_movementX = .1f;
		}
		if (_playerPosition.y - transform.position.y < 0)
		{
			_movementY = -.1f;
		}
		if (_playerPosition.y - transform.position.y > 0)
		{
			_movementY = .1f;
		}
		_objectRotation.FollowGameObject(_player);
		_objectMovement.Movement(_movementX, _movementY, _time, _movementSpeed);

		if (_fire)
		{
			FireRate();
		}
	}
	private IEnumerator FireRate()
	{
		yield return new WaitForSeconds(_fireRate);
		_fire = false;

	}

}
