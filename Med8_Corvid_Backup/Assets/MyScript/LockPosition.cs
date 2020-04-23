using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;

public class LockPosition : MonoBehaviour
{
    public OVRHand left, right;

    public UnityEvent ContactEvent, ActionEvent_Lock, ActionEvent_Unlock, DefaultEvent;

    bool islocked = false;

    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);
    }

    //easier overview of what happens when a button is pushed.
    void InitiateEvent(InteractableStateArgs state)
    {
        if (state.NewInteractableState == InteractableState.ContactState)
        {
            ContactEvent.Invoke();
        }
        else if (state.NewInteractableState == InteractableState.ActionState)
        {
            if (islocked == false)
            {
                ActionEvent_Lock.Invoke();
                islocked = true;
            }
            else if (islocked == true)
            {
                ActionEvent_Unlock.Invoke();
                islocked = false;
            }

        }
        else
            DefaultEvent.Invoke();
    }

    public void Lock_Position(GameObject position)
    {
        position.SetActive(false);
    }

    public void Unlock_Postion(GameObject postion)
    {
        postion.SetActive(true);
    }
}
