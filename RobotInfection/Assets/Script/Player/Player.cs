using UnityEngine;

public class Player : MonoBehaviour
{
	private enum PickUpTypes { ICEGUN, FLAMETHROWER, CANNON, HEALTH, SHIELD };
	public int hp = 10;
	private bool _isShielded;
	private UseWeapon _useWeapon;
	private void Awake()
	{
		_useWeapon = GetComponent<UseWeapon>();
	}
	private void Update()
	{
		if (hp <= 0)
		{
			Debug.Log("You are dead ");
		}
	}
	public bool Shielded(bool hasShield)
	{
		_isShielded = hasShield;
		return hasShield;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (_isShielded)
		{

		}
		else if(collision.gameObject.tag != "Bullet")
		{
			hp--;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PickUp")
		{
			if (collision.gameObject.GetComponent<PickUp>().PickUpType() == (int)PickUpTypes.ICEGUN) //Not the best solution...
			{
				gameObject.AddComponent<IceGun>();
				_useWeapon.AddIceGun();
				_useWeapon.WeaponAmount();
			}
			if ((int)collision.gameObject.GetComponent<PickUp>().PickUpType() == (int)PickUpTypes.FLAMETHROWER)
			{
				gameObject.AddComponent<FlameThrower>();
				_useWeapon.AddFlamethrower();
				_useWeapon.WeaponAmount();
			}
			if ((int)collision.gameObject.GetComponent<PickUp>().PickUpType() == (int)PickUpTypes.CANNON)
			{
				gameObject.AddComponent<Cannon>();
				_useWeapon.AddCannon();
				_useWeapon.WeaponAmount();
			}
			if ((int)collision.gameObject.GetComponent<PickUp>().PickUpType() == (int)PickUpTypes.HEALTH)
			{
				hp += collision.gameObject.GetComponent<PickUp>().PickUpHealth();
			}
			if ((int)collision.gameObject.GetComponent<PickUp>().PickUpType() == (int)PickUpTypes.SHIELD)
			{
				//More time and the shield function was going to be here, with a counter for uses and the ability to pick it up again
			}			
		}
		if (_isShielded)
		{

		}
		else if (collision.gameObject.tag != "Bullet")
		{
			hp--;
		}
	}
}
