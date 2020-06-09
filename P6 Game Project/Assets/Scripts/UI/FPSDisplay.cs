using UnityEngine;
using UnityEngine.UI;
 
public class FPSDisplay : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;
    [SerializeField] private float _hudRefreshRate = 1f;
    
    private float _timer;
 
    public void Update ()
    {
        int fps = (int)(1f / Time.unscaledDeltaTime);
        display_Text.text = "FPS: " + fps;
        _timer = Time.unscaledTime + _hudRefreshRate;
    }
}