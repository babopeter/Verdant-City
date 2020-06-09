using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HandleLife : MonoBehaviour
{
    public static bool charging;
    public Image barFill;
    private float fillAmount = 1.0f;
    [Range(0.01f, 0.15f)] public float decreaseRate;
    public static float currentHealth = 1.0f;
    public static float newHealth;
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private float vignetteIntensity = 0;
    public bool soundPlayed;
    public GameManager gameManager;
    public static bool dronePlaced;
    //public Color lowColor;
    //public Color highColor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Add more of these to easily jump to battery% where the music changes for testing
        // Test how charging up the battery works with the current implementation
        if (Input.GetKeyDown(KeyCode.F9))
        {
            currentHealth = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            currentHealth = 0.75f;
        }
        
        if (Input.GetKeyDown(KeyCode.F11))
        {
            currentHealth = 0.50f;
        }
        
        if (Input.GetKeyDown(KeyCode.F12))
        {
            currentHealth = 0.25f;
        }

        if (currentHealth <= 1.0)
        {
            AkSoundEngine.SetState(3826569560U, 1216605696U);
        }
        
        if (currentHealth <= 0.75)
        {
            AkSoundEngine.SetState(3826569560U, 241565863U);
        }
        
        if (currentHealth <= 0.5)
        {
            AkSoundEngine.SetState(3826569560U, 208010588U);
        }
        
        if (currentHealth <= 0.25)
        {
            AkSoundEngine.SetState(3826569560U, 191233004U);
            vignetteIntensity = QuickMaths.Map(currentHealth, 0.25f, 0.0f, 0.25f, 0.65f);
            barFill.color = Color.red;
            vignette.intensity.value = vignetteIntensity;
            if (!soundPlayed)
            {
                AkSoundEngine.PostEvent("lowBattery", gameObject);
                soundPlayed = true;
            }

            if (currentHealth <= 0)
            {
                gameManager.GameOver(false, "Your battery ran out. You need to build items that can charge you up, to stay alive. " +
                                            "Without you the city cannot become sustainable and have future inhabitants");
            }
        }
        else
        {
            barFill.color = Color.white;
        }
        
        if (!charging && !dronePlaced)
        {
            currentHealth -= Time.deltaTime * (decreaseRate * 0.1f);
        } else if (dronePlaced)
        {
            currentHealth = 1f;
        }
        
        else
        {
            currentHealth = Mathf.Lerp(currentHealth, newHealth, newHealth*Time.deltaTime);
            if (currentHealth >= newHealth-0.01 || currentHealth >= newHealth)
            {
                charging = false;
            }
            /*
            fillAmount = Mathf.Lerp(0.0f, 1.0f, fillAmount);
            fillAmount += 0.25f * Time.deltaTime;
            if (fillAmount >= 1.0f)
            {
                charging = false;
            }
            */
        }
        barFill.fillAmount = currentHealth;
    }
}
