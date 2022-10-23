using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;


public class LineManager : MonoBehaviour
{

    [SerializeField] public LineRenderer LineR;
    [SerializeField] private int PointerCounter = 0;
    [SerializeField] private string InputPattern;

    [SerializeField] GameObject Pattern1img;
    [SerializeField] GameObject Pattern2img;
    [SerializeField] GameObject Pattern3img;

    [SerializeField] private string CorrectPattern1;
    [SerializeField] private string CorrectPattern2;
    [SerializeField] private string CorrectPattern2b;
    [SerializeField] private string CorrectPattern3;
    [SerializeField] private string CorrectPattern3b;

    [SerializeField] private Text MistakesText;
    private int MistakesCount;

    private int CurrentLevel = 0;

    [SerializeField] public Animator Pattern1Anim;
    [SerializeField] public Animator Pattern2Anim;
    [SerializeField] public Animator Pattern3Anim;

    [SerializeField] private Button ResetButton;
    [SerializeField] private GameObject GameOverText;

    [SerializeField] private Animator TextFadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        CorrectPattern1 = "1231";
        CorrectPattern2 = "123541";
        CorrectPattern2b = "145321";
        CorrectPattern3 = "123451";
        CorrectPattern3b = "154321";
        Pattern1Anim.Play("Pattern1Anim");
    }
    
    public void AddPointer(Transform ThePointer, string PointerNumber)
    {
        LineR.positionCount += 1;
        LineR.SetPosition(PointerCounter, ThePointer.transform.position);
        AddToString(PointerNumber);
        PointerCounter += 1;
    }

    public void ResetScreen()
    {
        LineR.positionCount = 0;
        PointerCounter = 0;
        InputPattern = "";
    }

    private void AddToString(string Input)
    {
        InputPattern += Input;
        CheckIfCorrect();
    }

    private void CheckIfCorrect()
    {
        if (CurrentLevel == 0)
        {
            if(InputPattern == CorrectPattern1)
            {
                Debug.Log("Correct!");
                //Pattern1img.SetActive(false);
                Pattern1Anim.Play("Pattern1OutAnim");
                Pattern2img.SetActive(true);
                CurrentLevel += 1;
                Invoke("ResetScreen", 2);
            }

        }

        if (CurrentLevel == 1)
        {
            if (InputPattern == CorrectPattern2 || InputPattern == CorrectPattern2b)
            { 
                Debug.Log("Correct!");
                //Pattern2img.SetActive(false);
                Pattern2Anim.Play("Pattern2OutAnim");
                Pattern3img.SetActive(true);
                CurrentLevel += 1;
                Invoke("ResetScreen", 2);
            }

        }

        if (CurrentLevel == 2)
        {
            if (InputPattern == CorrectPattern3 || InputPattern == CorrectPattern3b)
            {
                Debug.Log("Correct!");
                Debug.Log("You win!");
                Pattern3Anim.Play("Pattern3OutAnim");
                //Pattern3img.SetActive(false);
            }

        }

    }

    public void AddToMistakes()
    {
        MistakesCount += 1;

        MistakesText.text = "Mistakes:" + MistakesCount + "/3";

        if (MistakesCount == 3)
        {

            Invoke("GameOver", 3);
            ResetButton.enabled = false;
            GameOverText.SetActive(true);
            TextFadeAnim.Play("GameOverTextFade");
        }


    }

    private void GameOver()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
