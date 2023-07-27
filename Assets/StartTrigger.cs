using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartTriggerr : MonoBehaviour
{
    public TMP_Text MessageBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        MessageBox.enabled = false;
    }
}
