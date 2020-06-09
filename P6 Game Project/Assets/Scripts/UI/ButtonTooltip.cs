using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTooltip : MonoBehaviour
{
    public string text;

    public void ShowTooltip()
    {
        Tooltip.ShowTooltip_Static(text);
    }

    public void HideTooltip()
    {
        Tooltip.HideTooltip_Static();
    }
}
