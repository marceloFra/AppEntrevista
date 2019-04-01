using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntrevista.CS
{
    public class Servicio
    {
             public static string IP = "http://192.168.0.136:85/";//QA S. Av.Policia
        //   public static string IP = "http://192.168.1.100:85/";
        //   public static string IP = "http://192.168.1.2:3000/";
        //   public static string IP = "http://192.168.0.109:3000/";
        //   public static string IP = "http://192.168.1.17:3000/";
        //   public static string IP = "http://192.168.1.26:3000/";
         //  public static string IP = "http://192.168.0.130:3000/";

        public static string GenerarNombre(int IdPostulante, int idRequerimiento, int idListpregunta, int idPregunta)
        {
            var idPosStr = "";

            if (IdPostulante < 10)
            {
                idPosStr = "00000" + IdPostulante.ToString();
            }
            else if (IdPostulante < 100)
            {
                idPosStr = "0000" + IdPostulante.ToString();
            }
            else if (IdPostulante < 1000)
            {
                idPosStr = "000" + IdPostulante.ToString();
            }
            else if (IdPostulante < 1000)
            {
                idPosStr = "00" + IdPostulante.ToString();
            }
            else if (IdPostulante < 10000)
            {
                idPosStr = "0" + IdPostulante.ToString();
            }
            else
            {
                idPosStr = IdPostulante.ToString() + "";
            }

            var idReqStr = "";

            if (idRequerimiento < 10)
            {
                idReqStr = "00000" + idRequerimiento.ToString();
            }
            else if (idRequerimiento < 100)
            {
                idReqStr = "0000" + idRequerimiento.ToString();
            }
            else if (idRequerimiento < 1000)
            {
                idReqStr = "000" + idRequerimiento.ToString();
            }
            else if (idRequerimiento < 1000)
            {
                idReqStr = "00" + idRequerimiento.ToString();
            }
            else if (idRequerimiento < 10000)
            {
                idReqStr = "0" + idRequerimiento.ToString();
            }
            else
            {
                idReqStr = idRequerimiento.ToString() + "";
            }

            var idListPregStr = "";

            if (idListpregunta < 10)
            {
                idListPregStr = "00000" + idListpregunta.ToString();
            }
            else if (idListpregunta < 100)
            {
                idListPregStr = "0000" + idListpregunta.ToString();
            }
            else if (idListpregunta < 1000)
            {
                idListPregStr = "000" + idListpregunta.ToString();
            }
            else if (idListpregunta < 1000)
            {
                idListPregStr = "00" + idListpregunta.ToString();
            }
            else if (idListpregunta < 10000)
            {
                idListPregStr = "0" + idListpregunta.ToString();
            }
            else
            {
                idListPregStr = idListpregunta.ToString() + "";
            }

            var idPregStr = "";

            if (idPregunta < 10)
            {
                idPregStr = "00000" + idPregunta.ToString();
            }
            else if (idPregunta < 100)
            {
                idPregStr = "0000" + idPregunta.ToString();
            }
            else if (idPregunta < 1000)
            {
                idPregStr = "000" + idPregunta.ToString();
            }
            else if (idPregunta < 1000)
            {
                idPregStr = "00" + idPregunta.ToString();
            }
            else if (idPregunta < 10000)
            {
                idPregStr = "0" + idPregunta.ToString();
            }
            else
            {
                idPregStr = idPregunta.ToString() + "";
            }

            return idPosStr + idReqStr + idListPregStr + idPregStr + "";

        }


    }
} 