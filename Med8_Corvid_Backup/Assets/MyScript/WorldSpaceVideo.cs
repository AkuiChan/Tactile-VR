using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WorldSpaceVideo : MonoBehaviour
{
    // Global
    private int Index;

    // Text
    public GameObject Setup, Instruction;
    private int TextIndex;

    // Video
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
        else if (Index == 4)
        {
            Setup.SetActive(false);
            Instruction.SetActive(true);
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
}
