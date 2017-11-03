using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pedro_teste.Models;
using System.Data.SqlClient;

namespace Pedro_teste
{
    public partial class Consultar_corridas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                label_msg.Text = "";
                List<Run> corridas = new List<Run>();
                // Cria e abre a conexão com o banco de dados
                try
                {
                    using (SqlConnection conn = Sql.OpenConnection())
                    {
                        // Cria um comando para selecionar registros da tabela
                        using (SqlCommand cmd = new SqlCommand("SELECT m.nm_motorista, p.nm_passageiro, c.vl_corrida FROM tb_corridas AS c JOIN tb_motorista AS m ON(c.tb_motorista_id_motorista = m.id_motorista) JOIN tb_passageiro AS p ON(c.tb_passageiro_id_passageiro = p.id_passageiro) ORDER BY m.nm_motorista ASC; ", conn))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (!reader.HasRows)
                                {
                                    label_msg.Text = "Não há corridas ainda...";
                                    return;
                                }
                                //Obtém os registros, um por vez
                                while (reader.Read() == true)
                                {
                                    Run c = new Run();
                                    c.nm_motorista = reader.GetString(0);
                                    c.nm_passageiro = reader.GetString(1);
                                    c.vl_corrida = ("R$ " + reader.GetDecimal(2).ToString());

                                    corridas.Add(c);
                                }
                            }
                        }
                    }

                    listRepeater.DataSource = corridas; //Origem dos dados
                    listRepeater.DataBind();    //cria os elementos a serem exibidos
                }
                catch (Exception ex)
                {
                    label_msg.Text = $"Não foi possivel acessar os dados. Erro: {ex.Message}";
                }
            }
        }

        protected void button_atualizar_consulta_corridas_click(object sender, EventArgs e)
        {
            label_msg.Text = "";
            List<Run> corridas = new List<Run>();
            // Cria e abre a conexão com o banco de dados
            try
            {
                using (SqlConnection conn = Sql.OpenConnection())
                {
                    // Cria um comando para selecionar registros da tabela
                    using (SqlCommand cmd = new SqlCommand("SELECT m.nm_motorista, p.nm_passageiro, c.vl_corrida FROM tb_corridas AS c JOIN tb_motorista AS m ON(c.tb_motorista_id_motorista = m.id_motorista) JOIN tb_passageiro AS p ON(c.tb_passageiro_id_passageiro = p.id_passageiro) ORDER BY m.nm_motorista ASC; ", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                label_msg.Text = "Não há corridas ainda...";
                                return;
                            }
                            //Obtém os registros, um por vez
                            while (reader.Read() == true)
                            {
                                Run c = new Run();
                                c.nm_motorista = reader.GetString(0);
                                c.nm_passageiro = reader.GetString(1);
                                c.vl_corrida = ("R$ " + reader.GetDecimal(2).ToString());

                                corridas.Add(c);
                            }
                        }
                    }
                }

                listRepeater.DataSource = corridas; //Origem dos dados
                listRepeater.DataBind();    //cria os elementos a serem exibidos
            }
            catch (Exception ex)
            {
                label_msg.Text = $"Não foi possivel acessar os dados. Erro: {ex.Message}";
            }
        }
    }
}