using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingManager : MonoBehaviour
{
    [SerializeField] private LineManager TheLineManager;

    [SerializeField] private LineRenderer Lr;

    [SerializeField] private Button DrawBtn1;
    [SerializeField] private Button DrawBtn2;
    [SerializeField] private Button DrawBtn3;
    [SerializeField] private Button DrawBtn4;
    [SerializeField] private Button DrawBtn5;

    [SerializeField] private Button ResetBtn;

    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;
    [SerializeField] private Transform P3;
    [SerializeField] private Transform P4;
    [SerializeField] private Transform P5;

    // Start is called before the first frame update

    void Start()
    {

        DrawBtn1.onClick.AddListener(delegate { DrawPressed(P1.transform,"1"); });
        DrawBtn2.onClick.AddListener(delegate { DrawPressed(P2.transform,"2"); });
        DrawBtn3.onClick.AddListener(delegate { DrawPressed(P3.transform,"3"); });
        DrawBtn4.onClick.AddListener(delegate { DrawPressed(P4.transform,"4"); });
        DrawBtn5.onClick.AddListener(delegate { DrawPressed(P5.transform,"5"); });
        ResetBtn.onClick.AddListener(ResetPressed);
    }

    private void DrawPressed(Transform PosTranform, string PatternNumber)
    {
        TheLineManager.AddPointer(PosTranform, PatternNumber);

    }

    private void ResetPressed()
    {
        TheLineManager.ResetScreen();
        TheLineManager.AddToMistakes();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
