using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] float ballForce;
    [SerializeField] float multiplier;
    [SerializeField] Slider slider;
    [SerializeField] float maxBallForce;
    [SerializeField] float terminalVelocity;
    [SerializeField] TextMeshProUGUI score, rank;
    [SerializeField] GameObject panel;

    BallScore bscore;
    Vector3 mousePosition;
    bool ballTap;
    Rigidbody2D rbBall;
    int ballHit;

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
            ballTap = true;

        
        

        SlideManager();

        BallHitManager();


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
    private enum BallScore { Bad, OK, Good, Great, Excelent, Impossible };
    void BallHitManager()
    {

        if (ballHit >= 7)
            bscore = BallScore.Bad;

        if (ballHit >= 5)
            bscore = BallScore.Good;

        if (ballHit >= 3)
            bscore = BallScore.Great;

        if (ballHit >= 2)
            bscore = BallScore.Excelent;

        if (ballHit >= 1)
            bscore = BallScore.Impossible;

        switch (bscore)
        {
            case BallScore.Bad:
                rank.text = "Bad";
                break;

            case BallScore.Good:
                rank.text = "Good";
                break;

            case BallScore.Great:
                rank.text = "Great";
                break;

            case BallScore.Excelent:
                rank.text = "Excelent";
                break;

            case BallScore.Impossible:
                rank.text = "STOP CHEATING";
                break;

        }

        score.text = ballHit.ToString();
    }

    IEnumerator EndLevel(int time)
    { 
        yield return new WaitForSeconds(3f);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        panel.SetActive(true);

    }

}
