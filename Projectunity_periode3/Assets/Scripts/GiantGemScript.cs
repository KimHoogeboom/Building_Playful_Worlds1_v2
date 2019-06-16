using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantGemScript : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        GameManager.instance.Win();

    }
}
