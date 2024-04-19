using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    public Transform fireBallPrefab;
    public AudioClip soundJump;
    public Animator anim;
    CharacterController controller;
    Vector3 velocity = Vector3.zero;
    float gravity = 20.0f;
    bool moveRight = true;
    float incrSpeed = 1.0f;
    public float jumpSpeed = 12;
    bool currentlyJumping;
    Vector3 savePosition;
    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        currentlyJumping = false;
        savePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {  
       
          
        
        if (controller.isGrounded)
        {
            //makes sure that player is on an object.
            velocity = new Vector3(Input.GetAxis("Horizontal") * incrSpeed, Input.GetAxis("Jump") * jumpSpeed, 0);
        }


        if(Input.GetAxis("Jump") > 0 )
        {

            PlaySound(soundJump);
            velocity.y = jumpSpeed;
                anim.SetBool("Jump",true);
            currentlyJumping = true;
        }
        else if (currentlyJumping)
        {
            anim.SetBool("Jump", false);
            currentlyJumping = false;
        }

        if (velocity.x > 0)
        {
            if (moveRight)
                incrSpeed += .007f;

            else
                incrSpeed = 1.0f;
            moveRight = true;

        }
        else if (velocity.x < 0)
        {
            if (moveRight)
                incrSpeed = 1.0f;

            else
                incrSpeed += .007f;
            moveRight = false;

        }
        else
        {
            incrSpeed = 1.0f;

        }
        velocity.y -= gravity * Time.deltaTime;   //apply gravity
        controller.Move(velocity * Time.deltaTime);  //move the controller

        anim.SetFloat("Speed", velocity.x);
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
          
            Transform obj = Instantiate(fireBallPrefab,transform.position, transform.rotation);
            if (moveRight)
            {
                obj.GetComponent<Rigidbody>().AddForce(300, 0, 0);
            }
            if (!moveRight)
            {
               obj.GetComponent<Rigidbody>().AddForce(-300, 0, 0);
            }
        }
       
    }
    void PlaySound(AudioClip soundName)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying || audio.clip != soundName)
        {
            audio.clip = soundName;
            audio.Play();
        }
    }
    public void SavePos(Vector3 position)
    {

        savePosition = position;    
    }
    /* void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Coin")
        {
            print("in  OnControllerColliderHit");
        }
     
     
    }
    */
   
    public void ResetPos()
    {
        controller.enabled = false;
           transform.position = savePosition;
        controller.enabled = true;
    }
   
}

