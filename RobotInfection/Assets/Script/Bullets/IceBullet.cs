public class IceBullet : Bullet
{
	private float _iceBulletSpeed = 10f;
	public void Start()
	{
		bulletSpeed = _iceBulletSpeed;
		bulletElement = Elements.ICE;
	}
	public Elements BulletProperties(Elements element)
	{
		element = Elements.ICE;
		return element;
	}
	public float BulletSpeed()
	{
		bulletSpeed = _iceBulletSpeed;
		return _iceBulletSpeed;
	}
}
