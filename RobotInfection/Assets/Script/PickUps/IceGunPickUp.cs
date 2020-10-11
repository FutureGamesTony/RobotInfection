using UnityEngine;

public class IceGunPickUp : MonoBehaviour
{
	private Sprite _sprite;
	public Sprite Sprite()
	{
		_sprite = Resources.Load<Sprite>("Sprites/IceGun");

		return _sprite;
	}
}
