using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleInput : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject craftingPanel;
    public GameObject overlayText;
    public GameObject cam;
    public bool TP; //Third-person
    public Animator anim;

    public GameObject pauseNotifier;
    
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!craftingPanel.activeInHierarchy)
            {
                ActivateCrafting();
                anim.SetBool("isWalking", false);
                AkSoundEngine.PostEvent("openCraftingMenu", gameObject);
            } 
            else if (craftingPanel.activeInHierarchy)
            {
                DisableCrafting();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        DisableScripts();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseNotifier.SetActive(true);
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        EnableScripts();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseNotifier.SetActive(false);
    }

    private void ActivateCrafting()
    {
        Time.timeScale = 0;
        craftingPanel.SetActive(true);
        DisableScripts();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        overlayText.SetActive(false);
        pauseNotifier.SetActive(true);
    }
    
    private void DisableCrafting()
    {
        Time.timeScale = 1;
        craftingPanel.SetActive(false);
        EnableScripts();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Tooltip.HideTooltip_Static();
        overlayText.SetActive(true);
        pauseNotifier.SetActive(false);
    }

    private void EnableScripts()
    {
        gameObject.GetComponent<PlayerController>().enabled = true;
        if(TP)
        {
            cam.GetComponent<TPMouseLook>().enabled = true;
        } else
        {
            cam.GetComponent<FPMouseLook>().enabled = true;
        }
        
    }

    private void DisableScripts()
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        if (TP)
        {
            cam.GetComponent<TPMouseLook>().enabled = false;
        }
        else
        {
            cam.GetComponent<FPMouseLook>().enabled = false;
        }
    }
}
