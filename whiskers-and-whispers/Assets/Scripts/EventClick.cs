using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SignEventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    // private void Awake()
    // {
    //     materialApplier GetComponent<MaterialApplier>();
    // }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("StorageRoom");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}

