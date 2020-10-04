using UnityEngine;

public class IceGun : UseWeapon
{
	private GameObject _iceBullet;

	private Elements WeaponFunction(Elements element)
	{
		element = Elements.ICE;
		return element;
	}
	public bool CanFire(Elements element)
	{
		Attack();
		return true;
	}
	public Elements WeaponElement()
	{
		return Elements.ICE;
	}
	private void Attack()
	{
			_iceBullet = Resources.Load<GameObject>("Prefabs/IceBullet");
			Instantiate(_iceBullet, transform.position, transform.rotation);		
	}
}