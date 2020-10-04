using UnityEngine;
[RequireComponent(typeof(ObjectMovement))]
public class Bullet : MonoBehaviour
{
	public enum Elements { FIRE = 1, ICE = -1, NONE = 0 };
	public Elements bulletElement;
	public float bulletSpeed;

	private Rigidbody2D _rigidbody2D;
	private CapsuleCollider2D _capsuleCollider2D;
	private ObjectMovement _objectMovement;
	private IceBullet _iceBullet;
	private FlameBullet _flameBullet;
	private CannonBullet _cannonBullet;

	private float _movemntX;
	private float _movemntY;
	private float _deltaTime;
	private float _lifeTime = 2.5f;
	private float _timer;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_capsuleCollider2D = GetComponent<CapsuleCollider2D>();
		_objectMovement = GetComponent<ObjectMovement>();
		_movemntX = Mathf.Cos(transform.rotation.z);
		_movemntY = Mathf.Sin(transform.rotation.z);
	}

	public void ShootBullet(Vector3 bulletPosition, Quaternion bulletRotation, float movementDirectionX, float movementDirectionY)
	{
		_rigidbody2D.position = bulletPosition;
		transform.rotation = bulletRotation;

	}
	private void Update()
	{
		_deltaTime = Time.deltaTime;
		_timer += _deltaTime;
		if (_timer > _lifeTime)
		{
			Destroy(gameObject);
		}
		if (_objectMovement != null)
		{
			_objectMovement.Movement(_deltaTime, bulletSpeed);
		}
		else
		{
			_objectMovement = GetComponent<ObjectMovement>();
		}
	}
	public Elements BulletElement()
	{
		return bulletElement;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
	}
}
