using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputAction pauseAction;
    [SerializeField] GameObject pauseMenu;
    bool gamePaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            

            if (gamePaused)
            {
              
                Resume();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Pause();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
        }
    }


    public void Pause()
    {
        gamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }


}
