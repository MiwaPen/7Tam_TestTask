using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemySpriteController : MonoBehaviour
{
    [SerializeField] List<Sprite> normalSprites;
    [SerializeField] List<Sprite> angrySprites;
    [SerializeField] List<Sprite> dirtySprites;
    private SpriteRenderer _spriteRenderer;
    private MoveDirection _currentMoveDir;
    private UnitState _currentState;
    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        TryChangeSprite(MoveDirection.Right,UnitState.Normal);
    }

    private void Update()
    {
        
    }

    public void TryChangeSprite(MoveDirection direction,UnitState state)
    {
        if (_currentMoveDir == direction && _currentState == state) return;

        _currentMoveDir = direction;
        _currentState = state;

        switch (state)
        {
            case UnitState.Normal:
                ChangeSprite(normalSprites);
                break;
            case UnitState.Angry:
                ChangeSprite(angrySprites);
                break;
            case UnitState.Dirty:
                ChangeSprite(dirtySprites);
                break;
        }
    }

    private void ChangeSprite(List<Sprite> sprites)
    {
        switch (_currentMoveDir)
        {
            case MoveDirection.Right:
                _spriteRenderer.sprite = sprites[0];

                break;
            case MoveDirection.Left:
                _spriteRenderer.sprite = sprites[1];

                break;
            case MoveDirection.Down:
                _spriteRenderer.sprite = sprites[2];
 
                break;
            case MoveDirection.Up:
                _spriteRenderer.sprite = sprites[3];
                break;
        }
    }
}
