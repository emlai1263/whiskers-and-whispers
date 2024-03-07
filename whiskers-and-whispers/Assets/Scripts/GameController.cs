using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BackgroundController backgroundController;
    public BottomBarController bottomBar;
    private State state = State.IDLE;
    private enum State
    {
        IDLE, ANIMATE
    }

    void Start()
    {
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (state == State.IDLE && bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentece())
                {
                    PlayScene(currentScene.nextScene);
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                }
                else
                {
                    bottomBar.PlayNextScentence();
                }
            }
        }
    }

    private void PlayScene(StoryScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(StoryScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        //bottomBar.Hide();
        yield return new WaitForSeconds(1f);
        backgroundController.SwitchImage(scene.background);
        yield return new WaitForSeconds(1f);
        //bottomBar.ClearText();
        //bottomBar.Show();
        //yield return new WaitForSeconds(1f);
        bottomBar.PlayScene(scene);
        state = State.IDLE;

    }
}
