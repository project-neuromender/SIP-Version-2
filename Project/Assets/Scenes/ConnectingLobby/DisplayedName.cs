using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class DisplayedName : MonoBehaviour
{
    public InputField NameText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Name Text : " + NameText.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
