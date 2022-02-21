using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    private SpriteRenderer _spriteRenderer;
    private MoveDirection currentMoveDir;
    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        TryChangeSprite(MoveDirection.Right);
    }

    public void TryChangeSprite(MoveDirection direction)
    {
        if (currentMoveDir == direction) return;
        currentMoveDir = direction;
        ChangeSprite();
    }
    private void ChangeSprite()
    {
        switch (currentMoveDir)
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
