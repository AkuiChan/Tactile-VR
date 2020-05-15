using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;
using UnityEditorInternal;

public class VideoNext : MonoBehaviour
{
    public OVRHand left, right;
    public UnityEvent ContactEvent, ActionEvent, DefaultEvent;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitiateEvent(InteractableStateArgs state)
    {
        if (state.NewInteractableState == InteractableState.ContactState)
        {
            ContactEvent.Invoke();
        }
        else if (state.NewInteractableState == InteractableState.ActionState)
        {
            ActionEvent.Invoke();
        }
        else
            DefaultEvent.Invoke();
    }

    
}
