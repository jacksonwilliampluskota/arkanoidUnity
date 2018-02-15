using UnityEngine;
using System.Collections;

public class FSMTrigger : MonoBehaviour
{
    [Comment("Methods: Trigger")]
    public Animator FSM;
    public string Property;

    public void Awake()
    {
        if (FSM == null)
            FSM = GetComponent<Animator>();
    }

	public void Do(string property)
	{
	    if (FSM == null)
	        return;
	    FSM.SetTrigger(property);
	}

    public void Trigger()
    {
        FSM.SetTrigger(Property);
    }
}
