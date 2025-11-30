using System.Linq;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private CalculatorManager manager;

    private string currentInput = "";

    private void Start()
    {
        UpdateDisplay();
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            HandleKeyboardInput();
        }
    }

    void HandleKeyboardInput()
    {
        // Check for number input using Input.inputString
        if (!string.IsNullOrEmpty(Input.inputString))
        {
            char inputChar = Input.inputString[0];

            // Numbers
            if (char.IsDigit(inputChar))
            {
                AddNumber(inputChar.ToString());
                return;
            }

            // Operators
            switch (inputChar)
            {
                case '/':
                    AddOperator("÷");
                    return;
                case '*':
                    AddOperator("×");
                    return;
                case '+':
                    AddOperator("+");
                    return;
                case '-':
                    AddOperator("-");
                    return;
                case '.':
                    AddDot();
                    return;
                case '=':
                    CalculateResult();
                    return;
            }
        }

        //other
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CalculateResult();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteLast();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            AllClear();
        }
    }

    public void AddNumber(string number)
    {
        currentInput += number;
        UpdateDisplay();
    }

    public void AddDot()
    {
        if (currentInput.Length == 0)
        {
            currentInput = "0.";
            UpdateDisplay();
            return;
        }

        string lastNumber = "";
        for (int i = currentInput.Length - 1; i >= 0; i--)
        {
            if (manager.mathOperators.Contains(currentInput[i]))
            {
                break;
            }
            lastNumber = currentInput[i] + lastNumber;
        }

        if (string.IsNullOrEmpty(lastNumber))
        {
            currentInput += "0.";
            UpdateDisplay();
            return;
        }

        if (!lastNumber.Contains("."))
        {
            currentInput += ".";
            UpdateDisplay();
        }
    }

    public void AddOperator(string operatorSymbol)
    {
        if (currentInput.Length > 0)
        {
            char lastChar = currentInput[currentInput.Length - 1];
            if (manager.mathOperators.Contains(lastChar))
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }

            currentInput += operatorSymbol;
            UpdateDisplay();
        }
    }

    public void CalculateResult()
    {
        if (currentInput.Length > 0)
        {
            char lastChar = currentInput[currentInput.Length - 1];
            if (manager.mathOperators.Contains(lastChar))
            {
                return;
            }

            manager.UserInput = currentInput;
            string result = manager.Calculate();
            currentInput = result;
            UpdateDisplay();
            currentInput = "";
        }
    }

    public void AllClear()
    {
        currentInput = "";
        UpdateDisplay();
    }

    public void DeleteLast()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        if (displayText != null)
        {
            displayText.text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;
        }
    }
}