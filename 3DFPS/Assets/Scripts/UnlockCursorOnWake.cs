using UnityEngine;

public class UnlockCursorOnWake : MonoBehaviour
{
    void Start()
    {
        // Call the function to unlock the cursor
        UnlockCursor();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Check if the application regained focus
        if (hasFocus)
        {
            // Call the function to unlock the cursor
            UnlockCursor();
        }
    }

    void UnlockCursor()
    {
        // Unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
