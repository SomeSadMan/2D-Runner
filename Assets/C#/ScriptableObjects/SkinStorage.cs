using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new storage", menuName = "SO/Storage")]
public class SkinStorage : ScriptableObject
{
   public SkinSettings[] skinSettingsArray;
}
