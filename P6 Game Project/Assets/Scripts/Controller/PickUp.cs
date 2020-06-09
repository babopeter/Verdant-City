using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public string pickUpTextString;
    public string pickUpType;
    private GameObject pickUpText;
    private bool triggerEntered;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText = GameObject.Find("Canvas/PickupText");
        text = pickUpText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerEntered)
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (gameObject.name.Contains("Scrap"))
                {
                    HandleInventory.scrap++;
                    AkSoundEngine.PostEvent("pickupScrap", gameObject);
                } else if (gameObject.name.Contains("Wood"))
                {
                    HandleInventory.wood++;
                    AkSoundEngine.PostEvent("pickupWood", gameObject);
                } else if (gameObject.name.Contains("Electronic"))
                {
                    HandleInventory.electronics++;
                    AkSoundEngine.PostEvent("pickupElectronics", gameObject);
                }
                Destroy(gameObject);
                HandleInventory.UpdateInventory();
                text.text = "";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEntered = true;
            //pickUpText.SetActive(true);
            text.text = pickUpTextString + " " + pickUpType;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEntered = false;
            text.text = "";
            //pickUpText.SetActive(false);
        }
    }
}
