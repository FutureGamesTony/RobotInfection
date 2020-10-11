using UnityEngine;

public class FlameThrowerPickup : MonoBehaviour
{
	private Sprite _sprite;
	public Sprite Sprite()
	{
		_sprite = Resources.Load<Sprite>("Sprites/Flamethrower");
		return _sprite;
	}
}
