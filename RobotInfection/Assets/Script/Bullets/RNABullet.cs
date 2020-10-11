

public class RNABullet : Bullet
{
	private float _rnaBulletSpeed = 20f;
	public void Start()
	{
		bulletSpeed = _rnaBulletSpeed;
		bulletElement = Elements.NONE;
	}
	public Elements BulletProperties(Elements element)
	{
		element = Elements.NONE;
		return element;
	}
	public float BulletSpeed()
	{
		bulletSpeed = _rnaBulletSpeed;
		return _rnaBulletSpeed;
	}
}
