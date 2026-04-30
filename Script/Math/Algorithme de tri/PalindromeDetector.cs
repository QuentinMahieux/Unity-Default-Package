using System;
using UnityEngine;

public class PalindromeDetector : MonoBehaviour
{
    public string palindrome;
    
    bool DetectPalindrome(string newPadlindrome)
    {
        string palindromeTest = newPadlindrome.Replace(" ", "");
        for (int i = 0; i < palindromeTest.Length; i++)
        {
            if (i > (palindromeTest.Length - 1) / 2) return true;
            if (palindromeTest[i] != palindromeTest[palindromeTest.Length - 1 - i]) return false;
        }
        return true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Debug.Log(DetectPalindrome(palindrome));
    }
}
