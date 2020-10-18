using UnityEngine.UI;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
	public Image[] _weapons;
	private void Awake()
	{
		_weapons = GetComponentsInChildren<Image>();
		for (int i = 0; i < _weapons.Length; i++)
		{
			_weapons[i].enabled = false;
		}
	}
	public void ChangeSprite(string sprite)
	{
		for (int i = 0; i < _weapons.Length; i++)
		{
			if (_weapons[i].name == sprite)
			{
				_weapons[i].enabled = true;
			}
			else
			{
				_weapons[i].enabled = false;
			}
		}
	}
}