using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private string CorrectPattern3;

    private int CurrentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        CorrectPattern1 = "1231";
        CorrectPattern2 = "123541";
        CorrectPattern3 = "123451";
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
                Pattern1img.SetActive(false);
                Pattern2img.SetActive(true);
                CurrentLevel += 1;
                Invoke("ResetScreen", 2);
            }
        }

        if (CurrentLevel == 1)
        {
            if (InputPattern == CorrectPattern2)
            {
                Debug.Log("Correct!");
                Pattern2img.SetActive(false);
                Pattern3img.SetActive(true);
                CurrentLevel += 1;
                Invoke("ResetScreen", 2);
            }
        }

        if (CurrentLevel == 2)
        {
            if (InputPattern == CorrectPattern3)
            {
                Debug.Log("Correct!");
                Debug.Log("You win!");
                Pattern3img.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
