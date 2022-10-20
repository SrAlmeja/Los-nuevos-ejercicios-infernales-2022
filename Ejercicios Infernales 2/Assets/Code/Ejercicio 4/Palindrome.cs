using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Palindrome : MonoBehaviour
{
    // Fields
    private int _size;
    private int _count;
    private string _palindrome;
    private string _value;
    private bool _isPalindrome;
    private Stack<string> revert = new Stack<string>();


    // Properties
    public string palindrome { 
        get { return _palindrome; }
        set {
                if (string.IsNullOrEmpty(value)) { Debug.LogError("No se admiten strings vacios");}
                _palindrome = value; 
            }        
    }

    public string value
    {
        get { return _value; }
        set { _value = value; }
    }

    public string Show()
    {
        Debug.Log(_palindrome);
        return _palindrome;
    }

    public bool isPalindrome()
    {
        Revert(0);
        _isPalindrome = true;
        CheckPalindrome(0);        
        return _isPalindrome;
    }

    void Revert(int i)
    {
        if (i == _size) return;
        revert.Push(_palindrome[i].ToString());
        Revert(i + 1);
    }

    void CheckPalindrome(int i)
    {
        if (i == _size) return;
        string letter = revert.Pop();
        if (letter != _palindrome[i].ToString())
        {
            _isPalindrome = false;
        }
        CheckPalindrome(i + 1);
    }

    public void New(string p)
    {
        if (string.IsNullOrEmpty(p))
        {
            Debug.LogError("No se admiten strings vacios");
        }
        _palindrome = p;
    }
    
    

}