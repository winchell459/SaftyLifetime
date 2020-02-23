using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

                             
public class myPlayerController1 : MonoBehaviour
{
    public Transform Head;
    private float headHeight;
    public float CrouchHeadHeight = 0f;
    private CharacterController myController;
    public FirstPersonController myFPS;
    public Examples.myVictorsFPS myVFPS;
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
        setFPSCrouchSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F)){
            myController.radius = CrouchRadius;
            myController.height = CrouchHeight;
            Head.localPosition = new Vector3(0, CrouchHeadHeight, 0);

            crouched = true;
            setFPSCrouched();
        }else if(!underObject){
            myController.radius = defaultRadius;
            myController.height = defaultHeight;
            Head.localPosition = new Vector3(0, headHeight, 0);
            crouched = false;
            setFPSCrouched();
        }
    }

    void setFPSCrouched()
    {
        if (myFPS) myFPS.Crouched =crouched;
        else if (myVFPS) myVFPS.Crouched = crouched;
    }

    void setFPSCrouchSpeed()
    {
        if (myFPS) myFPS.CrouchSpeed = CrouchSpeed;
        else if (myVFPS) myVFPS.CrouchSpeed = CrouchSpeed;
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
