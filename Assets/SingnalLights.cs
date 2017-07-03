using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingnalLights : MonoBehaviour
{

    public GameObject WarningPrefab;

    public void ShowWrning(float minH, float maxH)
    {
        float curentH = -4;
        while (curentH < 5)
        {
            if ((curentH-0.5 > maxH) || (curentH + 0.5 < minH))
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + curentH, transform.position.z);
                Instantiate(WarningPrefab, pos, Quaternion.identity);
            }
            curentH += 1f;
        }
    }
}
