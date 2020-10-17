using UnityEngine;

public class Shield : MonoBehaviour
{
	private bool _shield;
	private float _shieldLifetime = 10f;
	private float _shieldTimer;
	private bool _isCooling;
	private const float _shieldCoolDownTime = 3f;
	private float _shieldCoolDown = 3f;
	private int _shieldHealth;
	private Player _player;
	public SpriteRenderer shieldSpriteRenderer;

	private void Awake()
	{
		_player = GetComponent<Player>();
		
	}
	public bool ActivateShield()
	{
		if (!_isCooling)
		{
			Debug.Log("Shield");
			_shield = true;
			_player.Shielded(_shield);
			shieldSpriteRenderer.enabled = true;
		}

		return _shield;
	}
	private void Update()
	{
		if (_shield)
		{
			_shieldTimer += Time.deltaTime;
			if (_shieldTimer > _shieldLifetime)
			{
				_shieldTimer = 0;
				_shield = false;
				_player.Shielded(_shield);
				_isCooling = true;
			}
		}
		if (_isCooling)
		{
			shieldSpriteRenderer.enabled = false;
			_shieldCoolDown -= Time.deltaTime;
			if (_shieldCoolDown < 0)
			{
				_isCooling = false;
				_shieldCoolDown = _shieldCoolDownTime;
			}
		}
	}
}