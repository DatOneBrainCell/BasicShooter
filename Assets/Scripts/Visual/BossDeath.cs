using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [SerializeField] private GameObject playerWinScreenGameObject;
    private Canvas playerWinScreen;
    private GameObject enemySpawner;

    private const string WIN_SCREEN = "WinScreen";
    private const string SPAWNER = "Spawner";

    private void Awake() {

        //playerWinScreenGameObject = GameObject.FindWithTag(WIN_SCREEN);
        enemySpawner = GameObject.FindGameObjectWithTag(SPAWNER);
    }

    private void Start() {
        playerWinScreen = playerWinScreenGameObject.GetComponent<Canvas>();
    }

    private void OnDestroy() {
        Debug.Log("Destroyed");
        if(playerWinScreen != null) {
            playerWinScreen.gameObject.SetActive(true);
            enemySpawner.gameObject.SetActive(false);
            Debug.Log("Yes");
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
