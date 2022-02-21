using UnityEngine;
using Zenject;

public class PlayerHealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] HealthBarScript healthBar;
    [Inject] private AudioController audioController;
    private int _maxHealth;

    private void Start()
    {
        _maxHealth = health;
    }
    public void ApplyDamage(int damage)
    {
        if (this.gameObject == null) return;

        health = Mathf.Clamp(health - damage, 0, _maxHealth);
        audioController.PlayPlayerApplyDamageSound();
        CheckHealth—ondition();
    }

    private void CheckHealth—ondition()
    {
        if (health <= 0)
        {
            audioController.PlayLoseSound();
            Destroy(this.gameObject);
        }
        healthBar.UpdateHealthBar(health);
    }
}
