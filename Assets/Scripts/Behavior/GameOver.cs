using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Canvas gameOverScreen;
    [SerializeField] private GameObject gun;

    private void Start() {
        gameOverScreen.gameObject.SetActive(false);
    }

    private void OnDestroy() {

        if (gameOverScreen != null) {
            gameOverScreen.gameObject.SetActive(true);
            gun.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
