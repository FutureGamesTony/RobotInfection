using UnityEngine;

public class FlameThrower : UseWeapon
{
	private GameObject _flameBullet;

	private Elements WeaponFunction(Elements element)
	{
		element = Elements.FIRE;
		return element;
	}
	public bool CanFire(Elements element)
	{			
			Attack();
			return true;
	}
	public Elements WeaponElement()
	{
		return Elements.FIRE;
	}
	private void Attack()
	{
		_flameBullet = Resources.Load<GameObject>("Prefabs/FlameBullet");
		Instantiate(_flameBullet, transform.position, gameObject.transform.rotation);
	}
}