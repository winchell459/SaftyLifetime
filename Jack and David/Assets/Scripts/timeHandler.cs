using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeHandler : MonoBehaviour
{
    public GameObject[] TriggerEventObject;
    public bool triggered = false;

    public float WaitTime = 2;
    private float startTime;

    // Update is called once per frame
    void Update()
    {
        if (triggered && startTime + WaitTime < Time.fixedTime){
            foreach(GameObject triggerEvent in TriggerEventObject){
                triggerEvent.SendMessage("TriggerEvent");
            }
            //if (TriggerEventObject) TriggerEventObject.SendMessage("TriggerEvent");
            triggered = false;
        }else if (triggered){
            Debug.Log(Time.fixedTime - startTime);
        }

    }

    public void TriggerEvent()
    {
        triggered = true;
        startTime = Time.fixedTime;
    }

}
