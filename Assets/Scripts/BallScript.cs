using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    Vector3 ballPos; //setting variable for pos ball
    Rigidbody rb;
    int score;
    int highScore;
    [SerializeField]
    TMP_Text scoreHUD;
    public GameObject GameOverUI;
    public TimerScript clock;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballPos = transform.position;
        score = 0;
        GameOverUI.SetActive(false);
        highScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            GameOverUI.SetActive(true);
            clock.isGameOver = true;

            if(score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighSore", highScore);
            }

            if(clock.seconds > 9 )
            {
                GameOverUI.GetComponent<TMP_Text>().text = $"Game Over\n Your High Score is {highScore}\n your time was {clock.minutes}:{clock.seconds}";
            }
            else
            {
                GameOverUI.GetComponent<TMP_Text>().text = $"Game Over\n Your High Score is {highScore}\n your time was {clock.minutes}:0{clock.seconds}";
            }
        }
    }

    public void RestartGame()
    {
        if (transform.position.y < -10)
        {
            rb.velocity = Vector3.zero;
            transform.position = ballPos;
            score = 0;
            scoreHUD.text = $"Score: {score}";
            GameOverUI.SetActive(false);
            clock.startTime = 0;
            clock.isGameOver = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Paddle")
        {
            score++;
            scoreHUD.text = $"Score: {score}"; 
        }
    }
}
