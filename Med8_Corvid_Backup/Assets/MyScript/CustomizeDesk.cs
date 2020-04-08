using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeDesk : MonoBehaviour
{
    public GameObject R_Controller;
    public Toggle P1_Toggle, P2_Toggle, P3_Toggle;
    public GameObject P1, P2, P3;
    bool p1_Active, p2_Active, p3_Active = false;

    // Move the Active position
    void FixedUpdate()
    {
        if (p1_Active == true)
        {
            MovePosition(P1);
        }
        else if (p2_Active == true)
        {
            MovePosition(P2);
        }
        else if (p3_Active == true)
        {
            MovePosition(P3);
        }
    }

    // Activate/Deactivate the positions based on toggle input.
    public void ActiveToggle()
    {
        if (P1_Toggle.isOn)
        {
            p1_Active = true;
            p2_Active = false;
            p3_Active = false;
        }
        else if (P2_Toggle.isOn)
        {
            p1_Active = false;
            p2_Active = true;
            p3_Active = false;
        }
        else if (P3_Toggle.isOn)
        {
            p1_Active = false;
            p2_Active = false;
            p3_Active = true;
        }
    }

    void MovePosition(GameObject ActivePosition)
    {
        // While Trigger is active, Transform Position to be at the right controller.
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            ActivePosition.transform.position = R_Controller.transform.position;
        }
    }

}
