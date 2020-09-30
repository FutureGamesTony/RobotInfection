using UnityEngine;

public class UseWeapon : MonoBehaviour
{
	public enum Elements { FIRE = 1, ICE = -1, NONE = 0 };


	private FlameThrower _flameThrower;
	private IceGun _iceGun;
	private Cannon _cannon;
	private Elements weaponElement;
	private GameObject _bullet;
	private void Awake()
	{
		if (GetComponent<FlameThrower>() != null)
		{
			Debug.Log("Use weapon: FlameThrower compnent");
			_flameThrower = GetComponent<FlameThrower>();
			weaponElement = _flameThrower.WeaponElement();
		}
		if (GetComponent<IceGun>() != null)
		{
			Debug.Log("Use weapon: IceGun compnent");
			_iceGun = GetComponent<IceGun>();
			weaponElement = _iceGun.WeaponElement();
		}
		if (GetComponent<Cannon>() != null)
		{
			Debug.Log("Use weapon: Cannon compnent");
			_cannon = GetComponent<Cannon>();
			weaponElement = _cannon.WeaponElement();
		}


	}
	public void Attack(KeyCode fireKey)
	{
		if (Input.GetKey(fireKey))
		{
			if (GetComponent<FlameThrower>() != null)
			{
				_flameThrower = GetComponent<FlameThrower>();
				_flameThrower.Attack();
			}
			if (GetComponent<IceGun>() != null)
			{
				_iceGun = GetComponent<IceGun>();
				_iceGun.Attack();
			}
			if (GetComponent<Cannon>() != null)
			{
				_cannon = GetComponent<Cannon>();
				_cannon.Attack();
			}
		}
	}
}
