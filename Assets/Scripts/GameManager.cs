using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public int P1Life;
    public int P2Life;

    public GameObject p1Wins;
    public GameObject p2Wins;

    public AudioSource hurtSound;

    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;

    public string mainMenu;

    public Text scoreText;
    private static int P1Score = 0;
    private static int P2Score = 0;
    private static bool P1HasWon = false;
    private static bool P2HasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (P1Life <= 0 && !P2HasWon)
        {
            player1.SetActive(false);
            p2Wins.SetActive(true);
            P2Score += 1;
            UpdateScoreText();
            P2HasWon = true; 
        }
        if (P2Life <= 0 && !P1HasWon)
        {
            player2.SetActive(false);
            p1Wins.SetActive(true);
            P1Score += 1;
            UpdateScoreText();
            P1HasWon = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            P1HasWon = false ; P2HasWon = false ;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
            // poate trb adaugat , vad daca ma decid 
        }
    }

    public void HurtP1()
    {
        P1Life -= 1;
        for(int i = 0; i < p1Sticks.Length; i++)
        {
            if(P1Life > i)
            {
                p1Sticks[i].SetActive(true);
            } else
            {
                p1Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }

    public void HurtP2()
    {
        P2Life -= 1;
        for (int i = 0; i < p2Sticks.Length; i++)
        {
            if (P2Life > i)
            {
                p2Sticks[i].SetActive(true);
            }
            else
            {
                p2Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"{P1Score} - {P2Score}";
    }
}
