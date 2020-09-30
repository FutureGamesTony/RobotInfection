using System.Collections;
using UnityEngine;

public class Cannon : UseWeapon
{
	private float _rapidFireTimer = .2f;
	private bool _canFire = true;
	private ObjectRotation _objectRotation;
	private GameObject _cannonBullet;

	private void Start()
	{
		_objectRotation = GetComponent<ObjectRotation>();
	}
	private Elements WeaponFunction(Elements element)
	{
		RapidFireCount();
		element = Elements.NONE;
		return element;
	}

	public bool CanFire(Elements element)
	{
		if (_canFire)
		{
			element = WeaponFunction(element);
			return _canFire;
		}
		else
		{
			return _canFire;
		}
	}
	public Elements WeaponElement()
	{
		return Elements.NONE;
	}
	IEnumerator RapidFireCount()
	{
		_canFire = false;
		yield return new WaitForSeconds(_rapidFireTimer);
		_canFire = true;
	}
	public void Attack()
	{
		if (_canFire)
		{
			if (_objectRotation != GetComponent<ObjectRotation>())
			{
				_objectRotation = GetComponent<ObjectRotation>();
			}
			_cannonBullet = Resources.Load<GameObject>("Prefabs/CannonBullet");
			Instantiate(_cannonBullet, transform.position, gameObject.transform.rotation);
			RapidFireCount();
		}
		else
		{

		}
	}
}
