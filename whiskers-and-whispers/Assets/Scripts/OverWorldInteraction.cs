using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldInteraction : MonoBehaviour
{
    public GameObject dialogueBoxPrefab;
    public Transform player;
    public float interactionRadius = 2f;

    private bool hasInteractedWithJunkat = false;
    private bool hasInteractedWithEmployeeSign = false;
    private GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        // Check if interaction with Junkat has occurred before
        if (PlayerPrefs.GetInt("InteractedWithJunkat", 0) == 1)
        {
            hasInteractedWithJunkat = true;
        }

        // Check if interaction with Employee Sign has occurred before
        if (PlayerPrefs.GetInt("InteractedWithEmployeeSign", 0) == 1)
        {
            hasInteractedWithEmployeeSign = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check player proximity to Overworld-junkat
        if (!hasInteractedWithJunkat && Vector3.Distance(player.position, transform.position) <= interactionRadius)
        {
            // Show dialogue box
            if (dialogueBox == null)
            {
                dialogueBox = Instantiate(dialogueBoxPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
                dialogueBox.GetComponentInChildren<TextMesh>().text = "Follow me to the storage room to the right";
            }
        }
        else
        {
            // Hide dialogue box if player is not nearby or interaction has occurred before
            if (dialogueBox != null)
            {
                Destroy(dialogueBox);
                dialogueBox = null;
            }
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionRadius)
        {
            if (!hasInteractedWithJunkat)
            {
                PlayerPrefs.SetInt("InteractedWithJunkat", 1);
                hasInteractedWithJunkat = true;
            }
            else if (!hasInteractedWithEmployeeSign)
            {
                SceneManager.LoadScene("Backroom");
                PlayerPrefs.SetInt("InteractedWithEmployeeSign", 1);
                hasInteractedWithEmployeeSign = true;
            }
        }
    }
}
