using UnityEngine;
using System.Collections;

public class rigidBodyMovement : MonoBehaviour
{

    public bool jump = false;
    public float moveForce = 20f;
    public float maxSpeed = 3f;
    public float jumpForce = 200f;

    private Rigidbody2D rBody;


    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rBody.velocity.x < maxSpeed)
            rBody.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rBody.velocity.x) > maxSpeed)
            rBody.velocity = new Vector2(Mathf.Sign(rBody.velocity.x) * maxSpeed, rBody.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

}