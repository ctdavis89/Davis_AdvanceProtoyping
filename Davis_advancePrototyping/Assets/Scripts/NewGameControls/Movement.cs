using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float mSpeed;
    private Vector3 spawn;

    // Use this for initialization
    void Start()
    {
        spawn = transform.position;
        mSpeed = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }





    IEnumerator Scheme1()
    {
        yield return new WaitForSecondsRealtime(20);

        
        StartCoroutine(Scheme2());
        StopCoroutine(Scheme1());
    }


    IEnumerator Scheme2()
    {
        yield return new WaitForSecondsRealtime(20);


        StartCoroutine(Scheme1());
       
        StopCoroutine(Scheme2());

    }
}
