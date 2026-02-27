using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;
    private Rigidbody rb;
    private InputAction jumpAction;

    bool isOnGround = false;
    bool isDoubleJump = true;
    public bool isGameOver = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && !isOnGround && isDoubleJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isDoubleJump = false;
        }
        else if (jumpAction.triggered && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false ;
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit " + collision.gameObject.name);
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            isDoubleJump = true;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("GAME OVER");
            isGameOver = true;
        }
        
    }
}
