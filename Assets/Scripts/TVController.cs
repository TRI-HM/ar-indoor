using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class TVController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public TMP_Text buttonText;
    void Start()
    {
        playButton.onClick.AddListener(ControlVideo);
    }

    public void ControlVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            buttonText.text = "Play";
        }
        else
        {
            videoPlayer.Play();
            buttonText.text = "Pause";
        }
    }
}
