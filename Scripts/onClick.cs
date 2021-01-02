using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class onClick : MonoBehaviour
{
    public Text txt_hover;
    public void Start()
    {
        (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
    }
    private string display_name;
    
    //public void OnMouseDown()
    public void OnMouseOver()
    {  
        (gameObject.GetComponent("Halo") as Behaviour).enabled = true;
        display_name = gameObject.transform.name;
    }

    public void OnMouseExit()
    {
        (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
        display_name = "";
    }
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable

   
    private void OnGUI()
    {
        guiStyle.fontSize = 36; //change the font size
        GUI.Label(new Rect(150, 350, 400, 100),  display_name, guiStyle) ;
        //txt_hover.text = this.name;
    }

}