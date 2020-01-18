using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animationHandler : MonoBehaviour
{
    public GameObject[] TriggerEventObject;
    public bool triggered = false;

    public Animator anim;
    public bool animActivate;

    // Update is called once per frame
    void Update()
    {
        if (triggered){
            anim.SetBool("active", animActivate);
            foreach (GameObject triggerEvent in TriggerEventObject)
            {
                triggerEvent.SendMessage("TriggerEvent");
            }
            //if (TriggerEventObject) TriggerEventObject.SendMessage("TriggerEvent");
            triggered = false;
        } 
    }

    public void TriggerEvent()
    {
        triggered = true;

    }
}
