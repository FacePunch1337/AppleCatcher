using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public TMPro.TextMeshPro hp_Text;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            int currentHp = int.Parse(hp_Text.text);
            currentHp -= 1;
            hp_Text.text = currentHp.ToString();
            StartCoroutine(DestroyApple(collision.gameObject));
        }
    }

    private IEnumerator DestroyApple(GameObject apple)
    {
        yield return new WaitForSeconds(3f);
        Destroy(apple);
    }
}
