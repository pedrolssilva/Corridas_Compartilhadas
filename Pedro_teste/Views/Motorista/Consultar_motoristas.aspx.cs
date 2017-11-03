using System;
using System.Collections.Generic; 
using Pedro_teste.Models;
using System.Data.SqlClient;

namespace Pedro_teste
{
    public partial class Consultar_motoristas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                label_msg.Text = "";
                List<Driver> motoristas = new List<Driver>();
                // Cria e abre a conexão com o banco de dados
                try
                {
                    using (SqlConnection conn = Sql.OpenConnection())
                    {
                        // Cria um comando para selecionar registros da tabela
                        using (SqlCommand cmd = new SqlCommand("SELECT id_motorista, nm_motorista, dt_nasc_motorista, cpf_motorista, modelo_carro_motorista, status_motorista, sexo_motorista FROM tb_motorista ORDER BY nm_motorista ASC;", conn))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (!reader.HasRows)
                                {
                                    label_msg.Text = "Não há motoristas ainda...";
                                    return;
                                }
                                //Obtém os registros, um por vez
                                while (reader.Read() == true)
                                {
                                    Driver d = new Driver();
                                    d.id_motorista = reader.GetInt32(0);
                                    d.nm_motorista = reader.GetString(1);
                                    d.dt_nasc_motorista = String.Format("{0:dd/MM/yyyy}", reader.GetDateTime(2));
                                    d.cpf_motorista = reader.GetDecimal(3);
                                    d.modelo_carro_motorista = reader.GetString(4);
                                    if (reader.GetInt16(5) == 0)
                                    {
                                        d.status_motorista = "inativo";
                                    }
                                    else
                                    {
                                        d.status_motorista = "ativo";
                                    }
                                    d.sexo_motorista = Convert.ToChar(reader.GetString(6));

                                    motoristas.Add(d);
                                }
                            }
                        }
                    }

                    listRepeater.DataSource = motoristas; //Origem dos dados
                    listRepeater.DataBind();    //cria os elementos a serem exibidos
                }
                catch (Exception ex)
                {
                    label_msg.Text = $"Não foi possivel acessar os dados. Erro: {ex.Message}";                   
                }
            }

        }

        protected void button_atualizar_consulta_motoristas_click(object sender, EventArgs e)
        {
            label_msg.Text = "";
            List<Driver> motoristas = new List<Driver>();
            // Cria e abre a conexão com o banco de dados
            try
            {
                using (SqlConnection conn = Sql.OpenConnection())
                {
                    // Cria um comando para selecionar registros da tabela
                    using (SqlCommand cmd = new SqlCommand("SELECT id_motorista, nm_motorista, dt_nasc_motorista, cpf_motorista, modelo_carro_motorista, status_motorista, sexo_motorista FROM tb_motorista ORDER BY nm_motorista ASC;", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                label_msg.Text = "Não há motoristas ainda...";
                                return;
                            }
                            //Obtém os registros, um por vez
                            while (reader.Read() == true)
                            {
                                Driver d = new Driver();
                                d.id_motorista = reader.GetInt32(0);
                                d.nm_motorista = reader.GetString(1);
                                d.dt_nasc_motorista = String.Format("{0:dd/MM/yyyy}", reader.GetDateTime(2));
                                d.cpf_motorista = reader.GetDecimal(3);
                                d.modelo_carro_motorista = reader.GetString(4);
                                if (reader.GetInt16(5) == 0)
                                {
                                    d.status_motorista = "inativo";
                                }
                                else
                                {
                                    d.status_motorista = "ativo";
                                }
                                d.sexo_motorista = Convert.ToChar(reader.GetString(6));

                                motoristas.Add(d);
                            }
                        }
                    }
                }

                listRepeater.DataSource = motoristas; //Origem dos dados
                listRepeater.DataBind();    //cria os elementos a serem exibidos
            }
            catch (Exception ex)
            {
                label_msg.Text = $"Não foi possivel acessar os dados. Erro: {ex.Message}";
            }
        }
    }


}