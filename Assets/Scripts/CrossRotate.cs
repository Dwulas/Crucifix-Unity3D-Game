﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}
