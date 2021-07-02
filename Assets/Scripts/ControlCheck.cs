using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class ControlCheck : MonoBehaviour
{
    public static bool PcControl = true;

    public void ChangeControlToPc()
    {
        PcControl = true;
    }

    public void ChangeControlToMobile()
    {
        PcControl = false;
    }
}
