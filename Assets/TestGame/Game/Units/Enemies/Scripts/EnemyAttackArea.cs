using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField] private int damage;
    private bool canAttack = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovementController player;
        if (other.TryGetComponent<PlayerMovementController>(out player))
        {
            canAttack = true;
            IDamageable playerHealth;
            player.gameObject.TryGetComponent<IDamageable>(out playerHealth);
            TryAttackPlayer(playerHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovementController player;
        if (other.TryGetComponent<PlayerMovementController>(out player))
        {
            canAttack = false;
        }
    }

    private async void TryAttackPlayer(IDamageable player)
    {
        while (canAttack)
        {
            if (player == null)
            {
                canAttack = false;
                return;
            }
            if (canAttack)
                player.ApplyDamage(damage);
            await UniTask.Delay(1000);
            
        }
    }
}
