using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    public class DocumentoDAO
    {
        public AddResult UploadDocument(String ruta)
        {
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                FileStream fStream = File.OpenRead(ruta);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Documento VALUES('1', @data, @date, @dateMod, 'El que sea', 'Quien sea')", connection))
                {
                    command.Parameters.Add(new SqlParameter("@data", contents));
                    command.Parameters.Add(new SqlParameter("@date", DateTime.Today));
                    command.Parameters.Add(new SqlParameter("@dateMod", DateTime.Today));
                    command.ExecuteNonQuery();
                }

            }
            return AddResult.Success;

        }
        public String getDocument(String iDExp, String documentType)
        {
            string ToSaveFileTo = "~\\File\\Report.pdf";
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection cn = dbConnection.GetConnection())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Documento FROM dbo.Documento WHERE ID_Expediente=@expediente AND Tipo_Documento=@TipoDocumento", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {
                            byte[] fileData = (byte[])dr.GetValue(0);
                            using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData);
                                    bw.Close();
                                }
                            }
                        }
                        dr.Close();
                    }
                }
            }
            return ToSaveFileTo;
        }
    }
}
