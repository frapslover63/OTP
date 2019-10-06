using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem.Service;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private void Start()
    {
        var button = this.GetComponent<Button>();
        button.onClick.AddListener(PauseService.Instance.PauseButtonTrigger);
    }
}
