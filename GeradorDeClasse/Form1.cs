using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace GeradorDeClasse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            PreencherList();
        }

        private void lstTabela_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rdbEntidade.Checked)
                entidade();
            else if (rdbBll.Checked)
                Bll();
            else if (rdbDal.Checked)
            {
                Dao();
                CreateProcedure();
            }
        }
        void entidade()
        {
            try
            {
                string conn = txtBanco.Text;
                SqlConnection  myconection = new SqlConnection(conn);
                string strNomeClasse = char.ToUpper(lstTabela.SelectedItem.ToString().Replace("tb", "")[0]) + lstTabela.SelectedItem.ToString().Replace("tb", "").Substring(1);

                SqlCommand cmd = new SqlCommand("Select * from " + lstTabela.SelectedItem, myconection);

                DataTable dt = new DataTable();
                SqlDataAdapter myDa = new SqlDataAdapter(cmd);

                myDa.Fill(dt);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Linq;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine("using System.Threading.Tasks;");
                sb.AppendLine("namespace GerenciadorPortal");
                sb.AppendLine("{");
                sb.AppendLine("public class Entidade" + strNomeClasse);
                sb.AppendLine("\n{");
                foreach (DataColumn col in dt.Columns)
                {
                    sb.AppendLine("public " + dt.Columns["" + col + ""].DataType.FullName.Replace("System.", "") + " " + col + "{get;set;}\n");

                }

                sb.AppendLine("}");
                sb.Append("}");
                txtCampos.Text = sb.ToString();
            }
            catch (Exception erro)
            {

                throw new Exception("Erro: " + erro.Message);
            }


        }
        void Dao()
        {
            try
            {
                string conn = txtBanco.Text;
                string strNomeClasse = char.ToUpper(lstTabela.SelectedItem.ToString().Replace("tb", "")[0]) + lstTabela.SelectedItem.ToString().Replace("tb", "").Substring(1);

                SqlConnection myconection = new SqlConnection(conn);

                SqlCommand cmd = new SqlCommand("Select * from " + lstTabela.SelectedItem, myconection);

                DataTable dt = new DataTable();
                SqlDataAdapter myDa = new SqlDataAdapter(cmd);

                myDa.Fill(dt);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Linq;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine("using System.Threading.Tasks;");
                sb.AppendLine("using System.Data;");
                sb.AppendLine("using Sql.Data.SqlClient;"); 
                sb.AppendLine("using Sql.Data.SqlClient;");
                sb.AppendLine("using GerenciadorPortal.Entidade;");
                sb.AppendLine("using System.Configuration;");
                sb.AppendLine("namespace GerenciadorPortal.Dal");
                sb.AppendLine("{");
                sb.AppendLine("public class Dal" + strNomeClasse + "");
                sb.AppendLine("{");
                sb.AppendLine("string strConn = string.Empty;");
                sb.AppendLine("SqlConnection conn;");
                sb.AppendLine("public Dal" + strNomeClasse + "()");
                sb.AppendLine("{");
                sb.AppendLine("strConn = ConfigurationManager.ConnectionStrings['Conexao'].ToString();").Replace("'", "\"");
                sb.AppendLine("conn = new SqlConnection(strConn);");
                sb.AppendLine("}");
                sb.AppendLine("public DataTable Busca" + strNomeClasse + " ( Entidade" + strNomeClasse + " obj" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("SqlCommand cmd" + strNomeClasse + " = new SqlCommand();");
                sb.AppendLine("SqlDataAdapter da" + strNomeClasse + " = new SqlDataAdapter(cmd" + strNomeClasse + ");");
                sb.AppendLine("DataTable dt" + strNomeClasse + " = new DataTable ();");
                sb.AppendLine("cmd" + strNomeClasse + ".Connection = conn;");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandType = CommandType.StoredProcedure;");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandText = 'spc_" + strNomeClasse + "';").Replace("'", "\"");
                sb.AppendLine("da" + strNomeClasse + ".Fill(dt" + strNomeClasse + ");");
                sb.AppendLine("return dt" + strNomeClasse + ";");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro :'+ erro.Message);").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("public DataTable Busca" + strNomeClasse + "()");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("SqlCommand cmd" + strNomeClasse + " = new SqlCommand();");
                sb.AppendLine("SqlDataAdapter da" + strNomeClasse + " = new SqlDataAdapter(cmd" + strNomeClasse + ");");
                sb.AppendLine("DataTable dt" + strNomeClasse + " = new DataTable();");
                sb.AppendLine("cmd" + strNomeClasse + ".Connection = conn;");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandType = CommandType.StoredProcedure;");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandText = 'spc_" + strNomeClasse + "';").Replace("'", "\"");
                sb.AppendLine("da" + strNomeClasse + ".Fill(dt" + strNomeClasse + ");");
                sb.AppendLine("return dt" + strNomeClasse + ";");

                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");

                sb.AppendLine("throw new Exception ('Erro:'+erro.Message);").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("}");
                //inicio metodo inclusao
                sb.AppendLine("public void Inclui" + strNomeClasse + "(Entidade" + strNomeClasse + "  objEntidade" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("SqlCommand cmd" + strNomeClasse + " = new SqlCommand();");
                sb.AppendLine("cmd" + strNomeClasse + ".Connection = conn;");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandType = CommandType.StoredProcedure;");
                foreach (DataColumn col in dt.Columns)
                {
                    sb.AppendLine("cmd" + strNomeClasse + ".Parameters.AddWithValue('v_" + col + "', objEntidade" + strNomeClasse + "." + col + ");").Replace("'", "\"");

                }
                sb.AppendLine("cmd" + strNomeClasse + ".CommandText = 'spi_" + strNomeClasse + "';").Replace("'", "\"");
                sb.AppendLine("conn.Open();");
                sb.AppendLine("cmd" + strNomeClasse + ".ExecuteNonQuery();");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro: '+ erro.Message );").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("finally");
                sb.AppendLine("{");
                sb.AppendLine("conn.Close();");
                sb.AppendLine("}");
                sb.AppendLine("}");
                //Fim metodo Inclusao
                //inicio metodo Atualizacao
                sb.AppendLine("public void Atualiza" + strNomeClasse + "(Entidade" + strNomeClasse + " objEntidade" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("SqlCommand cmd" + strNomeClasse + " = new SqlCommand();");
                sb.AppendLine("cmd" + strNomeClasse + ".Connection = conn;");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandType = CommandType.StoredProcedure;");
                foreach (DataColumn col in dt.Columns)
                {
                    sb.AppendLine("cmd" + strNomeClasse + ".Parameters.AddWithValue('v_" + col + "', objEntidade" + strNomeClasse + "." + col + ");").Replace("'", "\"");

                }
                sb.AppendLine("cmd" + strNomeClasse + ".CommandText = 'spa_" + strNomeClasse + "';").Replace("'", "\"");
                sb.AppendLine("conn.Open();");
                sb.AppendLine("cmd" + strNomeClasse + ".ExecuteNonQuery();");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro: '+ erro.Message );").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("finally");
                sb.AppendLine("{");
                sb.AppendLine("conn.Close();");
                sb.AppendLine("}");
                sb.AppendLine("}");
                //fim metodo atualizacao
                //Inicio Metodo Excluir
                sb.AppendLine("public void Exclui" + strNomeClasse + "(Entidade" + strNomeClasse + " objEntidade" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("SqlCommand cmd" + strNomeClasse + " = new SqlCommand();");
                sb.AppendLine("cmd" + strNomeClasse + ".Connection = conn;");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandType = CommandType.StoredProcedure;");
                sb.AppendLine("cmd" + strNomeClasse + ".Parameters.AddWithValue('v_" + dt.Columns[0] + "', objEntidade" + strNomeClasse + "." + dt.Columns[0] + ");").Replace("'", "\"");
                sb.AppendLine("cmd" + strNomeClasse + ".CommandText = 'spe_" + strNomeClasse + "';").Replace("'", "\"");
                sb.AppendLine("conn.Open();");
                sb.AppendLine("cmd" + strNomeClasse + ".ExecuteNonQuery();");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro: '+ erro.Message );").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("finally");
                sb.AppendLine("{");
                sb.AppendLine("conn.Close();");
                sb.AppendLine("}");
                sb.AppendLine("}");
                //Fim MetodoExcluir
                sb.AppendLine("}");
                sb.AppendLine("}");
                txtCampos.Text = sb.ToString();
            }
            catch (Exception erro)
            {

                throw new Exception("Erro: " + erro.Message);
            }




        }
        void CreateProcedure()
        {
            string conn = txtBanco.Text;
            string strNomeClasse = char.ToUpper(lstTabela.SelectedItem.ToString().Replace("tb", "")[0]) + lstTabela.SelectedItem.ToString().Replace("tb", "").Substring(1);

            SqlConnection myconection = new SqlConnection(conn);

            SqlCommand cmd = new SqlCommand("Select * from " + lstTabela.SelectedItem, myconection);

            DataTable dt = new DataTable();
            SqlDataAdapter myDa = new SqlDataAdapter(cmd);

            myDa.Fill(dt);
            StringBuilder sb = new StringBuilder();
            //spc
            sb.AppendLine("create procedure spc_" + strNomeClasse + " ()");
            sb.AppendLine("select ");
            int numcol = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (numcol == 0)
                    sb.AppendLine("" + col + "");
                else
                    sb.AppendLine("," + col + "");
                numcol++;
            }
            sb.AppendLine("from tb" + strNomeClasse.ToLower ());
            //spi
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("create procedure spi_" + strNomeClasse + " (");
            numcol = 0;
            
            foreach (DataColumn col in dt.Columns)
            {
                if (numcol != 0)
                    sb.AppendLine("v_" + col + " " + dt.Columns["" + col + ""].DataType.FullName.Replace("System.", "").Replace("String", "Varchar()").Replace("Int32", "int") + ",");
                numcol++;
            }
            sb.AppendLine(")");
            numcol = 0;
            sb.AppendLine("insert into tb" + strNomeClasse.ToLower() + "(");
            foreach (DataColumn col in dt.Columns)
            {
                if (numcol != 0)
                    sb.AppendLine("" + col + ",");
                numcol++;
            }
            sb.AppendLine(")values(");
            numcol = 0;
            foreach (DataColumn col in dt.Columns)
            {
                if (numcol != 0)
                    sb.AppendLine("v_" + col + ",");
                numcol++;
            }
            sb.AppendLine(")");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("create procedure spa_" + strNomeClasse + " (");
            numcol = 0;

            foreach (DataColumn col in dt.Columns)
            {
                    sb.AppendLine("v_" + col + " " + dt.Columns["" + col + ""].DataType.FullName.Replace("System.", "").Replace("String", "Varchar()").Replace("Int32", "int") + "");
            }
            sb.AppendLine(")");
            sb.AppendLine("update tb" + strNomeClasse.ToLower() + " Set ");
            foreach (DataColumn col in dt.Columns)
            {
                if (numcol != 0)
                    sb.AppendLine(col + "=v_" + col + ",");
                numcol++;
            }
            sb.AppendLine("where " + dt.Columns[0].ToString() + "=v_" + dt.Columns[0].ToString());
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("create procedure spe_" + strNomeClasse + " (");
            sb.AppendLine ("v_" + dt.Columns[0].ToString()+"");
            sb.AppendLine(")");
            sb.AppendLine("delete from tb" + strNomeClasse.ToLower());
            sb.AppendLine("where " + dt.Columns[0].ToString() + "=v_" + dt.Columns[0].ToString());
            txtProcedure.Text = sb.ToString();


        }
        void Bll()
        {
            try
            {
                string conn = txtBanco.Text;
                string strNomeClasse = char.ToUpper(lstTabela.SelectedItem.ToString().Replace("tb", "")[0]) + lstTabela.SelectedItem.ToString().Replace("tb", "").Substring(1);

                SqlConnection myconection = new SqlConnection(conn);

                SqlCommand cmd = new SqlCommand("Select * from " + lstTabela.SelectedItem, myconection);

                DataTable dt = new DataTable();
                SqlDataAdapter myDa = new SqlDataAdapter(cmd);

                myDa.Fill(dt);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Linq;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine("using System.Threading.Tasks;");
                sb.AppendLine("using System.Data;");
                sb.AppendLine("using System.Data.Entity;");
                sb.AppendLine("using GerenciadorPortal.Dal;");
                sb.AppendLine("using GerenciadorPortal.Entidade;");
                sb.AppendLine("namespace GerenciadorPortal.Bll");
                sb.AppendLine("{");
                sb.AppendLine("public  class Bll" + strNomeClasse + "");
                sb.AppendLine("{");
                sb.AppendLine("Dal" + strNomeClasse + " obj" + strNomeClasse + " = new Dal" + strNomeClasse + "();");
                sb.AppendLine("public DataTable Busca" + strNomeClasse + "(Entidade" + strNomeClasse + " objEntidade" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("DataTable dt" + strNomeClasse + " = new DataTable();");
                sb.AppendLine("dt" + strNomeClasse + " = obj" + strNomeClasse + ".Busca" + strNomeClasse + "(objEntidade" + strNomeClasse + ");");
                sb.AppendLine("return dt" + strNomeClasse + ";");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro: '+ erro.Message );").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("public void Inclui" + strNomeClasse + "(Entidade" + strNomeClasse + " objEntidade" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("obj" + strNomeClasse + ".Inclui" + strNomeClasse + "(objEntidade" + strNomeClasse + ");");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro: '+ erro.Message );").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("public void Atualiza" + strNomeClasse + "(Entidade" + strNomeClasse + " objEntidade" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("obj" + strNomeClasse + ".Atualiza" + strNomeClasse + "(objEntidade" + strNomeClasse + ");");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro: '+erro.Message);").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("public void Exclui" + strNomeClasse + "(Entidade" + strNomeClasse + " objEntidade" + strNomeClasse + ")");
                sb.AppendLine("{");
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("obj" + strNomeClasse + ".Exclui" + strNomeClasse + "(objEntidade" + strNomeClasse + ");");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception erro)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception ('Erro: '+ erro.Message );").Replace("'", "\"");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("}");
                txtCampos.Text = sb.ToString();
            }
            catch (Exception erro)
            {

                throw new Exception("Erro: " + erro.Message);
            }

        }
        void PreencherList()
        {
            try
            {
                string conn = txtBanco.Text;
                //SqlConnection myconection = new SqlConnection(conn);
                SqlConnection myconection = new SqlConnection (conn);
                SqlCommand cmd = new SqlCommand("SELECT * FROM SYSOBJECTS WHERE XTYPE='U' ", myconection);

                //SqlCommand cmd = new SqlCommand("select TABLE_NAME from  INFORMATION_SCHEMA.TABLES dbgerenciadorportal " +
                //  "where TABLE_TYPE='BASE TABLE';", myconection);

                DataTable dt = new DataTable();
                SqlDataAdapter myDa = new SqlDataAdapter(cmd);

                myDa.Fill(dt);

                foreach (DataRow row in dt.AsEnumerable())
                {
                    //lstTabela.Items.Add(row["TABLE_NAME"]);
                    lstTabela.Items.Add(row["name"]);
                }


            }
            catch (Exception erro)
            {

                throw new Exception("Erro: " + erro.Message);
            }
        }

        private void rdbDal_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
