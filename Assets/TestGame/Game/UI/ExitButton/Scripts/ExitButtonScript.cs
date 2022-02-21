using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class ExitButtonScript : MonoBehaviour
{
    private Button _exit;
    [Inject] AudioController audioController;
    void Start()
    {
        _exit = gameObject.GetComponent<Button>();
        _exit.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        audioController.PlayExitSound();
        Application.Quit();
    }
}
