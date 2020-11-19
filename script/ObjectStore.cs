using UnityEngine;
using System.IO;

/*
Attach Object Store to an empty gameobject to allow it to work 
*/
public class ObjectStore : MonoBehaviour{
    string savePath;
    void Awake() {
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }

    public void Save(PersistentObject obj){
        using(
            var w = new BinaryWriter(File.Open(savePath,FileMode.Create))
        ){
            obj.Save(new GameDataWriter(w));
        }
    }

    public void Load(PersistentObject obj){
        using(
            var r = new BinaryReader(File.Open(savePath,FileMode.Open))
        ){
            obj.Load(new GameDataReader(r));
        }
    }
}