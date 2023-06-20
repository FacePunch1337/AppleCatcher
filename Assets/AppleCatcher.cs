using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AppleCatcher : MonoBehaviour
{
    public TMP_Text counter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            int text = Convert.ToInt32(counter.text);
            text += 1;
            counter.text = text.ToString();
        }
    }
}
