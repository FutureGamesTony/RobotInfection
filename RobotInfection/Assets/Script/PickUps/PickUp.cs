using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class PickUp : MonoBehaviour
{
	public enum PickUpTypes {ICEGUN, FLAMETHROWER, CANNON, HEALTH, SHIELD};
	public PickUpTypes pickUpType;
	public GameObject pickUpObject;
	private IceGunPickUp _iceGunPickUp;
	private FlameThrowerPickup _flameThrowerPickUp;
	private CannonPickup _cannonPickUp;
	private HealthPickUp _healthPickUp;
	private Sprite _sprite;
	private SpriteRenderer _spriteRenderer;
	private void Start()
	{
		switch (pickUpType)
		{
			case PickUpTypes.ICEGUN:
				_sprite = pickUpObject.GetComponent<IceGunPickUp>().Sprite();
				break;
			case PickUpTypes.FLAMETHROWER:
				_sprite = pickUpObject.GetComponent<FlameThrowerPickup>().Sprite();
				break;
			case PickUpTypes.CANNON:
				_sprite = pickUpObject.GetComponent<CannonPickup>().Sprite();
				break;
			case PickUpTypes.HEALTH:
				_sprite = pickUpObject.GetComponent<HealthPickUp>().Sprite();
				break;
			case PickUpTypes.SHIELD:
				_sprite = pickUpObject.GetComponent<ShieldPickUp>().Sprite();
				break;
		}
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_spriteRenderer.sprite = _sprite;

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//collision.gameObject.AddComponent(pickUpObject);
		}
	}
}
