using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Slider_global_value : MonoBehaviour
{
    public Slider slider;
    public float value;
    // Start is called before the first frame update
    void Awake()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
    }

    void OnSliderChanged(float new_value)
    {
        value = new_value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        slider.value = 0;
    }
}
