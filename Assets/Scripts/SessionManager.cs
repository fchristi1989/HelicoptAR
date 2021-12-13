using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


// Class to manage the AR session
public class SessionManager : MonoBehaviour
{

    [SerializeField]
    private GameObject [] heliPrefabs = null;

    [SerializeField]
    private GameObject dotsPrefab = null;

    private bool vehiclePlaced = false;

    private GameObject heli = null;
    private GameObject dotsGround = null;
    //private GameObject dotsCeiling = null;
    //private GameObject dotsForward = null;

    private Vector2 screenCenter;
    private ARRaycastManager aRRaycastManager = null;


    // Start is called before the first frame update
    void Start()
    {
        dotsGround = Instantiate(dotsPrefab);
        dotsGround.SetActive(false);
        /*dotsCeiling = Instantiate(dotsPrefab);
        dotsCeiling.SetActive(false);
        dotsForward = Instantiate(dotsForward);
        dotsForward.SetActive(false);*/

        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    // Check for initial helicopter positioning
    void Update()
    {
        if (aRRaycastManager == null)
            aRRaycastManager = FindObjectOfType<ARRaycastManager>();

        placeVehicle();
        controlDots();
    }

    private void placeVehicle()
    {
        if (vehiclePlaced)
            return;

        if (Input.touchCount == 0)
            return;

        Touch touch = Input.touches[0];
        Raycast raycast = new Raycast(aRRaycastManager, touch.position);

        if (raycast.TargetPosition == null)
            return;

        Vector3 position = new Vector3(raycast.TargetPosition.x, raycast.TargetPosition.y + 0.15f, raycast.TargetPosition.z);
        heli = Instantiate(heliPrefabs[GlobalParameters.HeliID], position, new Quaternion());
        heli.GetComponent<AudioSource>().mute = false;
        heli.GetComponent<Rigidbody>().useGravity = true;

        vehiclePlaced = true;
        GameObject textObject = GameObject.Find("TapText");
        textObject.SetActive(false);
    }

    private void controlDots()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (!vehiclePlaced)
        {            
            if (aRRaycastManager.Raycast(screenCenter, hits))
            {
                dotsGround.transform.position = hits[0].pose.position;
                dotsGround.SetActive(true);
            }
            else
                dotsGround.SetActive(false);
        }
        else
        {
            SetDots(-Vector3.up, dotsGround);
            //SetDots(Vector3.up, dotsCeiling);
            //SetDots(heli.transform.forward, dotsForward);
        }
    }

    private void SetDots(Vector3 vector, GameObject dots)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        Ray ray = new Ray();
        ray.origin = heli.transform.position;
        ray.direction = vector;

        if (aRRaycastManager.Raycast(ray, hits))
        {
            dots.transform.position = hits[0].pose.position;
            dots.transform.rotation = hits[0].pose.rotation;
            dots.SetActive(true);
        }
        else
        {
            dots.SetActive(false);
        }
    }

    public void OnMenuBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*
    // Toggle visualisation of detected surfaces: Unused feature at the moment
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
    */

}