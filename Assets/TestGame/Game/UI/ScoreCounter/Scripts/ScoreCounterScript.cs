using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounterScript : MonoBehaviour
{
    private TMP_Text _text;
    private int _score;

    private void Start()
    {
        _text = gameObject.GetComponent<TMP_Text>();
        _score = 0;
        _text.text = "" + _score;
    }

    public void IncreaseScore()
    {
        _score++;
        _text.text = "" + _score;
    }
}
