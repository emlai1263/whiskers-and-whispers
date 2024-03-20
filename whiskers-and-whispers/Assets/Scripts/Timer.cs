using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime;
    public TextMeshProUGUI currentTimeText; // Use TextMeshProUGUI instead of Text
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTimeText.text = (Mathf.RoundToInt(currentTime)).ToString();

        if(currentTime >= 30){
			SceneManager.LoadSceneAsync(0);
		}
    }
    
}
