using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int rotateSpeed;

    public int movementSpeed;
    public Transform player;

    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(movementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.SetBool("Walking", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(-movementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetBool("WalkingBack", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("WalkingBack", false);
        }

        if (Input.GetKey(KeyCode.A))
        {   
            Quaternion currentRotation = player.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, -90, 0);
            player.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Quaternion currentRotation = player.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 90, 0);
            player.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
        }
    }
    
    public void Move(float movementSpeed)
    {
        player.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }
}
