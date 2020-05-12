using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;

public class CustomizePoint : MonoBehaviour
{
    // Left is a leftover/continuasion in case we want to implement left handed options.
    // In the case of future polishing this could be set to work independently from each other. 
    // otherwise do not use as they currently perform the same actions, and you risk setting two positions at the same coordinate (which cant be moved)
    public OVRHand left, right;
    OVRSkeleton leftSkeleton, rightSkeleton;  // If skeleton doest update, change fixed timestep to 0.01
    OVRBone leftIndexTip, rightIndexTip;

    bool PitchingGesture_R = false;
    bool PitchingGesture_L = false;

    Vector3 leftIndexTipPos, rightIndexTipPos;
    public bool active = false; // Activates positions independently from each other. Also allows for collider check (remember physics active on hands)

    private bool StartBool = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);
        /*   
           rightSkeleton = right.GetComponent<OVRSkeleton>();
           foreach (OVRBone bone in rightSkeleton.Bones) // checks all bones.
           {
               if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip) // Sets the transpose position. 
               {
                   rightIndexTip = bone;
               }
           }
           */
    }

    // Update is called once per frame
    void Update()
    {

        PitchingGesture_R = right.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (PitchingGesture_R && active == true) // If pinching at an active position (whether ray or collider)
        {

            newStart();
            ActivePositionMove();
            Debug.Log("Pinching");
        }
    }

    void newStart()
    {
        //GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);

        rightSkeleton = right.GetComponent<OVRSkeleton>();
        foreach (OVRBone bone in rightSkeleton.Bones) // checks all bones.
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip) // Sets the transpose position. 
            {
                rightIndexTip = bone;
            }
        }
    }

    //enables Ray function in case object is to far away or outside users guardian.
    void InitiateEvent(InteractableStateArgs state)  
    {
        if (state.NewInteractableState == InteractableState.ContactState || state.NewInteractableState == InteractableState.ProximityState || state.NewInteractableState == InteractableState.ActionState)
        {
            active = true;
        }
        else
            active = false;
    }

    // Move active position to right index tip.
    public void ActivePositionMove() 
    {
            rightIndexTipPos = rightIndexTip.Transform.position;

            this.transform.position = rightIndexTipPos;
    }

    // Used colliders to check whether position is active. 
    private void OnTriggerEnter(Collider other)
    {
        active = true;
    }
    private void OnTriggerExit(Collider other)
    {
        active = false;
    }
}
