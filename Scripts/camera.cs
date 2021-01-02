using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class camera : MonoBehaviour
{

    public GameObject target;//the target object
    private float speedMod = 20.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at
    private int count;
    private ArrayList clicked = new ArrayList();
    
    public Text txt_v1;
    public Text txt_v2;
    public Text txt_cobb;
    
    public GameObject p1,p2,p3,p4; // add 4 spines
    
    void Start()
    {//Set up things on the start method
        point = target.transform.position;//get target's coords
        transform.LookAt(point+new Vector3(0,0,2.5f));//makes the camera look to it
        count = 0;
        // set the 4 spines invisibale
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
    }
    private float Ang;
    private Transform cobb_line1;
    private Transform cobb_line2;
    private Color default_col = new Color(0.7f, 0.7f, 0.7f, 1.0f);
    void Update()
    {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround(target.transform.position, Vector3.up * Input.GetAxis("Horizontal"), speedMod * Time.deltaTime);
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * 15f, Space.Self);
        float up_down = Input.GetAxis("Vertical");
        transform.Translate(0, up_down * 0.3f, 0, Space.Self);
        //transform.Rotate(Vector3.up * Input.GetAxis("Horizontal"));
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    //Debug.Log("Logged");
                    if (clicked.Contains(hit.transform.name))
                    {
                        clicked.Remove(hit.transform.name);
                        count--;
                        hit.transform.GetComponent<Renderer>().material.color = default_col;
                        //(hit.transform.GetComponent("Halo") as Behaviour).enabled = false;
                        foreach (Transform child in hit.transform)
                        {
                            child.gameObject.SetActive(false);

                        }
                        //hit.transform
                    }
                    else
                    { 
                        if (count < 2)
                        {
                            clicked.Add(hit.transform.name);
                            hit.transform.GetComponent<Renderer>().material.color= Color.blue; 
                            count++;
                            //(hit.transform.GetComponent("Halo") as Behaviour).enabled = true;
                        }

                    }
                        
                    }
                }
            }
        if (count == 2)
        {
            cobb_line1= GameObject.Find((string)clicked[0]).transform;
            cobb_line2 = GameObject.Find((string)clicked[1]).transform;
            
            foreach (Transform child in cobb_line1)
            {
                child.gameObject.SetActive(true);

            }
            foreach (Transform child in cobb_line2)
            {

                child.gameObject.SetActive(true);
            }
            float angle=0f;
           
            if (cobb_line1.eulerAngles.x > 180)
                angle = 360 - cobb_line1.eulerAngles.x + cobb_line2.eulerAngles.x;
            else
                if(cobb_line2.eulerAngles.x > 180) 
                    angle = 360 - cobb_line2.eulerAngles.x + cobb_line1.eulerAngles.x;

            //Vector3 dir = cobb_line1.position - cobb_line2.position;
            //float angle = -1*(Mathf.Atan2(dir.y, dir.z) * Mathf.Rad2Deg);
            
            if (angle < 180)
                Ang = angle;
            else
                Ang = 0;
        }
    }
    public void Reset()
    {
        count = 0;
        clicked = new ArrayList();
        txt_cobb.text = "";
        txt_v1.text = "";
        txt_v2.text = "";
        
        foreach (Transform v in p1.transform)
        {
            v.transform.GetComponent<Renderer>().material.color = default_col;
            foreach (Transform child in v.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        foreach (Transform v in p2.transform)
        {
            v.transform.GetComponent<Renderer>().material.color = default_col;
            foreach (Transform child in v.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        foreach (Transform v in p3.transform)
        {
            v.transform.GetComponent<Renderer>().material.color = default_col;
            foreach (Transform child in v.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        foreach (Transform v in p4.transform)
        {
            v.transform.GetComponent<Renderer>().material.color = default_col;
            foreach (Transform child in v.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

    }
    public void OnGUI()
    {
        //if (isClicked)
        if (count == 2)
        {
            //GUI.Label(new Rect(300, 3, 400, 100), "Angle " + Ang + " " + (string)clicked[0] + "/" + (string)clicked[1]);
            txt_cobb.text = Ang.ToString("F2")+"°";
            txt_v1.text = clicked[0].ToString();
            txt_v2.text =clicked[1].ToString();
        }
        else
        {
            txt_cobb.text = "";
            txt_v1.text = "";
            txt_v2.text = "";
        }
    }
}
 
 

