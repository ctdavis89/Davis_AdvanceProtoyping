using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float mSpeed;
    private Vector3 spawn;

    bool _useSchemeOne;

    // Use this for initialization
    void Start()
    {
        spawn = transform.position;
        mSpeed = 5f;

        StartCoroutine(Scheme1());
    }

    // Update is called once per frame
    void Update()
    {
        if(_useSchemeOne)
            transform.Translate(mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        else
            transform.Translate(mSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }


    IEnumerator Scheme1()
    {
        yield return new WaitForSecondsRealtime(20);

        _useSchemeOne = true;
        StartCoroutine(Scheme2());
    }


    IEnumerator Scheme2()
    {
        yield return new WaitForSecondsRealtime(20);

        _useSchemeOne = false;
        StartCoroutine(Scheme1());
    }
}
