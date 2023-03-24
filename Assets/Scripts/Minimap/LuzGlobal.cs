using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzGlobal : MonoBehaviour
{
    public int velRot = 1;

    void Update()
    {
        transform.Rotate(velRot * Time.deltaTime,0,0);
    }
}
