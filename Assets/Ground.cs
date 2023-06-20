using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            StartCoroutine(DestroyApple(collision.gameObject));
        }
    }

    private IEnumerator DestroyApple(GameObject apple)
    {
        yield return new WaitForSeconds(3f);
        Destroy(apple);
    }
}
