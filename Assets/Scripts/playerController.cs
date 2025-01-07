using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float runSpeed;
    private int JumpCount = 0;
    private bool canJump = true;
    Animator anim;
    public bool isGameOver = false;
    public GameObject GameOverPanel,ScoreText;
    public Text FinalScoreText, HightScoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("IncreasingGameSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        }


        if (JumpCount == 2)
        {
            canJump = false;
        }

        if (Input.GetKeyDown("space") && canJump && !isGameOver)
        {
            rb2d.velocity = Vector3.up * 4.5f;
            anim.SetTrigger("jump");
            JumpCount += 1;
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        anim.SetTrigger("death");
        StopCoroutine("IncreasingGameSpeed");
        StartCoroutine("ShowGameOverPanel");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 0;
            canJump = true;

        }
        if (collision.gameObject.CompareTag("obstacle"))
        {
            GameOver();
        }
        if (collision.gameObject.CompareTag("BottomDetactor"))
        {
            GameOver();
        }

    }
    IEnumerator IncreasingGameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (runSpeed < 8)
            {
                runSpeed += 0.2f;
            }
            if(GameObject.Find("GroundSpawner").GetComponent<obstacleSpawner>().obstacleSpawnInterval>1)
                    {
                GameObject.Find("GroundSpawner").GetComponent<obstacleSpawner>().obstacleSpawnInterval -= 0.1f;
            }
            
        }
    }
    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        ScoreText.SetActive(false);

      FinalScoreText.text ="Score : "  + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;
        HightScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");

    }
}
