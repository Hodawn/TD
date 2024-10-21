using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    public SplineAnimationController controller;

    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine("StartTrain");
    }
    IEnumerator StartTrain()
    {
        yield return new WaitForSeconds(1f);
      
        controller.Play();

        Debug.Log("±âÂ÷ ½¹");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
