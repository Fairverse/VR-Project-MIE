using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int movementSpeed;

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

        if (Input.GetKeyDown(KeyCode.A))
        {
           
        }
    }
    
    public void Move(float movementSpeed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }
}
