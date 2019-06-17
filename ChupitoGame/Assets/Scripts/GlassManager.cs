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


    // Start is called before the first frame update
    void Start()
    {
        //Cargamos el vaso de la carpeta Resources/Props
        glass = Resources.Load<GameObject>("Props/Glass");
        //Inicializamos las listas para el OP
        objetosActivos = objetosDesactivados = new List<GameObject>();
        spawnGlass();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Instancia un vaso en la posicion original
    /// </summary>
    public void spawnGlass()
    {
        if (objetosDesactivados.Count <= 0)
        {
            objetosActivos.Add(Instantiate(glass, originPosition, Quaternion.identity));
            objetosActivos.Last().GetComponent<Glass>().GlassManager = this;
            objetosActivos.Last().GetComponent<Glass>().IsLeft = direccionDeSpawnIsLeft;

        }
        else
        {
            objetosActivos.Add(objetosDesactivados.First());
            objetosDesactivados.Remove(objetosDesactivados.First());
            objetosActivos.Last().transform.position = originPosition;
        }
    }
}
