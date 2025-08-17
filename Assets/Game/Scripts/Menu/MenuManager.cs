using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField, Scene] private int _gameScene;
    public void StartButton() => SceneManager.LoadScene(_gameScene);
    public void OpenPanel(GameObject panel) => panel.SetActive(true);
    public void ClosePanel(GameObject panel) => panel.SetActive(false);
}
