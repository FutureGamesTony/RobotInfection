using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class PickUp : MonoBehaviour
{
	public enum PickUpTypes {ICEGUN, FLAMETHROWER, CANNON, HEALTH, SHIELD};
	public PickUpTypes pickUpType;
	public GameObject _pickUpObject;
	public int health;
	private IceGunPickUp _iceGunPickUp;
	private FlameThrowerPickup _flameThrowerPickUp;
	private CannonPickup _cannonPickUp;
	private HealthPickUp _healthPickUp;
	private Sprite _sprite;
	private SpriteRenderer _spriteRenderer;
	private BoxCollider2D _boxCollider2D;
	private string _spritePath = "Sprites/";
	private string[] _sprites =  {"IceGun", "Flamethrower", "Cannon", "HealthPickUpSprite", "ShieldSprite" };
	private void Awake()
	{
		SetSprite();

		_spriteRenderer = GetComponent<SpriteRenderer>();
		_spriteRenderer.sprite = _sprite;
		_boxCollider2D = GetComponent<BoxCollider2D>();
		_boxCollider2D.size = _sprite.bounds.size;
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
	public PickUpTypes PickUpType()
	{
		return pickUpType;
	}
	private void SetSprite()
	{
		_sprite = Resources.Load<Sprite>(_spritePath + _sprites[(int)pickUpType]);
	}

	public int PickUpHealth()
	{

		return health;
	}
}
