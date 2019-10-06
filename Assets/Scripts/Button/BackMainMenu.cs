using System.Collections;
using System.Collections.Generic;
using Assets.GameSystem.Constant.Enum;
using GameSystem.Service;
using UnityEngine;
using UnityEngine.UI;

public class BackMainMenu : MonoBehaviour
{
    private void Start()
    {
        var button = this.GetComponent<Button>();
        button.onClick.AddListener(BackToMainMenu);
    }

    private void BackToMainMenu()
    {
        SceneService.Instance.ChangeScene(SceneEnum.MainMenu);
    }
}
