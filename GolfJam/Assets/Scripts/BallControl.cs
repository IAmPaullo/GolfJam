using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] float ballForce;
    [SerializeField] float multiplier;
    Vector3 mousePosition;
    bool ballTap;
    Rigidbody2D rbBall;

    private void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();

    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
            ballForce += Time.deltaTime * multiplier;
            
        

        if (Input.GetMouseButtonUp(0))
        {
            ballTap = true;
        }
    }
    private void FixedUpdate()
    {

        if (ballTap)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = transform.position - mousePosition;
            rbBall.AddForce(new Vector2(dir.x, dir.y) * ballForce);
            ballTap = false;
            ballForce = 0;
        }

    }


}
