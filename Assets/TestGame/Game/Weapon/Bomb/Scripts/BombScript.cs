using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class BombScript : MonoBehaviour
{
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionDelay;
    [SerializeField] int explosionDamage;
    [SerializeField] private GameObject boomEffect;
    [Inject] AudioController audioController;
    void Start()
    {
        audioController.PlayBombPlantSound();
        ExplodeWithDelay();
    }

    private async void ExplodeWithDelay()
    {
        await UniTask.Delay((int)Mathf.RoundToInt(explosionDelay * 1000));
        audioController.PlayExplosionSound();
        RaycastHit2D[] hits =  Physics2D.CircleCastAll(this.transform.position, explosionRadius, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            IDamageable damageableObject;
            if(hit.transform.gameObject.TryGetComponent<IDamageable>(out damageableObject))
            {
               
                damageableObject.ApplyDamage(explosionDamage);
            }
        }
        GameObject newBoom = Instantiate(boomEffect, this.transform.position, Quaternion.identity);
        Destroy(newBoom,1);
        Destroy(this.gameObject);
    }
}
