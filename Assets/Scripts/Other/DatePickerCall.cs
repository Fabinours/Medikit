using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatePickerCall : MonoBehaviour
{
    [SerializeField]
    int defaultYear = 2000;
    [SerializeField]
    int defaultMonth = 01;
    [SerializeField]
    int defaultDay = 01;



    InputField input;
   


    void Awake()
    {
        input = GetComponentInChildren<InputField>();
        input.text = defaultYear + "/" + defaultMonth + "/" + defaultDay;
    }

    public void OnClick()
    {
        DatePickerControl.OpenPicker((s) => input.text = s); ;
    }

    public string GetValue()
    {
        return input.text;
    }

    }
