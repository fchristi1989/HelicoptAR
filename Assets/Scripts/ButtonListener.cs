using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool buttonPressed;


    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!buttonPressed)
            return;

        StandardHeliBehaviour hb = FindObjectOfType(typeof(StandardHeliBehaviour)) as StandardHeliBehaviour;
        hb.ButtonPressed(gameObject.name);
    }
}