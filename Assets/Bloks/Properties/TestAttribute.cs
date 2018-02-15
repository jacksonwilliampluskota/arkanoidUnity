//#if UNITY_EDITOR
using UnityEngine;

public class TestAttribute : PropertyAttribute {
    //public string tooltip;
    public string comment;

    public TestAttribute( string comment/*, string tooltip*/ ) {
        //this.tooltip = tooltip;
        this.comment = comment;
    }
}

//public class PropDraw : MonoBehaviour {
//    [Comment("This is the description","And this is the tooltip")]
//    public int thisIsADummy;
//}

//#endif
