using System;
using UnityEngine;
using System.Collections;
public class ControllerCustomization : MonoBehaviour
{

	private bool _up = false;
	private bool _down = false;
	private bool _left = false;
	private bool _right = false;
	private bool _previousWeapon = false;
	private bool _nextWeapon = false;
	private bool _fire = false;
	private bool _shield = false;
	private KeyCode _upKey;
	private KeyCode _downKey;
	private KeyCode _leftKey;
	private KeyCode _rightKey;
	private KeyCode _previousWeaponKey;
	private KeyCode _nextWeaponKey;
	private KeyCode _fireKey;
	private KeyCode _shieldKey;
	private string _moveDirection;
	public bool _isActive = false;
	private void Awake()
	{




		gameObject.SetActive(_isActive);
	}
	private void Update()
	{
		if (_up)
		{
			if (Input.anyKey)
			{
				_moveDirection = Input.inputString;
				_upKey = GetControllerInput(_upKey);
				Debug.Log(_upKey);
				_up = false;
			}
		}
		if (_down)
		{
			if (Input.anyKey)
			{
				_moveDirection = Input.inputString;
				_downKey = GetControllerInput(_downKey);
				Debug.Log(_downKey);
				_down = false;
			}
		}
		if (_left)
		{
			if (Input.anyKey)
			{
				_moveDirection = Input.inputString;
				_leftKey = GetControllerInput(_leftKey);
				Debug.Log(_leftKey);
				_left = false;
			}
		}
		if (_right)
		{
			if (Input.anyKey)
			{
				_moveDirection = Input.inputString;
				_rightKey = GetControllerInput(_rightKey);
				Debug.Log(_rightKey);
				_right = false;
			}
		}
		if (_previousWeapon)
		{
			if (Input.anyKey)
			{
				_moveDirection = Input.inputString;
				_previousWeaponKey = GetControllerInput(_previousWeaponKey);
				Debug.Log(_previousWeaponKey);
				_previousWeapon = false;
			}
		}
		if (_nextWeapon)
		{
			if (Input.anyKey)
			{
				_moveDirection = Input.inputString;
				_nextWeaponKey = GetControllerInput(_nextWeaponKey);
				Debug.Log(_nextWeaponKey);
				_nextWeapon = false;
			}
		}
		if (_fire)
		{
			if (Input.anyKey)
			{
				_moveDirection = Input.inputString;
				_fireKey = GetControllerInput(_fireKey);
				Debug.Log(_fireKey);
				_fire = false;
			}
		}
		Debug.Log("ControllerSetup");
	}
	private KeyCode GetControllerInput(KeyCode key)
	{

		if (_moveDirection == "")
		{
			key = NonLatinEnglishLetterKey(key);
		}
		_moveDirection = _moveDirection[0].ToString();
		_moveDirection = _moveDirection.ToUpper();

		if (Enum.IsDefined(typeof(KeyCode), _moveDirection))
		{

			key = (KeyCode)Enum.Parse(typeof(KeyCode), _moveDirection);
		}
		else
		{
			key = NonLatinEnglishLetterKey(key);
		}
		Debug.Log("KeyCode enum: " + key);
		return key;
	}
	private KeyCode NonLatinEnglishLetterKey(KeyCode key)
	{
		//https://forum.unity.com/threads/find-out-which-key-was-pressed.385250/ Code copied
		foreach (KeyCode _key in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKey(_key))
			{
				key = _key;
				Debug.Log("KeyCode down: " + _key);
			}
		}
		return key;
	}

	public void Up()
	{
		/*
		 * The update was supposed to be removed from this script and the settings was based on the button pressed, then a while loop waited for a button press
		 * to get user input:
		 * bool isKeyChosen = false; (global bool)
		 * while(!isKeyChosen)
		 * {
		 *		if(Input.anyKey)
		 *		{
		 *			_upKey = GetControllerInput(_upKey);
		 *			isKeyChosen = true;
		 *		}
		 *	}
		 *	the idea was that the bool should be set to false the clicked frame, then true and wait for user input to set the controllers. After wasting two days 
		 *	trying to find a solution, I decided to just use update and change a bool to true when clicked. Not elegant, not efficient, but it works.
		 */
		_up = true;

	}
	public void Down()
	{
		_down = true;
	}
	public void Left()
	{
		_left = true;
	}
	public void Right()
	{
		_right = true;
	}
	public void PreviousWeapon()
	{
		_previousWeapon = true;
	}
	public void NextWeapon()
	{
		_nextWeapon = true;
	}
	public void Fire()
	{
		_fire = true;
	}
	public void Shield()
	{
		_shield = true;
	}
	public KeyCode UpKey()
	{
		if (_upKey == KeyCode.None)
		{
			_upKey = KeyCode.W;
		}
		return _upKey;
	}
	public KeyCode DownKey()
	{
		if (_downKey == KeyCode.None)
		{
			_downKey = KeyCode.S;
		}
		return _downKey;
	}
	public KeyCode LeftKey()
	{
		if (_leftKey == KeyCode.None)
		{
			_leftKey = KeyCode.A;
		}
		return _leftKey;
	}
	public KeyCode RightKey()
	{
		if (_rightKey == KeyCode.None)
		{
			_rightKey = KeyCode.D;
		}
		return _rightKey;
	}
	public KeyCode PreviousWeaponKey()
	{
		if (_previousWeaponKey == KeyCode.None)
		{
			_previousWeaponKey = KeyCode.Q;
		}
		return _previousWeaponKey;
	}
	public KeyCode NextWeaponKey()
	{
		if (_nextWeaponKey == KeyCode.None)
		{
			_nextWeaponKey = KeyCode.E;
		}
		return _nextWeaponKey;
	}
	public KeyCode FireKey()
	{
		if (_fireKey == KeyCode.None)
		{
			_fireKey = KeyCode.Mouse0;
		}
		return _fireKey;
	}
	public KeyCode ShieldKey()
	{
		if (_shieldKey == KeyCode.None)
		{
			_shieldKey = KeyCode.Space;
		}
		return _shieldKey;
	}
	public void IsActive()
	{
		_isActive = !_isActive;
		gameObject.SetActive(_isActive);
	}
}