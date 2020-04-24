using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class FollowScript : MonoBehaviour
{
    public OVRHand  right;
    OVRSkeleton rightSkeleton;
    OVRBone rightIndexTip;

    Vector3 rightIndexTipPos;

    // Start is called before the first frame update
    void Start()
    {

        rightSkeleton = right.GetComponent<OVRSkeleton>();
        foreach (OVRBone bone in rightSkeleton.Bones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            {
                rightIndexTip = bone;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rightIndexTipPos = rightIndexTip.Transform.position;
        Quaternion rightIndexTipRot = rightIndexTip.Transform.rotation;
        this.transform.position = rightIndexTipPos;
        this.transform.rotation = rightIndexTipRot;
    }
}
