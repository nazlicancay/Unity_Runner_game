using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class JoystickPlayerExample : MonoBehaviour
{
    private AudioSource _playerAudio;
    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    public GameManager gm;
    public float fallMulti = 3.5f;
    public float lowMult = 2f;
    private Animator _playerAnim;
    [FormerlySerializedAs("JumpForce")] public int jumpForce;
    public bool isOnTheGround = true;
    [FormerlySerializedAs("RestartBotton")] public Button restartBotton;
    [FormerlySerializedAs("CrashS")] public AudioClip crashS;
    

 

    private void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(transform.position.x > 3.25 )
        {
            transform.position = new Vector3(3.25f, transform.position.y, transform.position.z);
        }
        if(transform.position.x < 1.3)
        {
            transform.position = new Vector3(1.3f,transform.position.y , transform.position.z);
        }
        if (gm.isGameActive)
        {
            Vector3 direction = Vector3.right * floatingJoystick.Horizontal;
            transform.Translate(direction * speed * Time.fixedDeltaTime);

        }
      

        if (floatingJoystick.Vertical > 0.9f && gm.isGameActive && isOnTheGround )  
        {

            rb.velocity = Vector3.up * jumpForce;
            _playerAnim.SetTrigger("Jump_trig");
            isOnTheGround = false;

        }
    }

 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            gm.levelUp = true;
            gm.isGameActive = false;
            Debug.Log("finish");
            GameManager.gameManagerInstance.levelUpBotton.gameObject.SetActive(true);
            GameManager.gameManagerInstance.levelnum +=1 ;
            PlayerPrefs.SetInt("Level", GameManager.gameManagerInstance.levelnum);
            GameManager.gameManagerInstance.startFromBeginingBotton.gameObject.SetActive(true);
           
            _playerAnim.SetBool("Static_b", false);
            _playerAnim.SetFloat("Speed_f", 0);
        }

        if (other.gameObject.CompareTag("obstacle"))
        {
            gm.isGameActive = false;
            _playerAudio.PlayOneShot(crashS , 0.5f);
            Debug.Log("game over");
            restartBotton.gameObject.SetActive(true);

            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;

        }        

       
    }

   
}