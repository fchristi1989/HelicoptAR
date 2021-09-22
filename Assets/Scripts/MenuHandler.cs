using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Class handling the menu panels:
// -> Vehicle selection
// -> Starting the AR scene
// -> Return to main menu
public class MenuHandler : MonoBehaviour
{
    private const int HELISTOSELECT = 5;
    private string[] descriptions = new string[]
    {
        "Red Razor - default test helicopter",
        "Flying Saucer - UFO variant",
        "Sikorsky S-64 Skycrane - by Pavan Ganti",
        "Kamov KA-52 - by Pavan Ganti",
        "Eurocopter EC130B4 - by Pavan Ganti"
    };

    [SerializeField]
    private GameObject[] heliPrefabs = null;

    private int currentSelection = 0;
    private GameObject currentHeli = null;
    

    // Start is called before the first frame update
    void Start()
    {
        UpdateSelection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuStart()
    {
        GlobalParameters.HeliID = currentSelection;
        
        SceneManager.LoadScene("ARScene");
    }

    public void OnMenuBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Switch helicopter
    public void OnMenuLeft()
    {
        if (currentSelection == 0)
            return;

        currentSelection--;
        UpdateSelection();
    }

    // Switch helicopter
    public void OnMenuRight()
    {
        if (currentSelection == HELISTOSELECT - 1)
            return;

        currentSelection++;
        UpdateSelection();
    }

    // Select a new helicopter type
    private void UpdateSelection()
    {

        if (currentHeli != null)
            Destroy(currentHeli);

        currentHeli = Instantiate(heliPrefabs[currentSelection]);


        GameObject textObject = GameObject.Find("Description");
        Text text = textObject.GetComponent<Text>();
        text.text = descriptions[currentSelection];
        

    }
}
