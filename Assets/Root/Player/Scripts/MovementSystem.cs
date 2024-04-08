using Root.Player.Scripts.Input;
using UnityEngine;

namespace Root.Player.Scripts
{
    public class MovementSystem : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _maxLeftRotationAngle = -55f;
        [SerializeField] private float _maxRightRotationAngle = 55f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _stopDistance;

        private float _leftBoundary;
        private float _rightBoundary;
        private float _playerWidth;
        private Quaternion _startRotation;
        private Vector3 _moveDirection;

        private const float _rotaionX = 0f;
        private const float _rotaionZ = 180f;

        private IInputSystem _currentInput;

        private void Start()
        {
            _playerWidth = GetComponent<Renderer>().bounds.size.x;
            
            Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _leftBoundary = screenBounds.x * -1f + _playerWidth / 2f;
            _rightBoundary = screenBounds.x - _playerWidth / 2f;
            
            _startRotation = transform.rotation;
            CheckPlatform();
        }

        private void Update()
        {
            if (_currentInput.ButtonMovePressed())
            {
                Vector3 targetPosition = Camera.main.ScreenToWorldPoint(_currentInput.TouchPosition());
                targetPosition.y = transform.position.y;
                targetPosition.z = transform.position.z;
                if (!(Vector3.Distance(transform.position, targetPosition) < _stopDistance))
                {
                    Move(targetPosition);
                    Rotate();
                }
            }
            else
            {
                RotateToDefault();
            }
        }

        private void CheckPlatform()
        {
#if UNITY_IOS || UNITY_ANDROID
            _currentInput = new MobileInput();
#endif
#if UNITY_EDITOR || UNITY_STANDALONE          
            _currentInput = new PCInput();
#endif
        }
        
        private void Move(Vector3 targetPosition)
        {
            targetPosition.x = Mathf.Clamp(targetPosition.x, _leftBoundary, _rightBoundary);

            _moveDirection = (targetPosition - transform.position).normalized;

            transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime, Space.World);
        }

        private void Rotate()
        {
            float targetRotationAngle = _moveDirection.x < 0 ?  _maxRightRotationAngle : _maxLeftRotationAngle;
            
            Quaternion rotation = Quaternion.Euler(_rotaionX, targetRotationAngle,_rotaionZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }

        private void RotateToDefault()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _startRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}
