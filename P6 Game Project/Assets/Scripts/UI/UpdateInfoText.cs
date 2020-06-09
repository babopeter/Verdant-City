using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInfoText : MonoBehaviour
{
    public Text infoText;
    public string infoString;

    public void ShowInfo()
    {
        infoText.text = infoString;
    }

    public void HideInfo()
    {
        infoText.text = "";
    }
}
