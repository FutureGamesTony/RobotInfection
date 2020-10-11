using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
	private Sprite _sprite;

	public Sprite Sprite()
	{
		_sprite = Resources.Load<Sprite>("Sprites/ShieldSprite");
		return _sprite;
	}
}
