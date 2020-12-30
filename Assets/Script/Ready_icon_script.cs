using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ready_icon_script : MonoBehaviour
{
    public GameObject main_logic;
    public Text TT;

    void Start()
    {
        print("i am here");
        main_logic = GameObject.Find("Logic_driver");
    }

    public void ButtonEvents()
    {
        TT.text = "destroy";
        Destroy(this.gameObject);
        main_logic.SendMessage("Begin_sig", 3);
    }
}
