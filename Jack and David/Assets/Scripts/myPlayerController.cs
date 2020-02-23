using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//namespace UnityStandardAssets.Characters.FirstPerson
                             
public class myPlayerController : MonoBehaviour
{
    public bool MobileControl = false;
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

    private Rigidbody rb;

    private bool pickupitem = false;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        myFPS = GetComponent<FirstPersonController>();
        defaultHeight = myController.height;
        defaultRadius = myController.radius;

        headHeight = Head.localPosition.y;
        setFPSCrouchSpeed();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.C) || crouchedPress)
        {
            myController.radius = CrouchRadius;
            myController.height = CrouchHeight;
            Head.localPosition = new Vector3(0, CrouchHeadHeight, 0);

            crouched = true;
            setFPSCrouched();
        }
        else if(!underObject){
            myController.radius = defaultRadius;
            myController.height = defaultHeight;
            Head.localPosition = new Vector3(0, headHeight, 0);
            crouched = false;
            setFPSCrouched();
        }

        if (MobileControl) mobileControl();
    }
    private Vector2 mousePos;
    public float HeadRotationSpeed = 10f;
    public float MovementSpeed = 10f;

    private void mobileControl()
    {
        float forwardMove = Input.GetAxis("Vertical") * MovementSpeed;
        float lateralMove = Input.GetAxis("Horizontal") * MovementSpeed;
        float jump = 0;
        if (Input.GetKeyDown(KeyCode.Space)) jump = 100;

        Vector3 addForce = transform.forward * forwardMove + transform.right * lateralMove + transform.up * jump;
        rb.AddForce(addForce);
    }
    public void SetIsPickingUpItem(bool pickingupitem)
    {
        this.pickupitem = pickingupitem;
    }
    public bool GetIsPickingupItem()
    {
        return Input.GetKeyDown(KeyCode.P) || this.pickupitem;
    }
    private bool crouchedPress = false;
    public void Crouch(bool crouched)
    {
        crouchedPress = crouched;
    }

    void setFPSCrouched()
    {
        if (myFPS) myFPS.Crouched = crouched;
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
