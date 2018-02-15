using UnityEngine;
using System.Collections;

public class SetVisibility : MonoBehaviour
{
    [Comment("Methods: Show, Hide")]
    public bool Status = true;
    private Renderer _renderer;

    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Do(Status);
    }

	public void Do (bool status)
	{
	    Status = status;
	    _renderer.enabled = status;
	}

    //---- Messages ----//

    public void Show()
    {
        Do(true);
    }

    public void Hide()
    {
        Do(true);
    }
}
