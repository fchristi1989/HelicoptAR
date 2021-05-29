using UnityEngine;
using System.Collections;

public class RotorBehaviourRight : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 500);

    }
}
