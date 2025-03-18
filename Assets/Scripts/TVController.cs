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
        playButton.onClick.AddListener(PlayVideo);
    }

    public void PlayVideo()
    {
        if (videoPlayer.isPlaying)
        {
            PauseVideo();
            UpdateButtonText();
        }
        else
        {
            videoPlayer.Play();
            UpdateButtonText();
        }
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }

    void UpdateButtonText()
    {
        buttonText.text = videoPlayer.isPlaying ? "Pause" : "Play";
    }
}
