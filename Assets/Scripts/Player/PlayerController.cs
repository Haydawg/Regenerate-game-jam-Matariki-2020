using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 playerVelocity;
    int direction;
    int lastDirection = 0;

    [SerializeField]
    Animator animator;
    [SerializeField]
    float speed;
    [SerializeField]
    AudioSource audio;

    public AudioSource itemAudio;

    protected static PlayerController _Instance = null;
    public static PlayerController Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<PlayerController>();

            return _Instance;
        }
    }
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

        if (direction != lastDirection)
        {
            animator.ResetTrigger("Change Dir");
            animator.SetTrigger("Change Dir");
            lastDirection = direction;
        }
        else
            lastDirection = direction;

        //Set animation variables
        animator.SetBool("Is Moving", (x != 0 | z != 0));
        animator.SetInteger("Direction", direction);

        controller.Move(playerVelocity);
    }

    public void Footstep()
    {
        audio.pitch = Random.Range(0.1f, 1);
        audio.Play();
    }

}
