using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public enum ContactEventType { Enter, Stay, Exit }

public class TriggerCheck : MonoBehaviour
{
    public ContactEventType EventType;
    public string Tag;
    public string MessageReceiver;
    private Transform _messageReceiver;
    public string Message;
//    public bool Mode2D;
    public UnityEvent Callback;

    /// <summary> To speed things up, let's cache the message receiver gameObject
    /// </summary>
    void Awake()
    {
        if (MessageReceiver == "")
            return;
        _messageReceiver = GameObject.Find(MessageReceiver).transform;
    }

    #region 3D Mode

	public void OnTriggerEnter (Collider other)
	{
	    if (EventType != ContactEventType.Enter)
	        return;
	    Debug.Log("Collision detected!");
	    FireEventCheck(other);
	    SendMessageCheck(other);
	}

    public void OnTriggerStay(Collider other) {
        if (EventType != ContactEventType.Stay)
            return;
        FireEventCheck(other);
        SendMessageCheck(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (EventType != ContactEventType.Exit)
            return;
        FireEventCheck(other);
        SendMessageCheck(other);
    }

    #endregion

    #region 2D Mode

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (EventType != ContactEventType.Enter)
            return;
        Debug.Log("2D Collision detected!");
        FireEventCheck(other);
        Debug.Log(other);
        SendMessageCheck(other);
    }

    public void OnTriggerStay2D(Collider2D other) {
//        if (!Mode2D)
//            return;
        if (EventType != ContactEventType.Stay)
            return;
        FireEventCheck(other);
        SendMessageCheck(other);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
//        if (!Mode2D)
//            return;
        if (EventType != ContactEventType.Exit)
            return;
        FireEventCheck(other);
        SendMessageCheck(other);
    }

 #endregion

    #region Generic methods; 2D and 3D overloads to work with both modes
    private void FireEventCheck(Collider other)
    {
        if (Tag != "" && !other.CompareTag(Tag))
            return;
        if (Callback != null)
            Callback.Invoke();
    }

    private void SendMessageCheck(Collider other)
    {
        if (Message == "")
            return;
        if (MessageReceiver == null)
            _messageReceiver = other.transform;
        _messageReceiver.SendMessage(Message, SendMessageOptions.DontRequireReceiver);
    }

    private void FireEventCheck(Collider2D other)
    {
        if (Tag != "" && !other.CompareTag(Tag))
            return;
        if (Callback != null)
            Callback.Invoke();
    }

    private void SendMessageCheck(Collider2D other)
    {
        if (Message == "")
            return;
        if (MessageReceiver == null)
            _messageReceiver = other.transform;
//        Debug.Log(_messageReceiver.name);
        Debug.Log(other);
        other.SendMessage(Message, SendMessageOptions.DontRequireReceiver);
    }
    #endregion
}
