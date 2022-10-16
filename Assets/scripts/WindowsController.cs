using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    [SerializeField] private GameObject ballotIdWindow;
    [SerializeField] private GameObject pKWindow;
    [SerializeField] private GameObject mPWindow;

    [SerializeField] private Button ballotIdDoneButton;
    [SerializeField] private Button pKDoneButton;
    [SerializeField] private Button mPDoneButton;

    void Start()
    {
        ballotIdDoneButton.onClick.AddListener(DoAfterIdIntrudaction);
        pKDoneButton.onClick.AddListener(DoAfterPKIntroduction);
        mPDoneButton.onClick.AddListener(DoAfterMPIntroduction);
    }

    private void DoAfterIdIntrudaction()
    {
        ballotIdWindow.SetActive(false);
        pKWindow.SetActive(true);
        mPWindow.SetActive(true);
    }

    private void DoAfterPKIntroduction()
    {
        pKWindow.SetActive(false);
    }

    private void DoAfterMPIntroduction()
    {
        mPWindow.SetActive(false);
    }
}
