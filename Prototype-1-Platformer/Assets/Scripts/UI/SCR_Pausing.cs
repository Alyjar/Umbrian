using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Pausing : MonoBehaviour
{

    private PauseUIManager uiScript;

    private bool isPaused = false;

    private void Start()
    {
        uiScript = GetComponent<PauseUIManager>();
    }
    public void CheckForPause()
    {
        if (uiScript.pausePressed)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            Debug.Log("Testing Pause");
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
        }
    }
    public void CheckForUnpause()
    {
        if (!uiScript.pausePressed)
        {
            Unpause();
        }
    }

    public void Unpause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        Debug.Log("Testing Pause");
        uiScript.OnUnloadScene(3);
    }
}
