using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSwitchScene : MonoBehaviour
{
    // public bool clickable = true;
    // public bool disableAfterClick = false;
    public void GoToScene(string sceneName)
    {
        // if (!clickable)  // do nothing if button is not clickable
        // {
        //     return;
        // }
        SceneManager.LoadScene(sceneName);
        // if (disableAfterClick)  // for buttons that we only want clickable ONCE
        // {
        //     clickable = false;
        //     GetComponent<Button>().interactable = false; // Disable the button visually
        // }
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}
