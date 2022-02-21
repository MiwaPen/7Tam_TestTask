using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider2D))]
public class EnemyFieldOfView : MonoBehaviour
{
    private EnemyBehaviour behaviour;
    private NavMeshAgent _agent;

    private void Start()
    {
        behaviour = gameObject.GetComponentInParent<EnemyBehaviour>();
        _agent = gameObject.GetComponentInParent<NavMeshAgent>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_agent.enabled == false) return;

        PlayerMovementController player;
        if(other.TryGetComponent<PlayerMovementController>(out player))
        {
          
            behaviour.ChangeState(UnitState.Angry);
            behaviour.ChangeTarger(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_agent.enabled == false) return;

        PlayerMovementController player;
        if (other.TryGetComponent<PlayerMovementController>(out player))
        {
            behaviour.ChangeState(UnitState.Normal);
            behaviour.SetRandomTarget();
        }
    }
}
