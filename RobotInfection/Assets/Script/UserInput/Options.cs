using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
	private Button _controls;
	private void Awake()
	{
		_controls = GetComponentInChildren<Button>();
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
