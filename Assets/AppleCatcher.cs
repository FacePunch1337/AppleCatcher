using UnityEngine;
using TMPro;

public class AppleCatcher : MonoBehaviour
{
    public TMP_Text counter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            int count = int.Parse(counter.text);
            counter.text = (count + 1).ToString();
            Destroy(other.gameObject);
        }
    }
}
