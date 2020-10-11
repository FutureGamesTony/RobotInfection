using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
	private Sprite _sprite;

	public Sprite Sprite()
	{
		_sprite = Resources.Load<Sprite>("Sprites/HealthPickUpSprite");
		return _sprite;
	}
}
