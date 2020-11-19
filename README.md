# Unity Objects Management For Save and Load Persistent Data
# GameDataReader
A public class using system io to read binary data
# GameDataWriter
A public class using system io to write binary data
# PersistentObject
An parent identity for objects with interface for read and write, inheritant from monobehaviour
# ObjectStore
An object store which parse the savePath and system data path, wrap it with binary reader and write and create our own writer and reader for persistent object to use
# GameManager
The manager is inheritant from persistentobject. It has logics:
1. React to Inputs from user;
2. Create a writer and write the objects data into an persistent binary file
3. Create a reader and read the objects data and restore the list of objects
