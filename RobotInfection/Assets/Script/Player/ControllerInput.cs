using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ObjectMovement))]
[RequireComponent(typeof(ObjectRotation))]
[RequireComponent(typeof(UseWeapon))]
public class ControllerInput : MonoBehaviour
{
	[Range(1, 100)]
	public float movementSpeed = 100.0f;
	public ControllerCustomization controllerCustomization;

	private Options _options;
	private float _movementX;
	private float _movementY;
	private bool _isInOptions = false;	
	private KeyCode _optionsKey = KeyCode.Escape;
	private KeyCode _upKey;
	private KeyCode _downKey;
	private KeyCode _leftKey;
	private KeyCode _rightKey;
	private KeyCode _fireKey;
	private KeyCode _previousWeaponKey;
	private KeyCode _nextWeaponKey;
	private KeyCode _shieldKey;
	private Player _player;
	private ObjectMovement _objectMovement;
	private ObjectRotation _objectRotation;
	private GameObject _weapon;
	private UseWeapon _useWeapon;
	private Shield _shield;

	private void Awake()
	{
		ButtonMapping();
		controllerCustomization.gameObject.SetActive(false);
		_objectMovement = GetComponent<ObjectMovement>();
		_objectRotation = GetComponent<ObjectRotation>();
		_useWeapon = GetComponent<UseWeapon>();
		_shield = GetComponent<Shield>();
		_options = FindObjectOfType<Options>();

	}
	private void Update()
	{
		if (Input.GetKeyUp(_upKey) || Input.GetKeyUp(_downKey))
		{
			_movementY = 0;
		}
		if (Input.GetKey(_upKey))
		{
			_movementY = +1f;
		}
		if (Input.GetKey(_downKey))
		{
			_movementY = -1f;
		}
		if (Input.GetKeyUp(_leftKey) || Input.GetKeyUp(_rightKey))
		{
			_movementX = 0;
		}
		if (Input.GetKey(_leftKey))
		{
			_movementX = -1f;
		}
		if (Input.GetKey(_rightKey))
		{
			_movementX = +1f;
		}
		if (Input.GetKey(_fireKey))
		{
			_useWeapon.Attack(_fireKey);
		}
		if (Input.GetKeyDown(_previousWeaponKey))
		{
			_useWeapon.PreviousWeapon();
		}
		if (Input.GetKeyDown(_nextWeaponKey))
		{
			_useWeapon.NextWeapon();
		}
		if (Input.GetKeyUp(_shieldKey))
		{
			_shield.ActivateShield();
		}
		if (Input.GetKeyUp(_optionsKey))
		{
			if (!_isInOptions)
			{
				_options.OptionsMenuOpen();
				_isInOptions = true;
				return;
			}
			if (_isInOptions)
			{
				_options.OptionsMenuClose();
				ButtonMapping();
				_isInOptions = false;
				return;
			}
		}
		_objectRotation.FollowPositionInPixelCoordinates(Input.mousePosition);
		_objectMovement.Movement(_movementX, _movementY, Time.deltaTime, movementSpeed);
		
	}
	private void ButtonMapping()
	{
		_upKey = controllerCustomization.UpKey();
		_downKey = controllerCustomization.DownKey();
		_leftKey = controllerCustomization.LeftKey();
		_rightKey = controllerCustomization.RightKey();
		_fireKey = controllerCustomization.FireKey();
		_previousWeaponKey = controllerCustomization.PreviousWeaponKey();
		_nextWeaponKey = controllerCustomization.NextWeaponKey();
		_shieldKey = controllerCustomization.ShieldKey();
	}
}
