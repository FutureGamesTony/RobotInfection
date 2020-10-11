using UnityEngine;

public class Player : MonoBehaviour
{
	public int hp = 10;
	private bool _isShielded;
	private GameObject[] _pickUps;
	private void Update()
	{
		if (hp < 0)
		{
			Debug.Log("You are dead ");
		}
	}
	public bool Shielded(bool hasShield)
	{
		_isShielded = hasShield;
		return hasShield;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (_isShielded)
		{

		}
		else if(collision.gameObject.tag != "Bullet")
		{
			hp--;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PickUp")
		{
			_pickUps = GameObject.FindGameObjectsWithTag("PickUo"); 
				//collision.gameObject.GetComponent<PickUp>().pickUpObject;
		}
		if (_isShielded)
		{

		}
		else if (collision.gameObject.tag != "Bullet")
		{
			hp--;
		}
	}
}
