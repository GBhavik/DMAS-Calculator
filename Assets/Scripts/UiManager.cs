using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Number Buttons")]
    [SerializeField] private Button Key0;
    [SerializeField] private Button Key1;
    [SerializeField] private Button Key2;
    [SerializeField] private Button Key3;
    [SerializeField] private Button Key4;
    [SerializeField] private Button Key5;
    [SerializeField] private Button Key6;
    [SerializeField] private Button Key7;
    [SerializeField] private Button Key8;
    [SerializeField] private Button Key9;
    [SerializeField] private Button dotKey;

    [Header("Operation Buttons")]
    [SerializeField] private Button DivideKey;
    [SerializeField] private Button MultiplicationKey;
    [SerializeField] private Button PlusKey;
    [SerializeField] private Button MinusKey;
    [SerializeField] private Button EqualKey;

    [Header("Control Buttons")]
    [SerializeField] private Button ACKey;
    [SerializeField] private Button DeleteKey;

    [Header("Input Handler")]
    [SerializeField] private InputHandler inputHandler;

    private void Start()
    {
        SetupButtons();
    }

    void SetupButtons()
    {
        Key0.onClick.AddListener(() => inputHandler.AddNumber("0"));
        Key1.onClick.AddListener(() => inputHandler.AddNumber("1"));
        Key2.onClick.AddListener(() => inputHandler.AddNumber("2"));
        Key3.onClick.AddListener(() => inputHandler.AddNumber("3"));
        Key4.onClick.AddListener(() => inputHandler.AddNumber("4"));
        Key5.onClick.AddListener(() => inputHandler.AddNumber("5"));
        Key6.onClick.AddListener(() => inputHandler.AddNumber("6"));
        Key7.onClick.AddListener(() => inputHandler.AddNumber("7"));
        Key8.onClick.AddListener(() => inputHandler.AddNumber("8"));
        Key9.onClick.AddListener(() => inputHandler.AddNumber("9"));

        dotKey.onClick.AddListener(inputHandler.AddDot);

        DivideKey.onClick.AddListener(() => inputHandler.AddOperator("÷"));
        MultiplicationKey.onClick.AddListener(() => inputHandler.AddOperator("×"));
        PlusKey.onClick.AddListener(() => inputHandler.AddOperator("+"));
        MinusKey.onClick.AddListener(() => inputHandler.AddOperator("-"));

        EqualKey.onClick.AddListener(inputHandler.CalculateResult);
        ACKey.onClick.AddListener(inputHandler.AllClear);
        DeleteKey.onClick.AddListener(inputHandler.DeleteLast);
    }
}