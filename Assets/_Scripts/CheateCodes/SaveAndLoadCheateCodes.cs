using UnityEngine;

public class SaveAndLoadCheateCodes : MonoBehaviour
{
    [ContextMenu("Reset Save Data")]
    void ResetSaveData()
    {
        SaveData loadData = new SaveData();
        SaveLoadSystem.Save(loadData);
    }
}