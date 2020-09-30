using System.Collections;
using UnityEngine;

public class IceGun : UseWeapon
{
	private float _coolDown = 1.0f;
	private float _maxHeat = 10.0f;
	private float _heatIncrease = 1.0f;
	private float _weaponHeat = 0f;
	private float _rapidFireTimer = 1.0f;
	private bool _isRapidFire = false;
	//private Shoot _shoot;
	private GameObject _iceBullet;

	private void Start()
	{

		//_shoot = GetComponent<Shoot>();
	}
	private Elements WeaponFunction(Elements element)
	{
		if (_isRapidFire)
		{
			_heatIncrease += .1f;
		}
		if (!_isRapidFire)
		{
			_heatIncrease = 1f;
			if (_weaponHeat > 0f || !Input.anyKey)
			{
				_weaponHeat -= Time.deltaTime * _coolDown;
			}
			if (_weaponHeat < 0f)
			{
				_weaponHeat = 0f;
			}
		}
		_weaponHeat += _heatIncrease;
		element = Elements.ICE;
		return element;
	}

	public bool CanFire(Elements element)
	{
		if (_weaponHeat < _maxHeat)
		{
			element = WeaponFunction(element);
			return true;
		}
		else
		{
			return false;
		}
	}
	public Elements WeaponElement()
	{
		return Elements.ICE;
	}
	IEnumerator RapidFireCount()
	{
		_isRapidFire = true;
		yield return new WaitForSeconds(_rapidFireTimer);
		_isRapidFire = false;
	}
	public void Attack()
	{
		_iceBullet = Resources.Load<GameObject>("Prefabs/FlameBullet");
		Instantiate(_iceBullet, transform.position, transform.rotation);

		Instantiate(_iceBullet, transform.position, transform.rotation);
	}
}
