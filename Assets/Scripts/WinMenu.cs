using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;

    public void WinScreen()
    {
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPaused = true;
            return;
        }
    }
}
