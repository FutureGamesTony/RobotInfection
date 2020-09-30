public class CannonBullet : Bullet
{
	private float _cannonBulletSpeed = 15f;
	public void Start()
	{
		bulletSpeed = _cannonBulletSpeed;
		bulletElement = Elements.NONE;
	}
	public Elements BulletProperties(Elements element)
	{
		element = Elements.NONE;
		return element;
	}
	public float BulletSpeed()
	{
		bulletSpeed = _cannonBulletSpeed;
		return _cannonBulletSpeed;
	}
}
