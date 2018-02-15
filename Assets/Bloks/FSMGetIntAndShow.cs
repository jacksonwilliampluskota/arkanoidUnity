using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FSMGetIntAndShow : MonoBehaviour {

    [Comment("Method: GetIntAndShow")]
    public string VariableFSM;
    private Animator _animator;
    public string IntPropertyName;
    public Text TextTarget;

    // If no public value defined, get the container's Text
    public void Awake()
    {
        if (TextTarget == null)
            TextTarget = GetComponent<Text>();
    }

    public void GetIntAndShow ()
	{
	    GameObject fsmObject;
	    Animator fsm;
	    if (!GetTargets(out fsmObject, out fsm, TextTarget)) return;

	    var intVal = fsm.GetInteger(IntPropertyName);

	    TextTarget.text = intVal + "";
	}

    private bool GetTargets(out GameObject fsmObject,
        out Animator fsm, Text txt)
    {
        fsmObject = GameObject.Find(VariableFSM);
        if (fsmObject == null) {
            Debug.LogError("Variable FSM not found!");
            fsm = null;
            return false;
        }

        fsm = fsmObject.GetComponent<Animator>();
        if (fsm == null) {
            Debug.LogError("Animator not found!");
            return false;
        }

        if (txt == null) {
            Debug.LogError("Text not assigned!");
            return false;
        }
        return true;
    }
}
