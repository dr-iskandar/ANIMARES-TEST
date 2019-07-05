using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changealpha : MonoBehaviour
{
    public Color color = Color.white;
    public float alphanya;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        alphanya -= Time.deltaTime * 200f;
        GetComponent<Renderer>().material.color = new Color32(255, 255, 255, (byte)alphanya);
    }

}
