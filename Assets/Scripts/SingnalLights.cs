using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingnalLights : MonoBehaviour
{

    public GameObject WarningPrefab;

    public void ShowWrning(float minH, float maxH, float value)
    {
        float curentH = -4;
        float size = 2 / (value);
        while (curentH < 5)
        {
            if ((curentH- size/2 > maxH) || (curentH + size/2 < minH))
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + curentH, transform.position.z);
                GameObject light = Instantiate(WarningPrefab, pos, Quaternion.identity) as GameObject;
                light.transform.localScale.Set(size,size,size);
            }
            curentH += 1f;
        }
    }
}
