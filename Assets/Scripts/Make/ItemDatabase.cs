using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    //������ list
    public List<Item> itemDB = new List<Item>();
    
    private void Start()
    {
         
    }

   
}
