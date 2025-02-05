using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : NamMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] public List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.DiamondOre, 1);
        this.AddItem(ItemCode.IronOre, 20);
        this.AddItem(ItemCode.GoldOre, 20);
    }

    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfile;
        ItemCode itemCode = itemProfile.itemCode;
        ItemType itemType = itemProfile.itemType;

        if (itemType == ItemType.Equipment) return this.AddEquipMent(itemInventory);
        return this.AddItem(itemCode, addCount);
    }

    public virtual bool AddEquipMent(ItemInventory itemPicked)
    {   

        if (this.IsInventoryFull()) return false;

        ItemInventory item = itemPicked.Clone ();

        this.items.Add(item);
        return true;
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);
        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExit;

        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExit = this.GetItemNotFullStack(itemCode);
            if (itemExit == null)
            {
                if (this.IsInventoryFull()) return false;
                itemExit = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExit);
            }
            newCount = itemExit.itemCount + addRemain;
            itemMaxStack = this.GetMaxStack(itemExit);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExit.itemCount;
                newCount = itemExit.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }
            itemExit.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }

    private bool IsInventoryFull()
    {
        if (this.items.Count > this.maxSlot) return true;
        return false;
    }

    private ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };
        return itemInventory;
    }

    private ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    private int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemCode != itemInventory.itemProfile.itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }
        return null;
    }

    private bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;
        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }
        return totalCount;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;

        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;
            itemInventory = this.items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }
        this.ClearEmptySLot();
    }

    private void ClearEmptySLot()
    {
        ItemInventory itemInventory;
        for (int i = 0; i < this.Items.Count; i++)
        {
            itemInventory = this.Items[i];
            if (itemInventory.itemCount == 0) this.Items.RemoveAt(i);
        }
    }
}












//     public virtual bool AddItem(ItemCode itemCode, int addCount)
//     {
//         ItemInventory itemInventory = this.GetItemByCode(itemCode);

//         int newCount = itemInventory.itemCount + addCount;
//         if (newCount > itemInventory.maxStack) return false;

//         itemInventory.itemCount = newCount;
//         return true;
//     }

//     public virtual bool DeductItem(ItemCode itemCode, int addCount)
//     {
//         ItemInventory itemInventory = this.GetItemByCode(itemCode);
//         int newCount = itemInventory.itemCount - addCount;
//         if (newCount < 0) return false;

//         itemInventory.itemCount = newCount;
//         return true;
//     }

//     public virtual bool TryDeductItem(ItemCode itemCode, int addCount)
//     {
//         ItemInventory itemInventory = this.GetItemByCode(itemCode);
//         int newCount = itemInventory.itemCount - addCount;
//         if (newCount < 0) return false;
//         return true;
//     }
//     public virtual ItemInventory GetItemByCode(ItemCode itemCode)
//     {
//         ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
//         if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
//         return itemInventory;
//     }

//     protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
//     {
//         var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
//         foreach (ItemProfileSO profile in profiles)
//         {
//             if (profile.itemCode != itemCode) continue;
//             ItemInventory itemInventory = new ItemInventory
//             {
//                 itemProfile = profile,
//                 maxStack = profile.defaultMaxStack
//             };
//             this.items.Add(itemInventory);
//             return itemInventory;
//         }
//         return null;
//     }
// }
