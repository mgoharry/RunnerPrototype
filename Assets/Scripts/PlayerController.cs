using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;

    private bool isGrounded = true;

    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityMod = 1.5f;

    public bool gameOver;

    private Animator playerAnim;

    public ParticleSystem particleExpl;

    public ParticleSystem dirtSplat;

    public AudioClip jumpSFX;

    public AudioClip deathSFX;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtSplat.Stop();
            playerAudio.PlayOneShot(jumpSFX, 1f);
            
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtSplat.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {

            Debug.Log("Game Over!");

            gameOver = true;
            particleExpl.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtSplat.Stop();
            playerAudio.PlayOneShot(deathSFX, 0.5f);
            
        }
    }
}
