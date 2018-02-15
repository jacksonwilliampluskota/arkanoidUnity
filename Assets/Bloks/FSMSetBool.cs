using UnityEngine;
using System.Collections;

public class FSMSetBool : MonoBehaviour {

    [Comment("Methods: BoolTrue, BoolFalse")]
    public Animator FSM;
    public string Property;
    //public bool Value;

    void Awake()
    {
        if (FSM == null)
            FSM = GetComponent<Animator>();
    }

    public void Do(bool value)
    {
        if (FSM == null)
            return;

        FSM.SetBool(Property, value);
    }

    public void BoolTrue()
    {
        FSM.SetBool(Property, true);
    }

    public void BoolFalse()
    {
        FSM.SetBool(Property, false);
    }

}
