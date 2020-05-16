using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WorldSpaceVideo : MonoBehaviour
{
    [Header("Global Attributes")]
    public GameObject NextButton;
    public GameObject PreviusButton;
    public GameObject StartExperiment;
    public GameObject TutorialUI, ExperimentUI;
    private int Index;

    [Header("Text Attributes")]
    public GameObject Setup;
    public GameObject Instruction;
    private int TextIndex;

    [Header ("Video Attributes")]
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    private int VideoIndex;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = videoClips[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Button
    public void Next()
    {
        Index++;
        if (Index >= 4)
        {
            Index = 4;
            Setup.SetActive(false);
            Instruction.SetActive(true);
            NextButton.SetActive(false); PreviusButton.SetActive(false); StartExperiment.SetActive(true);
        }
        else if (Index == 0)
        {
            VideoIndex = 0;
            videoPlayer.clip = videoClips[VideoIndex];
            videoPlayer.Play();
            Setup.SetActive(false);
            Instruction.SetActive(false);
        }
        else if (Index == 1)
        {
            VideoIndex = 1;
            videoPlayer.clip = videoClips[VideoIndex];
            videoPlayer.Play();
            Setup.SetActive(false);
            Instruction.SetActive(false);
        }
        else if (Index == 2)
        {
            Setup.SetActive(true);
            Instruction.SetActive(false);
        }
        else if (Index == 3)
        {
            VideoIndex = 2;
            videoPlayer.clip = videoClips[VideoIndex];
            videoPlayer.Play();
            Setup.SetActive(false);
            Instruction.SetActive(false);
        }
    }
    public void Previus()
    {
        Index--;
        if(Index <= 0)
        {
            Index = VideoIndex = 0;
            videoPlayer.clip = videoClips[VideoIndex];
            videoPlayer.Play();
            Setup.SetActive(false);
            Instruction.SetActive(false);
        }
        else if (Index == 1)
        {
            VideoIndex = 1;
            videoPlayer.clip = videoClips[VideoIndex];
            videoPlayer.Play();
            Setup.SetActive(false);
            Instruction.SetActive(false);
        }
        else if (Index == 2)
        {
            Setup.SetActive(true);
            Instruction.SetActive(false);
        }
        else if (Index == 3)
        {
            VideoIndex = 2;
            videoPlayer.clip = videoClips[VideoIndex];
            videoPlayer.Play();
            Setup.SetActive(false);
            Instruction.SetActive(false);
        }
    }

    public void ReadyToStart()
    {
        TutorialUI.SetActive(false);
        ExperimentUI.SetActive(true);
    }
}
