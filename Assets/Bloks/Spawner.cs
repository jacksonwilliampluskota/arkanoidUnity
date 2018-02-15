using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public float ReloadTime = 1f;
    public GameObject ObjectToSpawn;
    public GameObject SpawnTransform;
    public Vector3 SpawnPosition;
    public Vector3 SpawnRotation;
    public bool CopyTransformRotation;
    private bool CanSpawn = true;

    public void Start() {
        CanSpawn = true;
    }

    public void Do() {
        if (!CanSpawn)
            return;

        var spawnedObject = Instantiate(ObjectToSpawn) as GameObject;
        if (SpawnTransform)
            spawnedObject.transform.position = SpawnTransform.GetComponent<Transform>().position;
        else
            spawnedObject.transform.position = SpawnPosition;

        if (CopyTransformRotation)
            spawnedObject.transform.rotation = SpawnTransform.GetComponent<Transform>().rotation;
        else {
            spawnedObject.transform.rotation = Quaternion.Euler(SpawnRotation);
        }

        CanSpawn = false;
        StartCoroutine(WaitForReload());
    }

    public void Spawn()
    {
        Do();
    }

    private IEnumerator WaitForReload() {
        yield return new WaitForSeconds(ReloadTime);
        CanSpawn = true;
    }
}
