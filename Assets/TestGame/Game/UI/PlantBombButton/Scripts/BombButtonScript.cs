using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BombButtonScript : MonoBehaviour
{
    [SerializeField] float bombCooldown;
    [SerializeField] TMP_Text text;
    private Button button;

    public Action onBombButtonClick;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnBTNClick);
    }

    private void OnBTNClick()
    {
        BTNCoolDown();
        onBombButtonClick?.Invoke();
    }

    private async void BTNCoolDown()
    {
       
        button.interactable = false;
        DisplayCooldDownOnBTN();
        await UniTask.Delay((int)Mathf.RoundToInt(bombCooldown*1000));
        button.interactable = true;
    }

    private async void DisplayCooldDownOnBTN()
    {
        float coolDownTXT = bombCooldown;
        while (coolDownTXT > 0)
        {
            text.text = "" + coolDownTXT;
            coolDownTXT -= 1;
            await UniTask.Delay(1000);      
        }
        text.text = "";
    }
    
}
