using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

//This script is attached to Canvas GameObject
public class UI : MonoBehaviour
{
    //MainMenu
    [Space(10), Header("======MainMenu======")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject startBtn, controlesBtn, exitBtn;

    //GameMenu
    [Space(10), Header("======GameMenu======")]
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private TMP_Text gameMenutext;

    //PauseMenu
    [Space(10), Header("======PauseMenu======")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeBtn, controlesBtnPause, backBtn;

    //ControleMenu
    [Space(10), Header("======ControleMenu======")]
    [SerializeField] private GameObject controleMenu;
    [SerializeField] private GameObject controleMenubackBtn;
    [SerializeField]
    private TMP_InputField forwardMovement,
        backMovement, leftMovement, rightMovement,
        upMovement, downMovement, leftRotate, rightRotate,
        engine;

    bool isPlaying;

    void Awake()
    {

    }

    void Start()
    {
        startBtn.GetComponent<Button>().onClick.AddListener(() => StartButton());
        controlesBtn.GetComponent<Button>().onClick.AddListener(() => ControllesButton());
        exitBtn.GetComponent<Button>().onClick.AddListener(() => QuitButton());
        resumeBtn.GetComponent<Button>().onClick.AddListener(() => ResumeButton());
        controlesBtnPause.GetComponent<Button>().onClick.AddListener(() => ControllesButton());
        backBtn.GetComponent<Button>().onClick.AddListener(() => BackButton());
        controleMenubackBtn.GetComponent<Button>().onClick.AddListener(() => ContolsBackButton());

        isPlaying = false;

        mainMenu.SetActive(true);
        gameMenu.SetActive(false);
        pauseMenu.SetActive(false);
        controleMenu.SetActive(false);
    }

    void Update()
    {
        if (gameMenu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
    }

    void StartButton()
    {
        mainMenu.SetActive(false);
        gameMenu.SetActive(true);
        pauseMenu.SetActive(false);
        controleMenu.SetActive(false);
        isPlaying = true;
    }

    void ControllesButton()
    {
        mainMenu.SetActive(false);
        gameMenu.SetActive(false);
        pauseMenu.SetActive(false);
        controleMenu.SetActive(true);
    }

    void QuitButton()
    {
        Application.Quit();
    }

    void ResumeButton()
    {
        Time.timeScale = 1;
    }

    void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    void ContolsBackButton()
    {
        if (isPlaying)
        {
            mainMenu.SetActive(false);
            gameMenu.SetActive(true);
            pauseMenu.SetActive(false);
            controleMenu.SetActive(false);
        }
        else
        {
            mainMenu.SetActive(true);
            gameMenu.SetActive(false);
            pauseMenu.SetActive(false);
            controleMenu.SetActive(false);
        }
    }

    void PauseButton()
    {
        mainMenu.SetActive(false);
        gameMenu.SetActive(false);
        pauseMenu.SetActive(true);
        controleMenu.SetActive(false);
        Time.timeScale = 0;

    }
}
