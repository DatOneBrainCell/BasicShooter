using UnityEngine;

public class BossDeath : MonoBehaviour
{
    //[SerializeField] private GameObject playerWinScreenGameObject;
    //[SerializeField] private Canvas playerWinScreen;
    private GameObject enemySpawner;

    //private const string WIN_SCREEN = "WinScreen";
    private const string SPAWNER = "Spawner";

    private void Awake() {

        //playerWinScreenGameObject = GameObject.FindWithTag(WIN_SCREEN);
        enemySpawner = GameObject.FindGameObjectWithTag(SPAWNER);
    }

    private void Start() {
        //playerWinScreen = playerWinScreenGameObject.GetComponent<Canvas>();
    }

    private void OnDestroy() {
        
        //if(playerWinScreen != null) {
        //    playerWinScreen.gameObject.SetActive(true);
        //    enemySpawner.gameObject.SetActive(false);
        //}

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
