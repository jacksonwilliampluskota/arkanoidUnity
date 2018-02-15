/*
 	Provides a divider in-editor drawer.
*/


using UnityEngine;


public class CommentAttribute : PropertyAttribute
{
	#region Properties

	// The amount of vertical space this comment box takes up
	public float space = 10f;
	
	// The color of the line
	public string text = "This is a comment";
	
	// The width of the line (percentage of the window)
//	public float widthPct = 0.85f;
	
	#endregion
	
	
	#region Constructors
	
	public CommentAttribute (string text)
	{
		this.text = text;
	}
	
	public CommentAttribute () { }
	
	#endregion
}