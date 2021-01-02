using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Moveit : MonoBehaviour
{
    //public Slider slider;
    public Slider_global_value slider;
    // Preserve the original and current orientation
    private float previousValue;
    public Transform spine;
    public Dictionary<string, Transform> dict = new Dictionary<string, Transform>();
    public Dictionary<string, Vector3> dict1 = new Dictionary<string, Vector3>();
    public Dictionary<string, Quaternion> dict2 = new Dictionary<string, Quaternion>();
    private Vector3 destinationPosition;

    private Quaternion rotationPosition;
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    Color c1 = Color.white;
    void Awake()
    {
        // Assign a callback for when this slider changes
        //this.slider.onValueChanged.AddListener(this.OnSliderChanged);

        // And current value
        this.previousValue = this.slider.value;


        foreach (Transform child in spine)
        {
            dict.Add(child.name, child);
            
            //Debug.Log(child.name);

        }
        foreach (Transform child in transform)
        {
            dict1.Add(child.name, child.transform.position);
            dict2.Add(child.name, child.transform.rotation);
            //Debug.Log(child.name);

        }
        //destinationPosition = dict["atlas"].transform.position;
        //rotationPosition = dict["atlas"].transform.rotation;


    }
    void Start()
    {
        //_initialPosition = dict1["atlas"].transform.position;
        //_initialRotation = dict1["atlas"].transform.rotation;
        
        foreach (Transform child in transform)
        {
            GameObject line1 = new GameObject();
            //GameObject line2 = new GameObject();
            line1.AddComponent<LineRenderer>();
            //line2.AddComponent<LineRenderer>();

            LineRenderer l = line1.GetComponent<LineRenderer>();
            List<Vector3> pos = new List<Vector3>();
            pos.Add(child.transform.position + new Vector3(0, 0, 5f));
            pos.Add(child.transform.position + new Vector3(0, 0, -5f));
            
            l.startWidth = 0.1f;
            l.endWidth = 0.1f;
            l.SetPositions(pos.ToArray());
            l.useWorldSpace = false;
            l.transform.parent = child;
            line1.transform.name = "line1";
            line1.transform.GetComponent<Renderer>().material.color = c1;
            line1.transform.rotation = child.transform.rotation;
            line1.SetActive(false);
            /*
            LineRenderer l2 = line2.GetComponent<LineRenderer>();
            List<Vector3> pos1 = new List<Vector3>();
            pos1.Add(pos[0] + new Vector3(0, +5, 0));
            pos1.Add(pos[0] + new Vector3(0, -5, 0));
            l2.startWidth = 0.1f;
            l2.endWidth = 0.1f;
            l2.SetPositions(pos1.ToArray());
            l2.useWorldSpace = false;
            l2.transform.parent = child;
            line2.transform.name = "line2";
            line2.SetActive(false);
        */
            //Debug.Log(child.name);

        }
        
    }
   
    void OnSliderChanged(float value)
    {
        // How much we've changed
        float delta = value - this.previousValue;


        foreach (Transform c in gameObject.transform)
        {

            c.transform.position = Vector3.Lerp(dict1[c.name], dict[c.name].transform.position, value);
            c.transform.rotation = Quaternion.Lerp(dict2[c.name], dict[c.name].transform.rotation, value);

        }
        // Set our previous value for the next change
        this.previousValue = value;
    }
    void Update()
    {
        OnSliderChanged(slider.value);
    }
}
