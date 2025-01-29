using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cuando vayamos a Assets > Create > Item > Create New Item, se creará un nuevo archivo de tipo Item en el proyecto.
[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    //Informacion que tienen los items
    public string itemsName;
    public Sprite ItemIcono;

}

