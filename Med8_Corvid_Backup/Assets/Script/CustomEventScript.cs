using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventScript : MonoBehaviour
{
    public GameObject NewObject;
    
    public void OnCustomButtonPress()
    {
        Instantiate(NewObject);
        // Debug.Log("We pushed our custom button!");
    }
}
/*
 * using UnityEngine;
using Valve.VR.InteractionSystem;

public class Events : MonoBehaviour
{
    public void OnPress(Hand hand)
    {
        Debug.Log("SteamVR Button pressed!");
    }

    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
    }
}
 * 
 */
