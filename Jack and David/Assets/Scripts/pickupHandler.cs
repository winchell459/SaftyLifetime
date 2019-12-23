using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupHandler : MonoBehaviour
{
    public GameObject[] TriggerEventObject;
    public bool triggered = false;

    public GameObject[] prefabSpawnObjects;
    public Transform[] spawnLocation;
    private List<GameObject> itemsNeeded = new List<GameObject>();
    private List<GameObject> itemsAquired = new List<GameObject>();


    public List<Item> PickupItems = new List<Item>();

    public GameObject DialogPanel;
    public UnityEngine.UI.Text DialogText;
    private GameObject WaitingPickupItem;
 

    // Update is called once per frame
    void Update()
    {
        if (triggered){
            //int counter = 0;
            //foreach (GameObject item in prefabSpawnObjects){
            //    GameObject newItem = Instantiate(item, spawnLocation[counter].position, Quaternion.identity);
            //    itemsNeeded.Add(newItem);
            //    newItem.GetComponent<pickupItem>().myPH = this;
            //    triggered = false;
            //    counter += 1;
            //}

            int counter = 0;
            foreach (Item item in PickupItems)
            {
                GameObject prefab = item.Prefab;
                GameObject newItem = Instantiate(prefab, item.SpawnLocation.position, Quaternion.identity);
                itemsNeeded.Add(newItem);
                newItem.GetComponent<pickupItem>().myPH = this;
                triggered = false;
                counter += 1;
            }
        }

        if(WaitingPickupItem && Input.GetKeyDown(KeyCode.P)){
            addItem(WaitingPickupItem);
        }
        //else if(!WaitingPickupItem && DialogPanel){
        //    DialogPanel.SetActive(false);
        //}
    }

    public void TriggerEvent(){
        triggered = true;
    }

    private void addItem(GameObject myItem){
        itemsAquired.Add(myItem);
        myItem.SetActive(false);

        if(myItem == WaitingPickupItem){
            WaitingPickupItem = null;
            DialogPanel.SetActive(false);
        }

        if (itemsNeeded.Count == itemsAquired.Count)
        {
            foreach (GameObject triggerEvent in TriggerEventObject){
                triggerEvent.SendMessage("TriggerEvent");
            }

            gameObject.SetActive(false);
            //if(text)text.gameObject.SetActive(true);
        }
    }

    public void PickupItem(GameObject myItem){
        if (WaitingPickupItem == myItem)
        {
            WaitingPickupItem = null;
            DialogPanel.SetActive(false);
        }
        else if(itemsNeeded.Contains(myItem)){
            Item item = PickupItems[itemsNeeded.IndexOf(myItem)];
            if(!item.IsDialogItem){
                addItem(myItem);
            }else{
                DialogPanel.SetActive(true);
                DialogText.text = "Press (P) to pickup " + item.ItemName + ".";
                WaitingPickupItem = myItem;
            }


        }



    }

    public void LeaveItem(GameObject myItem){
        if(WaitingPickupItem && WaitingPickupItem == myItem){
            DialogPanel.SetActive(false);
            WaitingPickupItem = null;
        }
    }
    private Item findItem(GameObject findItem){
        Item foundItem = null;
        foreach(Item item in PickupItems){
            
        }
        return foundItem;
    }
}
[System.Serializable]
public class Item{
    public GameObject Prefab;
    public Transform SpawnLocation;
    public string ItemName;
    public bool IsDialogItem;
    [TextArea]
    public string DialogMessage;
}
