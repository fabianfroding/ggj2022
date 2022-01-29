using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private AudioSource footsteps;
    public bool dead;

    private Vector3 velocity;
    private bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f; // Force player onto the ground instead of setting to 0f.
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime); // Multiplying with deltaTime makes it framerate independent.

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (footsteps.isPlaying) footsteps.Stop();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        PlayFootstepSound();
    }

    private void PlayFootstepSound()
    {
        if (!dead && Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0 && isGrounded && !footsteps.isPlaying)
        {
            footsteps.Play();
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            footsteps.Stop();
        }
    }

    public void StopFootstepsSound()
    {
        footsteps.Stop();
    }
}
