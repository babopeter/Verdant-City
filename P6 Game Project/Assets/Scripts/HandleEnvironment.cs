using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleEnvironment : MonoBehaviour
{
    public Image barFill;
    public static float environmentHealth = 0.7f;
    public static float newEnvironmentHealth;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        newEnvironmentHealth = environmentHealth;
        RenderSettings.fogDensity = QuickMaths.Map(environmentHealth, 0.0f, 1.0f, 0.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (environmentHealth != newEnvironmentHealth)
        {
            environmentHealth = Mathf.Lerp(environmentHealth, newEnvironmentHealth, Time.deltaTime * 0.05f);
            //environmentHealth += 0.05f * Time.deltaTime;
            barFill.fillAmount = environmentHealth;
            RenderSettings.fogDensity = QuickMaths.Map(environmentHealth, 0.0f, 1.0f, 0.0f, 0.2f);
        }

        if (environmentHealth <= 0.0f)
        {
            gameManager.GameOver(true, "You have saved the environment, and created a sustainable solution " +
                                       "for future inhabitants of the city");
        }

        if (environmentHealth >= 1.0f)
        {
            gameManager.GameOver(false, "You have caused irreversible damage to the environment and have thus " +
                                        "failed your objective to create a sustainable future for the city");
        }
    }
    
}
