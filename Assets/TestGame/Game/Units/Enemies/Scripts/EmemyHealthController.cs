using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(EnemyBehaviour),typeof(NavMeshAgent))]
public class EmemyHealthController : MonoBehaviour,IDamageable
{
    [SerializeField] private int health;
    [SerializeField] HealthBarScript healthBar;
    [Inject] private AudioController audioController;
    private int _maxHealth;
    private EnemyBehaviour _behaviour;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _behaviour = gameObject.GetComponent<EnemyBehaviour>();
        _maxHealth = health;
    }
    public void ApplyDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, _maxHealth);
        healthBar.UpdateHealthBar(health);
        CheckHealth—ondition();
        audioController.PlayEnemyApplyDamageSound();
        if (_agent.enabled == false) return;
        _behaviour.Stun();
    }

    private void CheckHealth—ondition()
    {
        if (health <= 0)
        {
            _agent.enabled = false;
            Destroy(this.gameObject);
        }
    }
}
