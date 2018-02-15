using UnityEngine;
using System.Collections;

public class FSMAddInt : MonoBehaviour {

    public Animator FSM;
    public string Property;
    //public bool Value;
    public Callback CallbackAction = new Callback();

    void Awake()
    {
        if (FSM == null)
            FSM = GetComponent<Animator>();
    }

    //TODO: Get value to be added, currently only uses 1
    public void AddInt()
    {
        if (FSM == null)
            return;

        FSM.SetInteger(Property, FSM.GetInteger(Property) + 1);
        if (CallbackAction.MessageReceiver == "" ||
            CallbackAction.Message == "")
            return;

        var msgReceiver = GameObject.Find(CallbackAction.MessageReceiver).transform;
        msgReceiver.SendMessage(CallbackAction.Message, SendMessageOptions.DontRequireReceiver);
    }
}
