using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer (typeof (CommentAttribute))]
public class CommentDrawer : DecoratorDrawer
{
//	// Used to calculate the height of the box
//	public static Texture2D lineTex = null;

	CommentAttribute Comment {
	    get { return ((CommentAttribute) attribute); }
	}

	// Get the height of the element
	public override float GetHeight ()
	{
		return base.GetHeight () + Comment.space;
	}

	// Override the GUI drawing for this attribute
	public override void OnGUI (Rect pos)
	{		
		// Define the line parameters
//		float lineWidth = pos.width * attribute.widthPct;
//		float lineX = ((pos.x + pos.width) - lineWidth - ((pos.width - lineWidth) / 2));
//		float lineY = pos.y + (attribute.space / 2);
//		float lineHeight = attribute.thickness;
	    if (Comment == null)
	        return;
		// Draw the actual line
		//EditorGUI.DrawPreviewTexture (new Rect (lineX, lineY, lineWidth, lineHeight), lineTex);
	    EditorGUI.HelpBox(new Rect(pos.x, pos.y, pos.width, GetHeight()), Comment.text, MessageType.Info);
	}

//		// Get the color the line should be
//		Color co = Color.white;
//		switch (divider.col.ToLower ())
//		{
//			case "white": co = Color.white; break;
//			case "red": co = Color.red; break;
//			case "blue": co = Color.blue; break;
//			case "green": co = Color.green; break;
//			case "gray": co = Color.gray; break;
//			case "grey": co = Color.grey; break;
//			case "black": co = Color.black; break;
//		}
//
//		// Define the texture we will use to draw the line
//		lineTex = new Texture2D (1, 1, TextureFormat.ARGB32, true);
//		lineTex.SetPixel (0, 1, co);
//		lineTex.Apply ();

}
