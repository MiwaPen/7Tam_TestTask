using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;
    private PlayerSpriteController _spriteController;
    private Rigidbody2D _rigidbody;
    private MoveDirection _moveDirection;
    private bool isMoving = false;

    private void Awake()
    {
        _spriteController = gameObject.GetComponent<PlayerSpriteController>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(joystick.Horizontal >= .2f)
        {
            _moveDirection = MoveDirection.Right;
            isMoving = true;
        }else if(joystick.Horizontal <= -.2f)
        {
            _moveDirection = MoveDirection.Left;
            isMoving = true;
        }

        if (joystick.Vertical >= .2f)
        {
            _moveDirection = MoveDirection.Up;
            isMoving = true;
        }
        else if (joystick.Vertical <= -.2f)
        {
            _moveDirection = MoveDirection.Down;
            isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            _spriteController.TryChangeSprite(_moveDirection);
            switch (_moveDirection)
            {
                case MoveDirection.Right:
                    _rigidbody.transform.position += new Vector3(speed, 0);
                    break;
                case MoveDirection.Left:
                    _rigidbody.transform.position += new Vector3(-speed, 0);
                    break;
                case MoveDirection.Down:
                    _rigidbody.transform.position += new Vector3(0, -speed);
                    break;
                case MoveDirection.Up:
                    _rigidbody.transform.position += new Vector3(0, +speed);
                    break;
            }
            isMoving = false;
        }
    }
}
