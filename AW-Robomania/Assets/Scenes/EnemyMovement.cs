using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour


{
    
    public float yForce;
    public float xForce;
    public float xDirection;
    private Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if (transform.position.x <= -8)
        {
            //speed = speed * -1; 
            xDirection = 1;
            enemyRigidBody.AddForce(Vector2.right * xForce);
        }

        if (transform.position.x >= 8)
        {
            //speed = speed * -1;
            xDirection = -1;
            enemyRigidBody.AddForce(Vector2.left * xForce);

        }
    
        

        float newXPosition = transform.position.x * Time.deltaTime;
        float newYPosition = transform.position.y;
        Vector2 newPosition = new Vector2(newXPosition, newYPosition);
       // transform.position = newPosition;


    }
    
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidBody.AddForce(jumpForce);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Transform enemyPosition = collision.gameObject.transform;
           //transform.position.x;
           // enemyPosition.position.x;
            if (transform.position.x <= enemyPosition.position.x) 
            {
                xDirection = 1;
                enemyRigidBody.AddForce(Vector2.right * xForce);
            } 

            if ((transform.position.x >= enemyPosition.position.x)) 
                {

                xDirection = -1;
                enemyRigidBody.AddForce(Vector2.right * xForce);
            }
            
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidBody.AddForce(jumpForce);
        } 
        if (collision.gameObject.tag == "enemy")
        {
            Vector2 Force = new Vector2(yForce * xDirection, xForce);
            enemyRigidBody.AddForce(Force);
        }

        
    } 

   

}
