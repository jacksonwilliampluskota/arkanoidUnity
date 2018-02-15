using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class FSMOnStateChange : MonoBehaviour
{
    public Animator Anim;
    [FormerlySerializedAs("NewState")]
    public string ObservedState;
    private int _observedState;

    public int layerIdx;
    public string MessageReceiver;
    private GameObject _messageReceiver;
    public string Message;
    public UnityEvent Callback;

    private int _lastState;

    void Awake()
    {
        if (Anim == null)
            Anim = GetComponent<Animator>();
        if (Anim != null)
        {
            _lastState = Anim.GetCurrentAnimatorStateInfo(layerIdx).fullPathHash;
            _observedState = Animator.StringToHash("Base Layer."+ObservedState);
        }
        Debug.Log("Last: " + _lastState + " Observed: " + _observedState);
        if (MessageReceiver == "")
            return;
        _messageReceiver = GameObject.Find(MessageReceiver);
    }
	
	void LateUpdate ()
	{
	    if (Anim == null)
	        return;
	    var currentState = Anim.GetCurrentAnimatorStateInfo(layerIdx);
	    if (_observedState != _lastState)
	        _lastState = currentState.fullPathHash;
	    if (currentState.fullPathHash != _observedState)
	        return;
	    if (Callback != null)
	        Callback.Invoke();
	    SendMessageCheck();
	}

    private void SendMessageCheck()
    {
        if (_messageReceiver == null || Message == "")
            return;
        _messageReceiver.SendMessage(Message, SendMessageOptions.DontRequireReceiver);
    }
}
