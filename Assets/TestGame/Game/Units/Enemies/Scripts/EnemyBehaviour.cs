using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float normalSpeed;
    [SerializeField] private float angrySpeed;
    [SerializeField] private float dirtySpeed;
    [SerializeField] private float stunTime;
    [Inject] private EnemiesPathMarkerList _markerList;
    private UnitState _currentState;
    private MoveDirection _currentDirection;
    private EnemySpriteController _spriteController;
    private Vector2 _targetPos;
    private Vector2 _pos;
    private Vector2 _lastpos;
    private Transform _currentTarget;
    private NavMeshAgent _agent;
    private float _currentSpeed;
    private bool canChangeState = true;

    void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        _spriteController = gameObject.GetComponent<EnemySpriteController>();
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _currentSpeed = normalSpeed;
        _agent.speed = _currentSpeed;
        _currentDirection = MoveDirection.Right;
        SetRandomTarget();
    }
    private void FixedUpdate()
    {
        _targetPos = new Vector2(
            _currentTarget.position.x,
            _currentTarget.position.y);
        _pos = new Vector2(
           this.transform.position.x,
           this.transform.position.y);
        if (_pos == _targetPos)
        {
            SetRandomTarget();
        }

        if(_currentState == UnitState.Angry)
        {
            _agent.SetDestination(_currentTarget.position);
        }
        ChechMoveDirection();
        _lastpos = _pos;
    }
    
    private void ChechMoveDirection()
    {       
        if ((_pos.x - _lastpos.x) > (_pos.y - _lastpos.y))
        {
            if (_pos.x > _lastpos.x)
            {
                _currentDirection = MoveDirection.Right;
            }
            else
            {
                _currentDirection = MoveDirection.Left;
            }
        }
        else if  ((_pos.x - _lastpos.x) < (_pos.y - _lastpos.y))
        {
            if (_pos.y > _lastpos.y)
            {
                _currentDirection = MoveDirection.Up;
            }
            else
            {
                _currentDirection = MoveDirection.Down;
            }
        }
        _spriteController.TryChangeSprite(_currentDirection, _currentState);
    }
    public void SetRandomTarget()
    {
        System.Random random = new System.Random();
        int nextTargetId = random.Next(0, _markerList.PathMarkerList.Count);
        _currentTarget = _markerList.PathMarkerList[nextTargetId];
        ChangeTarger(_currentTarget);
    }

    public void ChangeTarger(Transform newTarget)
    {
        _currentTarget = newTarget;
        _agent.SetDestination(_currentTarget.position);
    }

    public void ChangeState(UnitState state)
    {
        if (canChangeState == false) return;

        _currentState = state;
        ChangeSpeed();
        _spriteController.TryChangeSprite(_currentDirection,_currentState);
    }

    private void ChangeSpeed()
    {
        switch (_currentState)
        {
            case UnitState.Normal:
                _currentSpeed = normalSpeed;
                break;
            case UnitState.Angry:
                _currentSpeed = angrySpeed;
                break;
            case UnitState.Dirty:
                _currentSpeed = dirtySpeed;
                break;
        }
        _agent.speed = _currentSpeed;
    }

    public async void Stun()
    {
        ChangeState(UnitState.Dirty);
        canChangeState = false;
        await UniTask.Delay((int)Mathf.RoundToInt(stunTime * 1000));

        canChangeState = true;
        ChangeState(UnitState.Normal);
        SetRandomTarget();
    }
}
