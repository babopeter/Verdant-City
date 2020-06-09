using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    public void onClick()
    {
        AkSoundEngine.PostEvent("UI_click", gameObject);
    }

    public void onHover()
    {
        AkSoundEngine.PostEvent("UI_hover", gameObject);
    }
}
