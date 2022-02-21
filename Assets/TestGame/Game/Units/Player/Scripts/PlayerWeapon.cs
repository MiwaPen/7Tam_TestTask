using UnityEngine;
using Zenject;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private BombButtonScript bombButton;
    [Inject] DiContainer diContainer;
    
    private void OnEnable()
    {
        bombButton.onBombButtonClick += PlantBomb;
    }

    private void OnDisable()
    {
        bombButton.onBombButtonClick -= PlantBomb;
    }
    private void PlantBomb()
    {
        if (this.gameObject == null) return;
        GameObject newBomb = diContainer.InstantiatePrefab(bomb);
        newBomb.transform.position = this.transform.position;
    }
}
