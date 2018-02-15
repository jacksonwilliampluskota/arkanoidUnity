using UnityEngine;
using System.Collections;

/// <summary>
/// Follows the position of a target gameobject, with an optional Ease factor
/// (Ease 0 = no delay, Ease 1 = smoothly lagging behind)
/// </summary>
public class Follow : MonoBehaviour {

    public Transform Target;
    [Range(0,1)]
    public float Ease = 0f;
    public bool DoOnUpdate;

    public void Update()
    {
        if (DoOnUpdate)
            Do();
    }

    // When 'Ease' is greater than 1, 'Do' should probably be ran from a 'On Stay' state
    public void Do()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, 1-Ease);
	}
}
