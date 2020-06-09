//////////////////////////////////////////////////////////
///Source: https://www.youtube.com/watch?v=wVLj-Kcj5gw ///
//////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    public List<Collider> col = new List<Collider>();
    public Material green;
    public Material red;
    public bool isPlaceable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            col.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            col.Remove(other);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "DronePlacement")
        {
            GetComponent<Renderer>().material = green;
        }
        else
        {
            GetComponent<Renderer>().material = red;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.name == "DronePlacement")
            GetComponent<Renderer>().material = red;
    }

    public void ChangeColor(string color)
    {
        if (GetComponent<Renderer>() != null)
        {
            if (color == "Green")
            {
                GetComponent<Renderer>().material = green;
            } else if (color == "Red")
            {
                GetComponent<Renderer>().material = red;
            }
        }
        
        foreach (Transform child in transform)
        {
            Material[] mats = child.GetComponent<Renderer>().materials;
            if (color == "Green")
            {
                //child.GetComponent<Renderer>().material = green;

                for (int i = 0; i < mats.Length; i++)
                {
                    mats[i] = green;
                }

                child.GetComponent<Renderer>().materials = mats;

            } else if (color == "Red")
            {
                //child.GetComponent<Renderer>().material = red;
                
                for (int i = 0; i < mats.Length; i++)
                {
                    mats[i] = red;
                }
                
                child.GetComponent<Renderer>().materials = mats;
                
            }
        }
        /*
        if (col.Count == 0)
        {
            isPlaceable = true;
        }
        else
        {
            isPlaceable = false;
        }

        if (isPlaceable)
        {
            foreach (Transform child in this.transform)
            {
                child.GetComponent<Renderer>().material = green;
            }
        }
        else
        {
            foreach (Transform child in this.transform)
            {
                child.GetComponent<Renderer>().material = red;
            }
        }
        */
    }
}
