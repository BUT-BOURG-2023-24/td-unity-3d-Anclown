using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounterUi : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemies Killed : " + GameManager.Instance.score;
    }
}
