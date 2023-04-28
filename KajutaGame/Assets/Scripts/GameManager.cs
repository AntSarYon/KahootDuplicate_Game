using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pregunta
{
    public string Texto;            // Pregunta mostrada
    public List<string> Opciones;   // Lisa de opciones
    public int IndexCorrecta;       // Indice de respuesta correcta

    //-------------------------------------

    //*CONSTRUCTOR*
    public Pregunta()
    {
        Opciones = new List<string>();
    }
}

//*************************************************
//*************************************************

public class GameManager : MonoBehaviour
{
    //Referencia a los Componentes de Texto de la UI
    public TextMeshProUGUI TextoPregunta;
    public TextMeshProUGUI TextoTimer;

    //Referencias a los Componentes Botones de la UI
    public Button ButOpcion1;
    public Button ButOpcion2;
    public Button ButOpcion3;
    public Button ButOpcion4;

    //Lista de Preguntas e índice de la misma
    private List<Pregunta> listaPreguntas;
    private int index = 0;

    //Controlador de tiempo transcurrido
    private float timer = 20f;

    //-----------------------------------------------------

    private void Start()
    {
        // 1. Crear las preguntas
        CrearPreguntas();

        // 2. Cargar pregunta inicial
        CargarPregunta(0);
    }

    //-----------------------------------------------------
    private void Update()
    {
        //Actualizamos el Texto correspondiente al Timer conviertiendolo en Integer
        TextoTimer.text = Mathf.RoundToInt(timer).ToString();

        //Reducimos el tiempo del Timer a partir del DeltaTime transcurrido
        timer -= Time.deltaTime;

        //Si ya se acabó el tiempo, mostramos un guión
        if (timer < 0f)
        {
            // Acabo el tiempo
            TextoTimer.text = "¡TimeOut!";
        }
    }

    //-----------------------------------------------------
    private void CrearPreguntas()
    {
        //Instanciamos una nueva lista de preguntas
        listaPreguntas = new List<Pregunta>();

        //Creamos Preguntas
        Pregunta p1 = new Pregunta();
        p1.Texto = "¿Quién era el Padre de Luke Skywalker?";
        p1.Opciones.Add("Obi-Wan Kenobi");
        p1.Opciones.Add("Darth Vader");
        p1.Opciones.Add("Han Solo");
        p1.Opciones.Add("Yoda");
        p1.IndexCorrecta = 1;

        Pregunta p2 = new Pregunta();
        p2.Texto = "¿Por qué Anakin Skywalker se hizo malo?";
        p2.Opciones.Add("Porque no le dieron el rango de Maestro");
        p2.Opciones.Add("Porque le invitaron helado");
        p2.Opciones.Add("Para salvar a Padme");
        p2.Opciones.Add("Porque los Jedi lo traicionaron");
        p2.IndexCorrecta = 2;

        //Agregamos las preguntas a Lista
        listaPreguntas.Add(p1);
        listaPreguntas.Add(p2);
    }

    //-----------------------------------------------------
    private void CargarPregunta(int index)
    {
        //Mostramos la pregunta en la UI a partir del índice en turno.
        Pregunta pregunta = listaPreguntas[index];
        TextoPregunta.text = pregunta.Texto;

        //Configuración del Texto de los Botones de opción

        //1. Encontramos el COMPONENTE de Texto DENTRO DEL OBJETO HIJO DEL BOTÓN.
        //2. Habiendo identificado el componente Texto del Hijo, le asignamos la opión correspondiente
        
        TextMeshProUGUI textoBoton1 = 
            ButOpcion1.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        textoBoton1.text = pregunta.Opciones[0];

        TextMeshProUGUI textoBoton2 =
            ButOpcion2.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        textoBoton2.text = pregunta.Opciones[1];

        TextMeshProUGUI textoBoton3 =
            ButOpcion3.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        textoBoton3.text = pregunta.Opciones[2];

        TextMeshProUGUI textoBoton4 =
            ButOpcion4.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        textoBoton4.text = pregunta.Opciones[3];
    }

    //-----------------------------------------------------
    // La siguiente función esta asociada a los botones directamente
    // Algunos de sus parámetros de entrada se han configurado
    // directamente desde el Inspector
    public void SeleccionarOpcion(int num)
    {
        //Obtenemos la pregunta en turno
        Pregunta pregunta = listaPreguntas[index];

        //Generamos una Variable de tipo Color
        Color color;

        //Si el número que le corresponde al Boton es el mismo
        //que al Índice de respuesta correcta...
        if (pregunta.IndexCorrecta == num)
        {
            // Selecciono el color Verde
            color = Color.green;
        }
        //Si no era la respuesta correcta...
        else
        {
            //Selecciono el color Rojo
            color = Color.red;
        }

        // Dependiendo de cual sea el Boton oprimido,
        // se modificará su apariencia
        switch (num)
        {
            // Nota: Dado que Unity no permite modificar
            // directamente el valor del parámetro de un componente
            // Debemos primero declararlo como variable

            case 0:
                var colors = ButOpcion1.colors;
                colors.normalColor = color;
                colors.highlightedColor = color;
                colors.selectedColor = color;
                ButOpcion1.colors = colors;
                break;

            case 1:
                colors = ButOpcion2.colors;
                colors.normalColor = color;
                colors.highlightedColor = color;
                colors.selectedColor = color;
                ButOpcion2.colors = colors;
                break;

            case 2:
                colors = ButOpcion3.colors;
                colors.normalColor = color;
                colors.highlightedColor = color;
                colors.selectedColor = color;
                ButOpcion3.colors = colors;
                break;

            case 3:
                colors = ButOpcion4.colors;
                colors.normalColor = color;
                colors.highlightedColor = color;
                colors.selectedColor = color;
                ButOpcion4.colors = colors;
                break;
        }
    }
}