using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 playerVelocity;
    int direction;

    [SerializeField]
    Animator animator;
    [SerializeField]
    float speed;

    //public List<Item> items;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }
    private void Movement()
    {
        // Player Movement
        playerVelocity = Vector3.zero;
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        playerVelocity += (transform.forward * z * speed * Time.deltaTime);
        playerVelocity += (transform.right * x * speed * Time.deltaTime);
        controller.Move(playerVelocity);

        // Direction for animation
        if (x == 0 & z > 0)
            direction = 0;
        else if (x > 0 & z > 0)
            direction = 1;
        else if (x > 0 & z == 0)
            direction = 2;
        else if (x > 0 & z < 0)
            direction = 3;
        else if (x == 0 & z < 0)
            direction = 4;
        else if (x < 0 & z < 0)
            direction = 5;
        else if (x < 0 & z == 0)
            direction = 6;
        else if (x < 0 & z > 0)
            direction = 7;

        //Set animation variables
        animator.SetBool("Is Moving", (x != 0 | z != 0));
        animator.SetInteger("Direction", direction);
    }


}
