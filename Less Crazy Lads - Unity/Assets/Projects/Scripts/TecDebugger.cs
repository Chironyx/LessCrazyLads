using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TecDebugger : MonoBehaviour
{
    [SerializeField] VarStorge varStorge;

    [SerializeField] Slider playerSpeed;
    [SerializeField] Slider playerMoveForward;
    [SerializeField] Slider spacing;
    [SerializeField] Slider safezone;
    [SerializeField] Slider easy;
    [SerializeField] Slider mid;
    [SerializeField] Slider hard;

    [SerializeField] Text playerSpeedUI;
    [SerializeField] Text playerMoveForwardUI;
    [SerializeField] Text spacingUI;
    [SerializeField] Text safezoneUI;
    [SerializeField] Text easyUI;
    [SerializeField] Text midUI;
    [SerializeField] Text hardUI;
    public void UpdateDebuggUi()
    {
        playerSpeed.value = varStorge.playerSpeed;
        playerMoveForward.value = varStorge.forwardSpeed;
        spacing.value = varStorge.spacingBtwObsticale;
        safezone.value = varStorge.safeDisFromStart;
        easy.value = varStorge.easyPattern;
        mid.value = varStorge.midPattern;
        hard.value = varStorge.hardPattern;
        playerMoveForwardUI.text = "Player Forward Speed: " + varStorge.forwardSpeed.ToString();
    }

    public void ChangePlayerSpeed(float change)
    {
        varStorge.playerSpeed = change;
        playerSpeedUI.text = "Player Forward Speed: " + varStorge.playerSpeed.ToString();
    }

    public void ChangePlayerForwardSpeed(float change)
    {
        varStorge.forwardSpeed = change;
        playerMoveForwardUI.text = "Player Forward Speed: " + varStorge.forwardSpeed.ToString();
    }

    public void ChangeEasyPattern(float change)
    {
        varStorge.easyPattern = change;
        easyUI.text = "Easy Pattern Percent: " + varStorge.easyPattern.ToString();
    }

    public void ChangeMidPattern(float change)
    {
        varStorge.midPattern = change;
        midUI.text = "Mid Pattern Percent: " + varStorge.midPattern.ToString();
    }

    public void ChangeHardPattern(float change)
    {
        varStorge.hardPattern = change;
        hardUI.text = "Hard Pattern Percent: " + varStorge.hardPattern.ToString();
    }

    public void ChangeSpaceBTWObsticale(float change)
    {
        varStorge.spacingBtwObsticale = change;
        spacingUI.text = "Spacing Btw Obsticale: " + varStorge.spacingBtwObsticale.ToString();
    }

    public void ChangeSafeSpace(float change)
    {
        varStorge.safeDisFromStart = change;
        safezoneUI.text = "Safe Distance from start: " + varStorge.safeDisFromStart.ToString();
    }
}
