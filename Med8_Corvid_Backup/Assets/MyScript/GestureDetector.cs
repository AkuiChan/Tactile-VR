using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> FingerDatas;
    public UnityEvent onRecognized;

}

public class GestureDetector : MonoBehaviour
{
    [Header("Gesture Recognition")]
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones;
    public bool debugMode;

    public float threshold = 0.1f;
    private Gesture previusGesture;

    [Header("Drawing Object")]
    public GameObject Pencil;
    private OVRBone grip, lookGrip1, lookGrip2;
    Vector3 gripPos;

    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previusGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());

        // Check if new Gesture
        if(hasRecognized)
        {
            Debug.Log("New Gesture Found : " + currentGesture.name);
            previusGesture = currentGesture;
            PencilPosition();
            //currentGesture.onRecognized.Invoke();
        }
    }


    // Gesture Recognition
    void Save()
    {
        Gesture g = new Gesture();
        g.name = "new Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            // Finger position relative to root
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.FingerDatas = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.FingerDatas[i]);

                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }
            if(!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }
        return currentGesture;
    }

    // Pencil object Follow
    void PencilPosition()
    {
        // Get bone position for the pencil
        foreach (var bone in fingerBones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            {
                grip = bone;
            }

            if (bone.Id == OVRSkeleton.BoneId.Hand_Pinky3)
            {
                lookGrip1 = bone;
            }

            if (bone.Id == OVRSkeleton.BoneId.Hand_Pinky1)
            {
                lookGrip2 = bone;
            }
        }
        

        // Set position
        gripPos = grip.Transform.position;
        Pencil.transform.position = gripPos;

        // Set rotation
        Vector3 lookGripCenter = 0.5f * (lookGrip1.Transform.position + lookGrip2.Transform.position);
        Vector3 directionToFace = lookGripCenter - grip.Transform.position;
        Pencil.transform.rotation = Quaternion.LookRotation(directionToFace);
    }
}
