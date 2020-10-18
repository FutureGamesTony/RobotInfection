using UnityEngine;
public class Options : MonoBehaviour
{
	private GameObject _controls;
	private void Awake()
	{
		_controls = transform.Find("Controls").gameObject;
		Debug.Log(_controls);
	}
	public void OptionsMenuOpen()
	{
		_controls.gameObject.SetActive(true);
		Time.timeScale = 0.0f;
	}
	public void OptionsMenuClose()
	{
		_controls.gameObject.SetActive(false);
		Time.timeScale = 1.0f;
	}
}
