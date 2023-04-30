using UnityEngine;

public class Movement : MonoBehaviour {
    
    public bool canMove = true;

    [Header("Variables")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpHeight = 2.0f;

    [Header("Ground Detection")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;

    [Header("Physics")]
    [SerializeField] private Rigidbody rb;

    
    Vector2 force;

    private void Start() {

        if (rb) return;
        rb = GetComponent<Rigidbody>();

    }
    private void FixedUpdate() {
        
        rb.AddForce(new Vector3(force.x, force.y, 0.0f));
        force = Vector2.zero;

    }
    private void Update() {

        if (!canMove) return;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        force.x = Input.GetAxisRaw("Horizontal") * speed;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);

        }

    }

}