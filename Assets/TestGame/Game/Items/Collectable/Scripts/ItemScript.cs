using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class ItemScript : MonoBehaviour, ICollectable
{
    [Inject] private AudioController audioController;
    public Action onItemPick;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovementController player;
        if (other.TryGetComponent<PlayerMovementController>(out player))
        {
            PickItem();
        }
    }
    public void PickItem()
    {
        audioController.PlayPickItemSound();
        onItemPick?.Invoke();
        Destroy(this.gameObject);
    }
}
