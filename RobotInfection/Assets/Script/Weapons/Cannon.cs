using System.Collections;
using UnityEngine;

public class Cannon : UseWeapon
{
	private GameObject _cannonBullet;
	private Elements WeaponFunction(Elements element)
	{
		element = Elements.NONE;
		return element;
	}

	public bool CanFire(Elements element)
	{
		Attack();
		return true;
	}
	public Elements WeaponElement()
	{
		return Elements.NONE;
	}
	private void Attack()
	{
			_cannonBullet = Resources.Load<GameObject>("Prefabs/CannonBullet");
			Instantiate(_cannonBullet, transform.position, gameObject.transform.rotation);
	}
}