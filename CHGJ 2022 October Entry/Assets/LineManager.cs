using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{

    public LineRenderer LineR;

    public Transform Pointer1;
    public Transform Pointer2;
    public Transform Pointer3;
    public Transform Pointer4;
    public Transform Pointer5;

    // Start is called before the first frame update
    void Start()
    {
        LineR.SetPosition(0, Pointer1.transform.position);
        LineR.SetPosition(1, Pointer2.transform.position);
        LineR.SetPosition(2, Pointer3.transform.position);
        LineR.SetPosition(3, Pointer4.transform.position);
        LineR.SetPosition(4, Pointer5.transform.position);



    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
