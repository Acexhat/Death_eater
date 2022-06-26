using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmout;
    float rot;
    int score;
    public GameObject winText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject backButton;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playGame();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

       // if(restartButton.)

        // It'll check if we are pressing or not
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //It'll get the position of press or mouse
            if (mousePos.x < 0)
            {
                // Rotate to left
                rot = rotateAmout;
            }
            else
            {
                // will rotate to right
                rot = -rotateAmout;
            }
            transform.Rotate(0, 0, rot);
        }

        Vector3 posCam = Camera.main.WorldToViewportPoint(transform.position);
        if(isOutOfBound(posCam))
        {
            var newPosition = getNewPos(posCam);
            handleOutOfBound(newPosition);  
        }
      
    }


    private Vector3 getNewPos(Vector3 currPos)
    {
        if (currPos.x < -0.2)
        {
            return new Vector3(currPos.x + 3f, currPos.y, currPos.z);
        }
        else if (currPos.x > 1.2)
        {
            return new Vector3(currPos.x - 4f, currPos.y, currPos.z);
        }
        else if (currPos.y < -0.2)
        {
            return new Vector3(currPos.x , currPos.y + 6f, currPos.z);
        }else
        {
            return new Vector3(currPos.x, currPos.y - 6f, currPos.z);
        }
    }

    private bool isOutOfBound(Vector3 obj)
    {
        if (obj.x < -0.2 || obj.x > 1.2 || obj.y < -0.2 || obj.y > 1.2) return true;
        return false;
    }

    private void handleOutOfBound(Vector3 newPos)
    {
        var offSet = newPos - transform.position;

        var trails = GetComponentsInChildren<TrailRenderer>();
        foreach (TrailRenderer t in trails)
        {
            // No. of vertices in trails
            var posCount = t.positionCount;
            for (var i = 0; i < posCount; i++)
            {
                t.SetPosition(i, t.GetPosition(i) + offSet);
            }
        }
        transform.position = newPos;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            score++;

            if (score >= 5)
            {
                pauseGame();
                print("Level Completed");
                winText.SetActive(true);
                restartButton.SetActive(true);
                backButton.SetActive(true);
            }
        }
        else if (collision.gameObject.tag == "Danger")
        {
            pauseGame();
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            backButton.SetActive(true);
        }
    }

    private void pauseGame()
    {
        Time.timeScale =0; // Fix this because every time i need to set it back to 1 to run game
    }

    private void playGame()
    {
        Time.timeScale = 1;
    }

    public void restartGame ()
    {
        SceneManager.LoadScene("Game");
        playGame();
    }

    public void goToMainMenu ()
    {
        SceneManager.LoadScene(0);
    }
}
