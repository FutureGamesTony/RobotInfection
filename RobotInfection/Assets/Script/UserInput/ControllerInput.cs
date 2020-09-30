using UnityEngine;

[RequireComponent(typeof(ObjectMovement))]
[RequireComponent(typeof(ObjectRotation))]
[RequireComponent(typeof(UseWeapon))]
public class ControllerInput : MonoBehaviour
{
	[Range(1, 100)]
	public float movementSpeed = 100.0f;
	public ControllerCustomization controllerCustomization;
	public Options options;

	private float _movementX;
	private float _movementY;
	private bool _isInOptions = false;
	
	private KeyCode _options = KeyCode.Escape;
	private KeyCode _upKey;
	private KeyCode _downKey;
	private KeyCode _leftKey;
	private KeyCode _rightKey;
	private KeyCode _fireKey;
	private KeyCode _previousWeaponKey;
	private KeyCode _nextWeaponKey;


	private ObjectMovement _objectMovement;
	private ObjectRotation _objectRotation;
	private GameObject _weapon;
	private UseWeapon _useWeapon;


	private void Awake()
	{
		_upKey = controllerCustomization.UpKey();
		_downKey = controllerCustomization.DownKey();
		_leftKey = controllerCustomization.LeftKey();
		_rightKey = controllerCustomization.RightKey();
		_fireKey = controllerCustomization.FireKey();
		_previousWeaponKey = controllerCustomization.PreviousWeaponKey();
		_nextWeaponKey = controllerCustomization.NextWeaponKey();
		controllerCustomization.gameObject.SetActive(false);
		_objectMovement = GetComponent < ObjectMovement>();
		_objectRotation = GetComponent<ObjectRotation>();
		_useWeapon = GetComponent<UseWeapon>();
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
			Debug.Log("FireKey pressed: " + _fireKey);
			_useWeapon.Attack(_fireKey);
		}
		if (Input.GetKeyUp(_options))
		{
			if (!_isInOptions)
			{
				options.OptionsMenuOpen();
				_isInOptions = true;
				return;
			}
			if (_isInOptions)
			{
				options.OptionsMenuClose();
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
	}
}
