using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlassManager : MonoBehaviour
{
    //Posicion de spanw
    public Vector3 originPosition;
    //Prefab del vaso
    private GameObject glass;
    //Direccion a la que va
    public bool direccionDeSpawnIsLeft = true;

    //Hechas para el OP
    public List<GameObject> objetosActivos;
    public List<GameObject> objetosDesactivados;

    //PoolGlass
    [HideInInspector]
    public GameObject poolGlass;

    //Brazo
    public Player_manager player_manager;

    //Gamemanager
    public Game_manager gameManager;

    //Lista de Shot
    public List<kind_shot> shots;

    // Start is called before the first frame update
    void Start()
    {
        //Cargamos el vaso de la carpeta Resources/Props
        glass = Resources.Load<GameObject>("Props/Glass");
        //Inicializamos las listas para el OP
        objetosActivos = new List<GameObject>();
        objetosDesactivados = new List<GameObject>();
        //Creamos el objeto pool
        poolGlass = new GameObject();
        poolGlass.name = "PoolGlass";
        Instantiate(poolGlass, originPosition, Quaternion.identity);

        gameManager = GameObject.Find("GameManager").GetComponent<Game_manager>();
        shots = gameManager.getListShot();
        spawnGlass();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) //|| !player_manager.myHand.GetComponent<Hand_class>().agarrando)
            spawnGlass();
    }



    /// <summary>
    /// Instancia un vaso en la posicion original
    /// </summary>
    public void spawnGlass()
    {
        if (objetosDesactivados.Count == 0)
        {
            objetosActivos.Add(Instantiate(glass, originPosition, Quaternion.identity));
            objetosActivos.Last().GetComponent<Glass>().restartObject(this.gameObject, shots.First());
            shots.RemoveAt(0);
        }
        else
        {
            objetosActivos.Add(objetosDesactivados.First());
            objetosDesactivados.Remove(objetosDesactivados.First());
            objetosActivos.Last().transform.rotation = Quaternion.identity;
            objetosActivos.Last().GetComponent<Glass>().restartObject(this.gameObject, shots.First());
            shots.RemoveAt(0);
        }
    }

    internal void RemoveGlass(GameObject _toRemove)
    {
        if (objetosActivos.Count <= 1)
        {
            spawnGlass();
        }

        _toRemove.GetComponent<Rigidbody2D>().Sleep();
        _toRemove.GetComponent<Glass>().isActive = false;
        _toRemove.SetActive(false);
        _toRemove.transform.parent = poolGlass.transform;
        objetosDesactivados.Add(_toRemove);
        objetosActivos.Remove(_toRemove);
    }
}
