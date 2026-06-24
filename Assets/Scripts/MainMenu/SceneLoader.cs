using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string MAIN_MENU = "MainMenu";
    private const string SAMPLE_SCENE = "SampleScene";

    public void LoadGameScene() {
        SceneManager.LoadScene(SAMPLE_SCENE);
    }
    public void QuitApplication() {
        Application.Quit();
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene(MAIN_MENU);
    }
}
