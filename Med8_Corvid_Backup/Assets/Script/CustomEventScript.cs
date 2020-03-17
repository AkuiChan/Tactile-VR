using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventScript : MonoBehaviour
{
    public GameObject Object1, Object2, Object3;

    public void OnCustomButtonPress()
    {
        //For Debuging Purpose
        Instantiate(Object1);
        Instantiate(Object2);
        Instantiate(Object3);
    }

    public void Condition2()
    {
        if(Object1.activeSelf == false)
        {
            Object1.SetActive(true);
            Object2.SetActive(false);
            Object3.SetActive(false);
        }
        else
        {
            Object1.SetActive(false);
        }
    }

    public void Condition3()
    {
        if(Object2.activeSelf == false)
        {
            Object1.SetActive(false);
            Object2.SetActive(true);
            Object3.SetActive(false);
        }
        else
        {
            Object2.SetActive(false);
        }
    }

    public void Condition4()
    {
        if (Object3.activeSelf == false)
        {
            Object1.SetActive(false);
            Object2.SetActive(false);
            Object3.SetActive(true);
        }
        else
        {
            Object3.SetActive(false);
        }
    }
}