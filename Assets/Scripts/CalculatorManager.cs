using System.Collections.Generic;
using UnityEngine;

public class CalculatorManager : MonoBehaviour
{
    public string UserInput;

    public readonly char[] mathOperators = { '÷', '×', '+', '-' };

    public string Calculate()
    {
        List<string> tokens = ParseInput(UserInput);
        float result = CalculateResult(tokens);
        Debug.Log($"Result: {UserInput} = {result}");
        return result.ToString("0.####");
    }

    private List<string> ParseInput(string input)
    {
        List<string> tokens = new List<string>();
        string currentNumber = string.Empty;

        foreach (char c in input)
        {
            if (IsOperator(c))
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    tokens.Add(currentNumber);
                    currentNumber = string.Empty;
                }
                tokens.Add(c.ToString());
            }
            else
            {
                currentNumber += c;
            }
        }

        if (!string.IsNullOrEmpty(currentNumber))
        {
            tokens.Add(currentNumber);
        }

        return tokens;
    }

    private float CalculateResult(List<string> tokens)
    {
        foreach (char op in mathOperators)
        {
            for (int i = 1; i < tokens.Count - 1; i++)
            {
                if (tokens[i][0] == op)
                {
                    float firstValue = float.Parse(tokens[i - 1]);
                    float secondValue = float.Parse(tokens[i + 1]);

                    float result = 0;

                    
                    switch (op)
                    {
                        case '÷':   
                            result = firstValue / secondValue;
                            break;
                        case '×': 
                            result = firstValue * secondValue;
                            break;
                        case '+':
                            result = firstValue + secondValue;
                            break;
                        case '-':
                            result = firstValue - secondValue;
                            break;
                    }

                    tokens[i - 1] = result.ToString();
                    tokens.RemoveRange(i, 2);
                    i--;
                }
            }
        }

        return float.Parse(tokens[0]);
    }

    private bool IsOperator(char c)
    {
        foreach (char op in mathOperators)
        {
            if (c == op) return true;
        }
        return false;
    }


}