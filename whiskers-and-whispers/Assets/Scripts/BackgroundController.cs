using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public List<Image> backgrounds;
    private int switchBackground = 0;
    public Animator animator;

    public void SwitchImage(Sprite sprite)
    {
        switchBackground++;
        backgrounds[switchBackground].sprite = sprite;
        if (switchBackground == 1)
        {
            animator.SetTrigger("SwitchFirst");
        }
        else if (switchBackground == 2)
        {
            animator.SetTrigger("SwitchSecond");
        }
        else if (switchBackground == 3)
        {
            animator.SetTrigger("SwitchThird");
        }
        else if (switchBackground == 4)
        {
            animator.SetTrigger("SwitchFourth");
        }
    }

    public void SetImage(Sprite sprite)
    {
        backgrounds[switchBackground].sprite = sprite;
    }
}
