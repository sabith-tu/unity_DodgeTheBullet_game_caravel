using UnityEngine;

public static class CurencyManager
{

    static int GetCurency()
    {
        SaveData loadedData = SaveLoadSystem.Load();
        return loadedData.Curency;
    }

    static void SetCurency(int amoundToSetAsNewCurency)
    {
        SaveData loadedData = SaveLoadSystem.Load();
        loadedData.Curency = amoundToSetAsNewCurency;
        SaveLoadSystem.Save(loadedData);
    }

    static void ResetCurencyToZero()
    {
        SetCurency(0);
    }

    static void AddToCurency(int amoundToAdd)
    {
        SetCurency((GetCurency() + amoundToAdd));
    }

    static void RemoveFromCurency(int amoundToRemove)
    {
        SetCurency((GetCurency() - amoundToRemove));
    }

    static bool CanSpent(int spentAmound)
    {
        if (GetCurency() >= spentAmound) return true;
        else return false;
    }

    
    
    
}