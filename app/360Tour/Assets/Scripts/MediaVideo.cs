using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MediaVideo : MonoBehaviour
{
    public GameObject canvasVideo;
    public TourManager tourManager;
    public VideoPlayer videoToPlay;
    // Start is called before the first frame update
    void Start()
    {
        canvasVideo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasVideo.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            HideVideo();
        }
    }

    public void ShowVideo()
    {
        canvasVideo.SetActive(true);
        tourManager.OpenMedia();
        videoToPlay.Play();
    }

    public void HideVideo()
    {
        canvasVideo.SetActive(false);
        tourManager.ReturnToSite();
        videoToPlay.Stop();
    }
}
