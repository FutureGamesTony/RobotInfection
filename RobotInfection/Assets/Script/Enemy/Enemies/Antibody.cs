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
	private float _deltaTime;
	private float _movementSpeed = 60f;
	private float _effectTimeLimit = 3f;
	private float _effectTimer = 0.0f;
	private float _spriteSize = .5f;
	private float _sineMovement;
	private int _sineUpdate;
	private int _sineIntervallTime = 5; 
	private int _hp;
	private int _hitElement = 0;
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
		if (_hitElement < 0)
		{
			if (_effectTimer < _effectTimeLimit)
			{
				_effectTimer += Time.deltaTime;
			}
			else
			{
				_effectTimer = 0;
				_hitElement = 0;
			}
		}
		else if (_hitElement > 0)
		{
			ReverseMovement();
		}
		else
		{
			Movement();
		}
	}
	private void Movement()
	{
		_deltaTime = Time.deltaTime;
		_playerPosition = _player.transform.position;
		if (_playerPosition.x - transform.position.x < 0)
		{
			_movementX = -0.1f * SinusCurve();
		}
		if (_playerPosition.x - transform.position.x > 0)
		{
			_movementX = 0.1f * SinusCurve();
		}
		if (_playerPosition.y - transform.position.y < 0)
		{
			_movementY = -0.1f * SinusCurve();
		}
		if (_playerPosition.y - transform.position.y > 0)
		{
			_movementY = 0.1f * SinusCurve();
		}

		_objectRotation.FollowGameObject(_player);
		_objectMovement.Movement(_movementX, _movementY, _deltaTime, _movementSpeed);
	}
	private void ReverseMovement()
	{
		_deltaTime = Time.deltaTime;
		_playerPosition = _player.transform.position;

		if (_playerPosition.x - transform.position.x < 0)
		{
			_movementX = 0.1f;
		}
		if (_playerPosition.x - transform.position.x > 0)
		{
			_movementX = -0.1f;
		}
		if (_playerPosition.y - transform.position.y < 0)
		{
			_movementY = 0.1f;
		}
		if (_playerPosition.y - transform.position.y > 0)
		{
			_movementY = -0.1f;
		}
		if (_effectTimer < _effectTimeLimit)
		{
			_effectTimer += _deltaTime;
		}
		else
		{
			_effectTimer = 0;
		}
		_objectRotation.FollowGameObject(_player);
		_objectMovement.Movement(_movementX, _movementY, _deltaTime, _movementSpeed);
	}
	private float SinusCurve()
	{
		_sineMovement += Time.deltaTime;
		_sineUpdate = (int)_sineMovement;
		if (_sineUpdate % _sineIntervallTime == 0)
		{
			_sineMovement = Mathf.Sin(_sineMovement);

		}
		return _sineMovement;
	}
	private IEnumerator ElementEffect()
	{
		yield return new WaitForSeconds(_effectTimeLimit);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Bullet>())
		{
			_hitElement = (int)collision.GetComponent<Bullet>().BulletElement();
			if (_hitElement == 0)
			{
				Destroy(gameObject);
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
