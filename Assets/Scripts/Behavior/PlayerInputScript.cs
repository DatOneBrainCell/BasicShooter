using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";


    public float GetMouseXAxis() {

        return Input.GetAxisRaw(MOUSE_X);
    }

    public float GetMouseYAxis() {

        return Input.GetAxisRaw(MOUSE_Y);
    }

    public bool GetRightMouseKey() {

        return Input.GetKey(KeyCode.Mouse1);
    }
}
