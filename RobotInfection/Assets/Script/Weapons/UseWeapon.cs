using UnityEngine;
public class UseWeapon : MonoBehaviour
{
	public enum Elements { FIRE = 1, ICE = -1, NONE = 0 };

	private FlameThrower _flameThrower;
	private IceGun _iceGun;
	private Cannon _cannon;
	private GameObject _bullet;
	private float _rapidFireTimer = .2f;
	private float _time = 0;
	private int _weaponAmount = 3;
	private int _weaponSelected = 1;
	private int _selectCannon = 1;
	private int _selectFlameThrower = 2;
	private int _selectIceGun = 3;
	private bool _canFire = false;
	private Elements weaponElement;

	private void Awake()
	{
		_cannon = GetComponent<Cannon>();
		weaponElement = _cannon.WeaponElement();
		_flameThrower = GetComponent<FlameThrower>();
		weaponElement = _flameThrower.WeaponElement();
		_iceGun = GetComponent<IceGun>();
		weaponElement = _iceGun.WeaponElement();
		_cannon.enabled = false;
		_flameThrower.enabled = false;
		_iceGun.enabled = false;
	}
	public void Attack(KeyCode fireKey)
	{
		if (_canFire)
		{
			if (_weaponSelected == _selectFlameThrower)
			{
				_flameThrower.enabled = true;
				_iceGun.enabled = false;
				_cannon.enabled = false;
				_flameThrower.CanFire(weaponElement);
			}
			if (_weaponSelected == _selectIceGun)
			{
				_flameThrower.enabled = false;
				_iceGun.enabled = true;
				_cannon.enabled = false;
				_iceGun = GetComponent<IceGun>();
				_iceGun.CanFire(weaponElement);
			}
			if (_weaponSelected == _selectCannon)
			{
				_flameThrower.enabled = false;
				_iceGun.enabled = false;
				_cannon.enabled = true;
				_cannon = GetComponent<Cannon>();
				_cannon.CanFire(weaponElement);
			}
		}
		_canFire = false;
	}
	private void Update()
	{
		if (!_canFire)
		{
			if (_time < _rapidFireTimer)
			{
				_time += Time.deltaTime;
			}
			else if (_time >= _rapidFireTimer)
			{
				_canFire = true;
				_time = 0;
			}
		}
	}
	public int PreviousWeapon()
	{
		_weaponSelected--;
		if (_weaponSelected == 0)
		{
			_weaponSelected = _weaponAmount;
		}
		return _weaponSelected;
	}
	public int NextWeapon()
	{
		_weaponSelected++;
		if (_weaponSelected > _weaponAmount)
		{
			_weaponSelected = 1;
		}
		return _weaponSelected;
	}
}
