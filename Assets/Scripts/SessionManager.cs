using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SessionManager : MonoBehaviour
{

    [SerializeField]
    private GameObject [] heliPrefabs = null;

    private bool vehiclePlaced = false;
    private bool surfaceViewed = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vehiclePlaced)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            ARRaycastManager aRRaycastManager = GetComponent<ARRaycastManager>();
            Raycast raycast = new Raycast(aRRaycastManager, touch.position);

            Vector3 position = new Vector3(raycast.TargetPosition.x, raycast.TargetPosition.y + 0.15f, raycast.TargetPosition.z);
            GameObject heli = Instantiate(heliPrefabs[GlobalParameters.HeliID], position, new Quaternion());
            heli.GetComponent<AudioSource>().mute = false;
            heli.GetComponent<Rigidbody>().useGravity = true;



            vehiclePlaced = true;
            GameObject textObject = GameObject.Find("TapText");
            textObject.SetActive(false);

        }
    }

    public void OnMenuBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnToggleSurface()
    {
        ARPlaneManager manager = FindObjectOfType(typeof(ARPlaneManager)) as ARPlaneManager;

        if (surfaceViewed)
        {
            foreach (var plane in manager.trackables)
            {
                foreach (Renderer renderer in plane.gameObject.GetComponents<Renderer>())
                {
                    renderer.enabled = false;

                }

            }

            surfaceViewed = false;
        }
        else
        {
            foreach (var plane in manager.trackables)
            {
                foreach (Renderer renderer in plane.gameObject.GetComponents<Renderer>())
                {
                    renderer.enabled = true;

                }

            }

            surfaceViewed = true;

        }
    }

}