using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [Inject] private EnemiesPathMarkerList _markerList;
    [Inject] DiContainer diContainer;
    [SerializeField] private ItemScript item;
    [SerializeField] private ScoreCounterScript scoreCounter;
    private Transform _itemPos;

    private void Start()
    {
        TrySpawnItem();
    }
    private void TrySpawnItem()
    {
        SetRandomPos();
        GameObject newItem = diContainer.InstantiatePrefab(item);
        newItem.transform.position = _itemPos.position;
        newItem.GetComponent<ItemScript>().onItemPick += TrySpawnItem;
        newItem.GetComponent<ItemScript>().onItemPick += scoreCounter.IncreaseScore;
    }

    public void SetRandomPos()
    {
        System.Random random = new System.Random();
        int nextTargetId = random.Next(0, _markerList.PathMarkerList.Count);
        _itemPos = _markerList.PathMarkerList[nextTargetId];
    }
}
