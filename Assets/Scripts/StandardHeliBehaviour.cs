using UnityEngine;
using System.Collections;

// CLass to control the helicopter
public class StandardHeliBehaviour : MonoBehaviour
{

    protected Rigidbody rb;


    // Start is called before the first frame update
    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }


    //TODO on next version: Set visibility to private

    public void OnThrustUpClicked(int direction)
    {
        if (rb.velocity.magnitude < 1 || rb.velocity.y < -1)
        {
            Vector3 vector = transform.up * -0.02f * direction * -1;
            rb.velocity += vector;
        }



    }


    public void OnThrustForwardClicked(int direction)
    {
        rb.AddTorque(transform.right * 0.002f * direction);

        if (rb.velocity.magnitude < 1)
        {
            Vector3 vector = transform.forward * -0.02f * direction * -1;
            rb.velocity += vector;
        }



    }


    public void OnUpClicked()
    {
        rb.AddTorque(transform.right * 0.002f);



    }

    public void OnDownClicked()
    {
        rb.AddTorque(transform.right * 0.002f * -1);



    }


    public void OnLeftClicked()
    {
        rb.AddTorque(transform.up * 0.002f * -1);



    }

    public void OnRightClicked()
    {
        rb.AddTorque(transform.up * 0.002f);


    }

    // Called by ButtonListener
    internal void ButtonPressed(string name)
    {
        switch (name)
        {
            case "BtnUp":
                OnUpClicked();
                break;
            case "BtnDown":
                OnDownClicked();
                break;
            case "BtnLeft":
                OnLeftClicked();
                break;
            case "BtnRight":
                OnRightClicked();
                break;
            case "BtnThrustUp":
                OnThrustUpClicked(1);
                break;
            case "BtnThrustDown":
                OnThrustUpClicked(-1);
                break;
            case "BtnThrustForward":
                OnThrustForwardClicked(1);
                break;
            case "BtnThrustBackward":
                OnThrustForwardClicked(-1);
                break;
            default:
                break;
        }
    }

}
