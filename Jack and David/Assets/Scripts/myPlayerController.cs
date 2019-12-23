using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//namespace UnityStandardAssets.Characters.FirstPerson
                             
public class myPlayerController : MonoBehaviour
{
    public Transform Head;
    private float headHeight;
    public float CrouchHeadHeight = 0f;
    private CharacterController myController;
    public FirstPersonController myFPS;
    public float CrouchHeight = 0.5f;
    public float CrouchRadius = 0.3f;
    public float CrouchSpeed = 1.0f;
    private float defaultHeight;
    private float defaultRadius;
    private float defaultSpeed;

    public bool underObject = false;
    private bool crouched = false;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        myFPS = GetComponent<FirstPersonController>();
        defaultHeight = myController.height;
        defaultRadius = myController.radius;

        headHeight = Head.localPosition.y;
        myFPS.CrouchSpeed = CrouchSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C)){
            myController.radius = CrouchRadius;
            myController.height = CrouchHeight;
            Head.localPosition = new Vector3(0, CrouchHeadHeight, 0);

            crouched = true;
            myFPS.Crouched = crouched;
        }else if(!underObject){
            myController.radius = defaultRadius;
            myController.height = defaultHeight;
            Head.localPosition = new Vector3(0, headHeight, 0);
            crouched = false;
            myFPS.Crouched = crouched;
        }
    }

	private void OnTriggerStay(Collider other)
	{
        if(other.CompareTag("DuckFurniture") && crouched){
            underObject = true;
        }
	}

	private void OnTriggerExit(Collider other)
	{
        if (other.CompareTag("DuckFurniture") && crouched)
        {
            underObject = false;
        }
	}
}
