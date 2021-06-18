using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private const float START_BALL_FORCE = 400f, OFFSET = 0.7f, SPEED = 10f;

    private bool isStart;
    private int score;

    private Transform playerT;
    private Rigidbody2D rb;
    private Text scoreText;
    private GameObject buttonPanel;

    void Awake()
    {
        isStart = false;
        playerT = GameObject.Find("Platform").transform;
        rb = GetComponent<Rigidbody2D>();
        buttonPanel = GameObject.Find("BallPanel");
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score = 0;
    }

    void FixedUpdate()
    {
        if (!isStart)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //pc case
            {
                BallPush();
            }
            transform.position = new Vector2(playerT.position.x, playerT.position.y + OFFSET);
        }
        else
        {
            if(rb.velocity.magnitude != SPEED)
            {
                rb.velocity = rb.velocity.normalized * SPEED;
            }
        }
    }

    public void BallPush()
    {
        isStart = true;
        rb.AddForce(new Vector2(Random.Range(-1f, 1f) * START_BALL_FORCE, START_BALL_FORCE));
        buttonPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Finish":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "Brick":
                score++;
                scoreText.text = "Score: " + score.ToString();
                break;
        }
    }
}
