using UnityEngine;
using System.IO;

[DisallowMultipleComponent]
public class PersistentObject : MonoBehaviour{
    public virtual void Save(GameDataWriter writer){
        writer.Write(transform.localPosition);
        writer.Write(transform.localRotation);
        writer.Write(transform.localScale);
    }
    public virtual void Load(GameDataReader reader){
        transform.localPosition=reader.ReadVector3();
        transform.localRotation=reader.ReadQuaternion();
        transform.localScale=reader.ReadVector3();
    }
}