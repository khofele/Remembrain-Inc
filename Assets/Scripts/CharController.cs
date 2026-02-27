using System.Collections;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private CharacterController charController = null;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f * 2;
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask = default;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private UIManager uiManager = null;

    private Vector3 moveDir;
    private Vector3 velocity;
    private bool isGrounded = false;
    private bool dead = false;
    private Vector3 startPosition = Vector3.zero;
    private Quaternion startRotation = Quaternion.identity;
    private bool gotKey = false;
    private bool gameOver = false;

    public bool Dead { get => dead; set => dead = value; }
    public bool GotKey { get => gotKey; set => gotKey = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }

    private void Start()
    {
        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;
    }

    private void Update()
    {
        if(dead == false && GameOver == false)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float xAxis = Input.GetAxis("Horizontal");
            float zAxis = Input.GetAxis("Vertical");

            moveDir = transform.right * xAxis + transform.forward * zAxis;

            charController.Move(moveDir * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            charController.Move(velocity * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                Jump();
            }
        }
        else if(GameOver == false)
        {
            Respawn();
        }
        else
        {

        }
        
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    public void Respawn()
    {
        StartCoroutine(DisplayDeathMessage());
        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = startRotation;
    }

    public IEnumerator DisplayDeathMessage()
    {
        uiManager.DisplayDeathMessage();
        yield return new WaitForSeconds(1.5f);
        uiManager.DisableDeathMessage();
        dead = false;
    }
}

