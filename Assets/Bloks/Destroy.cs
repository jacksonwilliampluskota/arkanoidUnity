using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    public float Lifetime = 0f;
    public GameObject ObjectToDestroy;

    public void Awake()
    {
        // Will destroy its own game object if nothing set in 'ObjectToDestroy'
        if (ObjectToDestroy == null)
            ObjectToDestroy = this.gameObject;

        if (Mathf.Approximately(Lifetime, 0f))
            Do();

        StartCoroutine(WaitForTimer());
    }

    private IEnumerator WaitForTimer()
    {
        yield return new WaitForSeconds(Lifetime);
        Do();
    }

    private void Do() 
    {
        Destroy(ObjectToDestroy);
    }
}
