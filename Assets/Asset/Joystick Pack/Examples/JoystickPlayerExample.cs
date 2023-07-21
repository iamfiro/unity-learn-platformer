using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public Slider slider;
    public TMP_Text sliderText;


    private void Start()
    {
        sliderText.text = speed.ToString();
    }
    public void FixedUpdate()
    {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void Update()
    {
      
    }

    public void OnValuChanged()
    {
        speed = slider.value;
        sliderText.text = speed.ToString();
    }

    
}