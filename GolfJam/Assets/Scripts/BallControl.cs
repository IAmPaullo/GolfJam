using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] float ballForce;
    [SerializeField] float multiplier;
    [SerializeField] Slider slider;
    [SerializeField] float maxBallForce;
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

        if (ballForce > maxBallForce)
            ballForce = maxBallForce;



        if (Input.GetMouseButtonUp(0))
        {
            ballTap = true;
        }

        SlideManager();
        
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



    void SlideManager()
    {
        //float sliderClamp = Mathf.Clamp(ballForce, 0, maxBallForce);
        //int sliderClamp = Mathf.Clamp01(ballForce);
        //slider.value = sliderClamp;

        slider.maxValue = maxBallForce;
        slider.value = ballForce;

    }

}
