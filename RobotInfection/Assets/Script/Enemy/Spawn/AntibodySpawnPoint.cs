using UnityEngine;

public class AntibodySpawnPoint : MonoBehaviour
{
	private float _spawnTimer = 0;
	public float spawnSecond = 3f;
	private Antibody _antibody;
	private GameObject _antibodyGameObject;
	Vector3 temp;
	private void Awake()
	{
		temp = transform.position;
		_antibodyGameObject = Resources.Load<GameObject>("Prefabs/Antibody");
	}
	void Update()
	{
		_spawnTimer += Time.deltaTime;
		if (_spawnTimer > spawnSecond)
		{
			Instantiate(_antibodyGameObject, gameObject.transform.position, transform.rotation, transform);
			_spawnTimer = 0f;

		}
	}
}
