using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentObject
{
    public PersistentObject prefab;
    public ObjectStore store;
    public KeyCode createCode = KeyCode.C;
    public KeyCode deleteCode = KeyCode.D;
    public KeyCode loadCode = KeyCode.L;
    public KeyCode quitCode = KeyCode.Q;
    public KeyCode saveCode = KeyCode.S;
    private Transform parent;
    private List<PersistentObject> objects;
    void Awake()
    {
        objects = new List<PersistentObject>();
        parent = new GameObject("Parent").transform;
        parent.transform.position = Vector3.one;
    }
    // Start is calle d before the first frame update
    void Start()
    {        
        prefab.transform.position = new Vector3(1,1,1);

    }
    public override void Save(GameDataWriter writer){
        writer.Write(objects.Count);
        for(int i =0;i<objects.Count;i++){
            objects[i].Save(writer);
        }
    }
    public override void Load(GameDataReader reader)
    {
        int count = reader.ReadInt();
        for(int i =0;i<count;i++){
            PersistentObject persistent = Instantiate(prefab,parent);
            persistent.Load(reader);
            objects.Add(persistent);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0,0,500,50),Application.persistentDataPath);    
    }


    void Create(){
            PersistentObject p = Instantiate(prefab,parent);
            Transform child = p.transform;
            child.localPosition = Random.insideUnitSphere * 5f;
            child.localRotation = Random.rotation;
            child.localScale = Vector3.one * Random.Range(0.1f,1f);
            objects.Add(p);
    }
    void Restart(){
            foreach(PersistentObject p in objects){
                Destroy(p.gameObject);
            }
            objects.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(createCode)){
            Create();
        }
        if(Input.GetKeyDown(deleteCode)){
            Restart();
        }
        if(Input.GetKeyDown(quitCode)){
            Application.Quit();
        }
        if(Input.GetKeyDown(saveCode)){
            store.Save(this);
        }
        if(Input.GetKeyDown(loadCode)){
            Restart();
            store.Load(this);
        }
    }
}
