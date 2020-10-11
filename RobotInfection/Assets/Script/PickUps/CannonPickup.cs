using UnityEngine;

public class CannonPickup : MonoBehaviour
{
	private Sprite _sprite;

	public Sprite Sprite()
	{
		_sprite = Resources.Load<Sprite>("Sprites/Cannon");
		return _sprite;
	}
}
