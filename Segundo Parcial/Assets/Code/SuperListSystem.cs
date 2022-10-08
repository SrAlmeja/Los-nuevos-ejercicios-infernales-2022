using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperListSystem : MonoBehaviour
{
    private int[] _content;
    private int _count;
    private List<GameObject> _type;
    private List<List<GameObject>> _mergedList;

    public int Show(int[] n)
    {
        if (n.Length == 0)
        {
            return 0;
        }
        else
        {
            Debug.Log(Show(_content));
            return 1 + Show(n[1..]);
        }
    }
    public void SortOrder(bool isOrdenated, int[]n)
    {
        if (n.Length >= (n.Length+1))
        {
            return isOrdenated(false);
        }
    }

    public int Merge(int[] n)
    {
        if (n.Length == 0)
        {
            return 0;
        }
    }
   
    

    public int[] CountProperty
    {
        get { return _content;}
        set { _content[0] = value.Length; }
    }
}
