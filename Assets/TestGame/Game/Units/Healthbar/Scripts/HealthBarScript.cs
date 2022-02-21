using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    private Transform bar;
    private float barMaxValue;

    private void Start()
    {
        bar = this.transform;
        barMaxValue = bar.localScale.x;
    }
    public void UpdateHealthBar(int hp)
    {
        float barValue = (float)hp / 100f * barMaxValue;
        bar.localScale = new Vector3(barValue, bar.localScale.y, bar.localScale.z);
    }
}
