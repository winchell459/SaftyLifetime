using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupItem : MonoBehaviour
{
    public pickupHandler myPH;
    public string ItemName = "No Name";
    //public bool IsDialogItem;

	private void OnTriggerEnter(Collider other)
	{
        if(other.CompareTag("Player"))
        {
            myPH.PickupItem(gameObject);
            //gameObject.SetActive(false);
        }
	}

	private void OnTriggerExit(Collider other)
	{
        if(other.CompareTag("Player")){
            myPH.PickupItem(gameObject);
        }
	}
}
