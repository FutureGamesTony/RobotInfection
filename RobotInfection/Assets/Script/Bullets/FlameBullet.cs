public class FlameBullet : Bullet
{
	private float _flameBulletSpeed = 8f;
	public void Start()
	{
		bulletSpeed = _flameBulletSpeed;
		bulletElement = Elements.FIRE;
	}
	public Elements BulletProperties(Elements element)
	{
		element = Elements.FIRE;
		return element;
	}
	public float BulletSpeed()
	{
		return _flameBulletSpeed;
	}
}
