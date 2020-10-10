using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMovement : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;
	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_rigidbody2D.gravityScale = 0;
	}
	public void Movement(float movementX, float movementY, float deltaTime, float movementSpeed)
	{
		Vector2 movement = new Vector2(_rigidbody2D.transform.position.x + (movementX * deltaTime), 
		_rigidbody2D.transform.position.y + (movementY * deltaTime));
		_rigidbody2D.transform.position = new Vector3(movement.x + (movementX * movementSpeed * deltaTime),
		movement.y + (movementY * movementSpeed * deltaTime));
	}
	public void Movement(Vector3 movement, float deltaTime, float movementSpeed)
	{
		movement = new Vector3(_rigidbody2D.transform.position.x + (_rigidbody2D.transform.position.x * deltaTime), 
		_rigidbody2D.transform.position.y + (deltaTime * _rigidbody2D.transform.position.y));
		_rigidbody2D.transform.position = movement;
		_rigidbody2D.AddForce(movement * movementSpeed);
	}
	public void Movement(float deltaTime, float speed)
	{
		_rigidbody2D.transform.position += transform.up * deltaTime * speed;
	}
}