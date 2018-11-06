using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Servicio
    {
        public string Login(string Usuario, string Pass)
        {
            string cScript = "exec appLogin '" + Usuario + "','" + Pass + "'";
            DataTable oTabla = new DataTable();
            SqlConnection oCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("WSConexion").ConnectionString);
            SqlDataAdapter oAdap = new SqlDataAdapter(cScript, oCon);

            try
            {
                oCon.Open();
                oAdap.Fill(oTabla);

                if (!oTabla == null)
                {
                    if (oTabla.Rows.Count > 0)
                    {
                        string cRespuesta = oTabla.Rows(0).Item(0);

                        return cRespuesta;
                    }
                    else
                        return "Error Usuario o Contrasea Incorrecto";
                }
                else
                    return "Error Usuario o Contrasea Incorrecto";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
    }
}
