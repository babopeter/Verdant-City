using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Source: https://www.youtube.com/watch?v=d_qk7egZ8_c
/// </summary>
public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;
    
    public Camera cam;
    public Text tooltiptext;
    public RectTransform backgroundRectTransform;

    private void Awake()
    {
        gameObject.SetActive(false);
        instance = this;
    }

    private void Update()
    {
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint;
    }

    // Start is called before the first frame update
    private void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltiptext.text = tooltipString;
        float textOffset = 4f;
        Vector2 backgroundSize = new Vector2(tooltiptext.preferredWidth/2 + textOffset * 2,
            tooltiptext.preferredHeight/2 + textOffset * 2);
        backgroundRectTransform.sizeDelta = backgroundSize;

    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowTooltip(tooltipString);
    }

    public static void HideTooltip_Static()
    {
        instance.HideTooltip();
    }
}
