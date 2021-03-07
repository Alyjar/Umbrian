using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{

    [Tooltip("Script that has the pausing related code.")]
    private SCR_Pausing pausingScript;
    public bool pausePressed = false;
    public GameObject ui;

    private void Start()
    {
        pausingScript = GetComponent<SCR_Pausing>();
    }

    // Used whenever the play button has been pressed by the user.
    public void OnPlayPress()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OnOptionsPress() => SceneManager.LoadScene("SCN_OptionsScene", LoadSceneMode.Additive);
    public void OnControlsPress() => SceneManager.LoadScene("SCN_ControlsScene", LoadSceneMode.Additive);
    public void OnMainMenuPress() => SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    public void OnQuitPress() => Application.Quit();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePressed)
            {
                pausePressed = true;
                Pause();
                Debug.Log("Pause: True");
            }

            else
            {
                pausePressed = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Resume();
                Debug.Log("Pause: False");
            }
        }
    }
    public void OnUnloadScene(int sceneNumber)
    {
        SceneManager.UnloadSceneAsync(sceneNumber);
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        Debug.Log("Testing Pause");
        ui.SetActive(true);
    }

    public void Resume()
    {
        pausePressed = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        Debug.Log("Testing Resume");
        ui.SetActive(false);
    }
}
