using UnityEngine;

public class MouseLockController : MonoBehaviour
{
    private bool isCursorLocked = true;

    private void Start()
    {
        SetCursorState(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorLocked = !isCursorLocked;
            SetCursorState(isCursorLocked);
        }
    }

    private void SetCursorState(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;            
        }
    }
}
