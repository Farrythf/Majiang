using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ready_icon_script : MonoBehaviour
{
    public Text TT;
    public void ButtonEvents()
    {
        TT.text = "destroy";
        Destroy(this.gameObject);
    }

}
