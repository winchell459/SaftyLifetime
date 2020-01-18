using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [TextArea]
    public string message;
    public Text MessageText;
    public GameObject MessagePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player")){
            MessagePanel.SetActive(true);
            MessageText.text = message;
        }
	}

	private void OnTriggerExit(Collider other)
	{
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(false);

        }
	}
}
