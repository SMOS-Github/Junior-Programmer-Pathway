using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    private float m_ProductionSpeed = 0.5f;
    public float ProductionSpeed // delete semicolon
    {
        get { return m_ProductionSpeed; } // getter returns backing field
        set {// m_ProductionSpeed = value;
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative production speed!");
            }
            else
            {
                m_ProductionSpeed = value; // original setter now in if/else statement
            }

        } // setter uses backing field
    }

    public ResourceItem Item;

   // public float ProductionSpeed = 0.5f;

    private float m_CurrentProduction = 0.0f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += ProductionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        m_CurrentProduction += m_ProductionSpeed * Time.deltaTime;

        return $"Producing at the speed of {m_ProductionSpeed}/s";
       // return $"Producing at the speed of {ProductionSpeed}/s";
        
    }
    
    
}
