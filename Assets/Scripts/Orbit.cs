using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;

    public float rotSpeed;
    public bool rotateClockwise;
    public bool roteObj = true;

    float timer = 0;
    float m_alpha = 255;

    public GameObject[] spherelain;
    public Color color = Color.white;
    public bool chosed;




    // Update is called once per frame
    void Update()
    {
        if (roteObj!=false)
        {
            timer += Time.deltaTime * rotSpeed;
            Rotate();
        }
        else
        {
            if (m_alpha <= 1)
            {
                chosed = false;
            }
        }

        if (chosed != false)
        {
            m_alpha -= Time.deltaTime * 200f;
            for (int i = 0; i < spherelain.Length; i++)
            {
                spherelain[i].GetComponent<Renderer>().material.color = new Color32(255, 255, 255, (byte)m_alpha);
            }
            roteObj = false;
        }
    }

    void Rotate()
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;

        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
    }

    private void OnMouseDown()
    {
        chosed = true;
    }
}
