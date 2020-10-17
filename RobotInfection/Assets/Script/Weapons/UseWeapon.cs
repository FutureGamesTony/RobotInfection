using UnityEngine;
public class UseWeapon : MonoBehaviour
{
	public enum Elements { FIRE = 1, ICE = -1, NONE = 0 };
	private enum Weapon { EMPTY, ICEGUN, FLAMETHROWER, CANNON}
	private Weapon _weapon = Weapon.EMPTY;
	private Weapon _first = Weapon.EMPTY;
	private Weapon _second = Weapon.EMPTY;
	private FlameThrower _flameThrower;
	private IceGun _iceGun;
	private Cannon _cannon;
	private GameObject _bullet;
	private float _rapidFireTimer = .2f;
	private float _time = 0;
	private int _weaponAmount = 0;
	private int _selectCannon = 1;
	private int _selectFlameThrower = 2;
	private int _selectIceGun = -1;
	private bool _canFire = false;
	private Elements weaponElement;

	public void Attack(KeyCode fireKey)
	{

		if (_canFire)
		{
			switch (_weapon)
			{
				case Weapon.ICEGUN:
				_iceGun.CanFire(weaponElement);
					break;
				case Weapon.FLAMETHROWER:
				_flameThrower.CanFire(weaponElement);
					break;
				case Weapon.CANNON:
				_cannon.CanFire(weaponElement);
					break;
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
		if (_weaponAmount > 0)
		{
			if (_weaponAmount == 2)
			{
				if (_weapon == _first) _weapon = _second;
				else _weapon = _first;
			}
			if (_weaponAmount == 3)
			{
				_weapon--;
				if (_weapon == Weapon.EMPTY) _weapon = Weapon.CANNON;
			}
		}
		
		return (int)_weapon;
	}
	public int NextWeapon()
	{
		if (_weaponAmount > 0)
		{
			if (_weaponAmount == 2)
			{		
				if (_weapon == _first) _weapon = _second;
				else _weapon = _first;			
			}
			if (_weaponAmount == 3)
			{
				_weapon++;
				if (_weapon > Weapon.CANNON) _weapon = Weapon.ICEGUN;
			}
		}
		return (int)_weapon;
	}
	public void WeaponAmount()
	{
		_weaponAmount++;
	}
	public void AddCannon()
	{
		_cannon = GetComponent<Cannon>();
		weaponElement = _cannon.WeaponElement();
		_selectCannon = _weaponAmount;
		_weapon = Weapon.CANNON;
		SetWeapons(_weapon);
	}
	public void AddIceGun()
	{
		_iceGun = GetComponent<IceGun>();
		weaponElement = _iceGun.WeaponElement();
		_selectIceGun = _weaponAmount;
		_weapon = Weapon.ICEGUN;
		SetWeapons(_weapon);
	}
	public void AddFlamethrower()
	{
		_flameThrower = GetComponent<FlameThrower>();
		weaponElement = _flameThrower.WeaponElement();
		_selectFlameThrower = _weaponAmount;
		_weapon = Weapon.FLAMETHROWER;
		SetWeapons(_weapon);
	}
	private void SetWeapons(Weapon weapon)
	{
		if (_first == Weapon.EMPTY)
		{
			_first = weapon;
		}
		else if (_second == Weapon.EMPTY)
		{
			_second = weapon;
		}
	}
}