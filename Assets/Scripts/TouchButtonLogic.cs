using UnityEngine;
using System.Collections;

public class TouchButtonLogic : MonoBehaviour
{
//    private bool touched = false;
    // Use this for initialization
    // Update is called once per frame
    public void CheckTouches()
    {
        //if there a touch on screen
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (this.GetComponent<GUITexture>().HitTest(touch.position))
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        // print(this.name + " touch started");
                        //touched = true;
                        //this.SendMessage("OnTouchDown");
                        OnTouchDown();
                    } else if (touch.phase == TouchPhase.Ended)
                    {
                        // this.SendMessage("OnTouchUp");
                        OnTouchUp();
                        //touched = false;
                        // print(this.name + " touch ended");
                    }
                }
            }
        }
    }
    public virtual void OnTouchUp()
    {
        print(name + "is not using the OnTouchUp");
    }
    public virtual void  OnTouchDown()
    {
        print(name + "is not using the OnTouchDown");
    }
}