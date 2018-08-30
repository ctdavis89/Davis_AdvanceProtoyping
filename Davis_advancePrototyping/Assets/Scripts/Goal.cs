using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OntriggerEnter()
    {
        GameManager.instance.Win();

    }
}
