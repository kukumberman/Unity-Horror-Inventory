using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask m_LayerMask = 0;
    [SerializeField] private Inventory m_Inventory = null;

    private Camera m_Camera = null;

    private void Start()
    {
        m_Camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        if (Physics.Raycast(m_Camera.ScreenPointToRay(Input.mousePosition), out var hit, 5, m_LayerMask))
        {
            if (hit.collider.TryGetComponent<ItemPickup>(out var itemPickup))
            {
                if (m_Inventory.CanAddItem(itemPickup.InventoryItem))
                {
                    itemPickup.gameObject.SetActive(false);
                }
            }
        }
    }
}
