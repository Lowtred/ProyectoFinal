using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public SkinnedMeshRenderer visto;
    //public MeshRenderer visto;
    // Start is called before the first frame update
    void Start()
    {
        visto.enabled=false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vision"))
        {
            visto.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vision"))
        {
            visto.enabled = false;
        }
    }
}
