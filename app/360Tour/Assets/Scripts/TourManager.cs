using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static ButtonClick;
// using (ButtonClick button1 = new ButtonClick());

public class TourManager : MonoBehaviour
{
    //List of sites
    public GameObject[] objSites;
    //Main menu
    public GameObject canvasMainMenu;
    //Profile
    public GameObject canvasProfile;
    //Should the camera move
    public bool isCameraMove = false;

    // Start is called before the first frame update
    void Start()
    {
        ReturnToMenu();
        // ReturnToProfile();

        // if(ButtonClick.Click() == true)
        // {
        //     ReturnToProfile();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if(isCameraMove)
        {

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ReturnToMenu();
            }

            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, 100.0f))
                {
                    if(hit.transform.gameObject.tag == "Sound")
                    {
                        hit.transform.gameObject.GetComponent<MediaAudio>().PlayAudio();
                    }
                    else if(hit.transform.gameObject.tag == "Image")
                    {
                        hit.transform.gameObject.GetComponent<MediaImage>().ShowImage();
                    }
                    else if(hit.transform.gameObject.tag == "Video")
                    {
                        hit.transform.gameObject.GetComponent<MediaVideo>().ShowVideo();
                    }
                }
            }
        }
    }

    public void LoadSite(int siteNumber)
    {
        //Show site
        objSites[siteNumber].SetActive(true);
        //Hide menu
        canvasMainMenu.SetActive(true);
        //Enable the camera
        isCameraMove = true;
        GetComponent<CameraController>().ResetCamera();
    }

    public void ReturnToMenu()
    {
        //Show menu
        canvasMainMenu.SetActive(true);
        //Hide sites
        for(int i = 0; i < objSites.Length; i++)
        {
            objSites[i].SetActive(false);
        }

        //Disable the camera
        isCameraMove = false;
    }

    public void ReturnToProfile()
    {
        //Show profile
        canvasMainMenu.SetActive(false);
        canvasProfile.SetActive(true);

        //Disable the camera
        isCameraMove = false;
    }

    public void ReturnToSite()
    {
        isCameraMove = true;
    }

    public void OpenMedia()
    {
        isCameraMove = false;
    }
}
