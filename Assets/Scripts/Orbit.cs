using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orbit : MonoBehaviour
{
    float timer = 0;
    float m_alpha = 255;

    public LevelChanger levelchanger;

    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;

    public float rotSpeed;
    public bool rotateClockwise;
    public bool roteObj = true;
    public float waitForLerp = 2;

    public GameObject[] spherelain;
    public Color color = Color.white;
    public bool chosed;
    public bool changePosition;


    void Update()
    {
        if (roteObj != false)
        {
            timer += Time.deltaTime * rotSpeed;
            Rotate();
        }
        else
        {
            if (m_alpha <= 2)
            {
                chosed = false;
            }
        }

        if (chosed == true)
        {
            AlphaController();
            roteObj = false;
        }

        if (changePosition == true)
        {
            MoveObject();
        }
    }

    void OnMouseDown()
    {
        StartCoroutine(MovementControll());
    }

    void Rotate()
    {
        if (centerPoint != gameObject.transform)
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

    }

    void MoveObject()
    {

        Vector3 aPos = gameObject.transform.position;
        Vector3 bPos = new Vector3(0, 0, 0);
        gameObject.transform.position = Vector3.Lerp(aPos, bPos, Time.deltaTime);
        waitForLerp -= Time.deltaTime;

        if (waitForLerp <= 0)
        {
            DontDestroyOnLoad(gameObject);
            levelchanger.FadeToNextLevel();
            gameObject.GetComponent<Orbit>().enabled = false;
        }
    }

    void AlphaController()
    {
        m_alpha -= Time.deltaTime * 200f;
        for (int i = 0; i < spherelain.Length; i++)
        {
            spherelain[i].GetComponent<Orbit>().enabled = false;
            spherelain[i].GetComponent<Renderer>().material.color = new Color32(255, 255, 255, (byte)m_alpha);
        }
    }

    IEnumerator MovementControll()
    {
        chosed = true;
        yield return new WaitForSeconds(1);
        changePosition = true;
    }

}