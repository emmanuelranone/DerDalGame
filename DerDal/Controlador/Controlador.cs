using System;
using System.Collections.Generic;
using System.Collections;

using Base;


namespace Controlador
{
    public class Controlador
    {
        Base.Base b;
        Puntaje p;
        List<Pregunta> preguntas;
        List<int> botonRep;


        public Controlador()
        {
            b = new Base.Base();
            p = new Puntaje();
            preguntas = new List<Pregunta>();
            creaPreguntas();
        }
        
        public List<string> darPuntos()
        {
            List<Puntaje> lista = b.obtenerPuntaje();
            ObjetoRelacional or = new ObjetoRelacional();

            return or.PuntajeRelacional(lista);           
        }

        public void guardarPuntaje(string n, string p)
        {
            ObjetoRelacional or = new ObjetoRelacional();

            b.guardarRegistro(or.puntajeObjeto(n, p));            
        }
        
        public void creaPreguntas()
        {
            //List<Pregunta> preguntas = new List<Pregunta>();
            Pregunta p = new Pregunta();

            p.Categoria = "Geografía";
            p.Preg = "¿En cuál de los siguientes países NO hay ningún desierto?";
            p.Opc1 = "Alemania";
            p.Opc2 = "España";
            p.Opc3 = "Chile";
            p.Opc4 = "Mongolia";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Geografía";
            p.Preg = "¿Cuál es la capital de Suiza?";
            p.Opc1 = "Berna";
            p.Opc2 = "Zurich";
            p.Opc3 = "Ginebra";
            p.Opc4 = "Basilea";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Geografía";
            p.Preg = "¿A qué país pertenece la Isla de Pascua? ";
            p.Opc1 = "Chile";
            p.Opc2 = "Indonesia";
            p.Opc3 = "Australia";
            p.Opc4 = "Israel";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Historia";
            p.Preg = "¿Cuántos soldados argentinos murieron en la Guerra de las Malvinas?";
            p.Opc1 = "649";
            p.Opc2 = "200";
            p.Opc3 = "1016";
            p.Opc4 = "837";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Historia";
            p.Preg = "¿Con qué emperador estuvo casada Cleopatra?";
            p.Opc1 = "Todas son correctas";
            p.Opc2 = "Ptolomeo XIV";
            p.Opc3 = "Julio César";
            p.Opc4 = "Marco Antonio";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Historia";
            p.Preg = "El Renacimiento marcó el inicio de la Edad...";
            p.Opc1 = "Moderna";
            p.Opc2 = "Antiguedad Clásica";
            p.Opc3 = "Contemporanea";
            p.Opc4 = "Media";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Arte y Literatura";
            p.Preg = "¿Qué odia Mafalda?";
            p.Opc1 = "La sopa";
            p.Opc2 = "El pájaro loco";
            p.Opc3 = "A Manolito";
            p.Opc4 = "Panqueques";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Arte y Literatura";
            p.Preg = "Arroz con leche me quiero...";
            p.Opc1 = "Casar";
            p.Opc2 = "Escapar";
            p.Opc3 = "Matar";
            p.Opc4 = "Cazar";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Arte y Literatura";
            p.Preg = " ¿Quién pintó La Capilla Sixtina?";
            p.Opc1 = "Miguel Ángel";
            p.Opc2 = "Leonardo Da Vinci";
            p.Opc3 = "Giorgio Vasari";
            p.Opc4 = "Tiziano";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Ciencia y Tecnología";
            p.Preg = "¿Cuál de las sisguientes enfermedades ataca al higado? ";
            p.Opc1 = "Hepatitis";
            p.Opc2 = "Diabetes";
            p.Opc3 = "Artrosis";
            p.Opc4 = "Cifoescoliosis";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Ciencia y Tecnología";
            p.Preg = "¿Cuál es la función principal del instestino grueso?";
            p.Opc1 = "La absorción de agua";
            p.Opc2 = "La absorción de nutrientes";
            p.Opc3 = "La digestión mecánica de los alimentos";
            p.Opc4 = "La digestión química de los alimentos";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Ciencia y Tecnología";
            p.Preg = "¿Cuál es el mamífero más grande conocido hasta la actualidad?";
            p.Opc1 = "La ballena azul";
            p.Opc2 = "Elefante";
            p.Opc3 = "Cachalote";
            p.Opc4 = "Rinoceronte";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Entretenimiento";
            p.Preg = "¿En qué año se estrenó la película de Disney Pinocho?";
            p.Opc1 = "1940";
            p.Opc2 = "1950";
            p.Opc3 = "1942";
            p.Opc4 = "1946";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Entretenimiento";
            p.Preg = "¿Quién es Bella en la saga Crepúsculo?";
            p.Opc1 = "Kristen Stewart";
            p.Opc2 = "Cristina Ricci";
            p.Opc3 = "Emma Watson";
            p.Opc4 = "Dakota Fanning";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Entretenimiento";
            p.Preg = "¿Cómo se llamaba el personaje que interpretaba Al Pacino en Scarface?";
            p.Opc1 = "Tony Montana";
            p.Opc2 = "Sonny Montana";
            p.Opc3 = "Michael Corleone";
            p.Opc4 = "Frank Slade";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Deportes";
            p.Preg = "¿Cuál es el clásico rival del Flamengo (BRA)?";
            p.Opc1 = "Corinthians";
            p.Opc2 = "Palmeiras";
            p.Opc3 = "Cruzeiro";
            p.Opc4 = "São Paulo";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Deportes";
            p.Preg = "¿Cuál es el estilo de natación más rápido?";
            p.Opc1 = "Crol";
            p.Opc2 = "Espalda";
            p.Opc3 = "Natación";
            p.Opc4 = "Pecho";
            preguntas.Add(p);

            p = new Pregunta();
            p.Categoria = "Deportes";
            p.Preg = "¿En qué país se inventó el voleibol?";
            p.Opc1 = "Estados Unidos";
            p.Opc2 = "Rusia";
            p.Opc3 = "Francia";
            p.Opc4 = "Japón";
            preguntas.Add(p);
            
        }

        public List<Pregunta> getPreguntas()
        {
            return preguntas;
        }

        public void BotonRep()
        {
            botonRep = new List<int>();
        }

        public int dameNroBoton()
        {
            bool agrega = true;
            Random rnd = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            int nro = 0;
            if (botonRep.Count < 4)
            {
                do
                {
                    agrega = true;
                    nro = rnd.Next(1, 5);
                    for (int i = 0; i < botonRep.Count; i++) // recorro para evitar repetidos
                    {
                        if (nro == Convert.ToInt32(botonRep[i]))
                        {
                            agrega = false;
                        }
                    }
                } while (!agrega);

                botonRep.Add(nro);
            }
            return nro;
        }

    }

}
