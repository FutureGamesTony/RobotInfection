using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVirusSpawn : MonoBehaviour
{
	private float _spawnTimer = 0;
	public float spawnSecond = 3f;
	private Antibody _antibody;
	private GameObject _tVirusGameObject;

	private void Awake()
	{
		_tVirusGameObject = Resources.Load<GameObject>("Prefabs/TVirus");
	}
	void Update()
	{
		_spawnTimer += Time.deltaTime;
		if (_spawnTimer > spawnSecond)
		{
			Instantiate(_tVirusGameObject, gameObject.transform.position, transform.rotation, transform);
			_spawnTimer = 0f;

		}
	}
}
