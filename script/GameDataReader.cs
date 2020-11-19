using UnityEngine;
using System.IO;

public class GameDataReader{
    BinaryReader reader;
    public GameDataReader(BinaryReader reader){
        this.reader = reader;
    }
    public int ReadInt(){
        return reader.ReadInt32();
    }
    public float ReadFloat(){
        return reader.ReadSingle();
    }
    public Quaternion ReadQuaternion(){
        Quaternion q;
        q.x=reader.ReadSingle();        
        q.y=reader.ReadSingle();        
        q.z=reader.ReadSingle();        
        q.w=reader.ReadSingle();        
        return q; 
    }
    public Vector3 ReadVector3(){
        Vector3 v;
        v.x=reader.ReadSingle();
        v.y=reader.ReadSingle();
        v.z=reader.ReadSingle();
        return v;
    }
}
