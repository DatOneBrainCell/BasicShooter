using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Canvas gameOverScreen;
    [SerializeField] private GameObject gun;

    private void OnDestroy() {

        //gameOverScreen.gameObject.SetActive(true);
        //gun.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
