using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


// Class attached to buttons to listen for pressing and releasing
public class ButtonListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool buttonPressed;

    // Called when button pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    // Called when button released
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