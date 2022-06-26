using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button btn = null;

    private void ParameterOnClick(string test)
    {
        Debug.Log(test);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // adding a delegate with parameters
        btn.onClick.AddListener(delegate { ParameterOnClick("Button was pressed!"); });
    }
}
