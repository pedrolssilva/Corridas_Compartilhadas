using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pedro_teste.Models;
using System.Data.SqlClient;

namespace Pedro_teste.Views.Passageiro
{
    public partial class Consultar_passageiros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                label_msg.Text = "";
                List<Passenger> passageiros = new List<Passenger>();
                // Cria e abre a conexão com o banco de dados
                try
                {
                    using (SqlConnection conn = Sql.OpenConnection())
                    {
                        // Cria um comando para selecionar registros da tabela
                        using (SqlCommand cmd = new SqlCommand("SELECT id_passageiro, nm_passageiro, dt_nasc_passageiro, cpf_passageiro, sexo_passageiro FROM tb_passageiro ORDER BY nm_passageiro ASC;", conn))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (!reader.HasRows)
                                {
                                    label_msg.Text = "Não há passageiros ainda...";
                                    return;
                                }
                                //Obtém os registros, um por vez
                                while (reader.Read() == true)
                                {
                                    Passenger p = new Passenger();
                                    p.id_passageiro = reader.GetInt32(0);
                                    p.nm_passageiro = reader.GetString(1);                                    
                                    p.dt_nasc_passageiro = String.Format("{0:dd/MM/yyyy}", reader.GetDateTime(2));
                                    p.cpf_passageiro = reader.GetDecimal(3);
                                    p.sexo_passageiro = Convert.ToChar(reader.GetString(4));

                                    passageiros.Add(p);
                                }
                            }
                        }
                    }

                    listRepeater.DataSource = passageiros; //Origem dos dados
                    listRepeater.DataBind();    //cria os elementos a serem exibidos
                }
                catch (Exception ex)
                {
                    label_msg.Text = $"Não foi possivel acessar os dados. Erro: {ex.Message}";
                }
            }

        }

        protected void button_atualizar_consulta_passageiros_click(object sender, EventArgs e)
        {
            label_msg.Text = "";
            List<Passenger> passageiros = new List<Passenger>();
            // Cria e abre a conexão com o banco de dados
            try
            {
                using (SqlConnection conn = Sql.OpenConnection())
                {
                    // Cria um comando para selecionar registros da tabela
                    using (SqlCommand cmd = new SqlCommand("SELECT id_passageiro, nm_passageiro, dt_nasc_passageiro, cpf_passageiro, sexo_passageiro FROM tb_passageiro ORDER BY nm_passageiro ASC;", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                label_msg.Text = "Não há passageiros ainda...";
                                return;
                            }
                            //Obtém os registros, um por vez
                            while (reader.Read() == true)
                            {
                                Passenger p = new Passenger();
                                p.id_passageiro = reader.GetInt32(0);
                                p.nm_passageiro = reader.GetString(1);                                     
                                p.dt_nasc_passageiro = String.Format("{0:dd/MM/yyyy}", reader.GetDateTime(2));
                                p.cpf_passageiro = reader.GetDecimal(3);
                                p.sexo_passageiro = Convert.ToChar(reader.GetString(4));

                                passageiros.Add(p);
                            }
                        }
                    }
                }

                listRepeater.DataSource = passageiros; //Origem dos dados
                listRepeater.DataBind();    //cria os elementos a serem exibidos
            }
            catch (Exception ex)
            {
                label_msg.Text = $"Não foi possivel acessar os dados. Erro: {ex.Message}";
            }
        }
    }
}