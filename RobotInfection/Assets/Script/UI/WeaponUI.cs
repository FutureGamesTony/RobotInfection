using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
	
	public GameObject iceGun;
	public GameObject flamethrower;
	public GameObject cannon;

	public void IceGun()
	{
		iceGun.SetActive(true);
		flamethrower.SetActive(false);
		cannon.SetActive(false);
	}
	public void Flamethrower()
	{
		iceGun.SetActive(false);
		flamethrower.SetActive(true);
		cannon.SetActive(false);
	}
	public void Cannon()
	{
		iceGun.SetActive(false);
		flamethrower.SetActive(false);
		cannon.SetActive(true);
	}

}
