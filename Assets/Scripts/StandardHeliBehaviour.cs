using UnityEngine;
using System.Collections;

// CLass to control the helicopter
public class StandardHeliBehaviour : MonoBehaviour
{
    private const float MOVINGSPEED = 0.02f;
    private const float TURNINGSPEED = 0.002f;
    private const float SINKSPEED = 0.0005f;


    protected Rigidbody rb;


    // Start is called before the first frame update
    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }


    //TODO on next version: Set visibility to private


    private void OnThrustUpClicked(int direction)
    {
        if (rb.velocity.magnitude < 1 || rb.velocity.y < -1)
        {
            Vector3 vector = transform.up * MOVINGSPEED * direction;
            rb.velocity += vector;
        }



    }

    // The idea is to not only let the heli go strait forward, but move him a litte diagonally downwards on the ling run to make adjustment necessary 
    private void OnThrustForwardClicked(int direction)
    {

        // Sink the helicopter
        rb.AddTorque(transform.right * SINKSPEED * direction);

        if (rb.velocity.magnitude < 1)
        {
            /*
            // Upward vector
            Vector3 vector = transform.right * direction * DIAGONALSPEED;
            rb.velocity += vector;
            */

            // Forward vector
            Vector3 vector = transform.forward * MOVINGSPEED * direction;
            rb.velocity += vector;
        }



    }


    private void OnUpClicked()
    {
        rb.AddTorque(transform.right * TURNINGSPEED);



    }

    private void OnDownClicked()
    {
        rb.AddTorque(transform.right * TURNINGSPEED * -1);



    }


    private void OnLeftClicked()
    {
        rb.AddTorque(transform.up * TURNINGSPEED * -1);



    }

    private void OnRightClicked()
    {
        rb.AddTorque(transform.up * TURNINGSPEED);


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
