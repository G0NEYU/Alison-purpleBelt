using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;

    float jumpForce = 5.7f;
   bool canJump;
    public bool isGrounded;
    float fallMultiplier = 1.5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() 
        
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .15f);
        Debug.DrawRay(transform.position, Vector3.down * .15f, Color.red);
        if (rigidbody.velocity.y > -.01 && rigidbody.velocity.y < .01)
        {
            canJump = true;
            
        } else
        {
            canJump = false;
        }
        if(Input.GetButtonDown("Jump") && isGrounded){
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } 
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Physics.gravity * fallMultiplier * Time.deltaTime;
        }
    }
}

