using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleObjective : MonoBehaviour
{
    public List<Objective> objective;
    public Text objectiveText;
    public int objectiveNumber = 0;
    public Animation newObjectiveAnim;
    public Animation objectiveAnim;

    private void Start()
    {
        objectiveText.text = objective[objectiveNumber].goalDescription;
        //AkSoundEngine.PostEvent("Objective_New", gameObject);
        //newObjectiveAnim.Play("New objective");
        //objectiveAnim.Play("Objective");
    }

    public void CompleteObjective()
    {
        objective[objectiveNumber].isActive = false;
        if (objectiveNumber+1 < objective.Count)
        {
            objectiveNumber++;
            objective[objectiveNumber].isActive = true;
            objectiveText.text = objective[objectiveNumber].goalDescription;
            AkSoundEngine.PostEvent("Objective_New", gameObject);
            newObjectiveAnim.Play("New Objective");
            objectiveAnim.Play("Objective");
        }
        else
        {
            objectiveText.text = "";
        }
    }
}

