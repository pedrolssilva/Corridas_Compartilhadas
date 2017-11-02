using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pedro_teste.Models;
using System.Data.SqlClient;
using System.Globalization;

namespace Pedro_teste
{
    public partial class Registrar_corrida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_registrar_corrida_click(object sender, EventArgs e)
        {
            label_msg.Text = "";
            label_msg.ForeColor = System.Drawing.Color.Empty;

            //Validando nome do motorista:
            if (string.IsNullOrWhiteSpace(input_nome_motorista.Text))
            {
                label_msg.Text = "Campo de nome do motorista vazio!";
                return;
            }

            //Validando nome do passageiro:
            if (string.IsNullOrWhiteSpace(input_nome_passageiro.Text))
            {
                label_msg.Text = "Campo de nome do passageiro vazio!";
                return;
            }

            //Verifica valor da corrida:
            float valor;
            if (string.IsNullOrWhiteSpace(input_valor.Text) || float.TryParse(input_valor.Text, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("pt-br"), out valor) == false)
            {
                label_msg.Text = "Campo valor inválido. Tente no formato: 0000,00";
                return;
            }


            int id_motorista;
            int id_passageiro;

            //Consulta do id e validação do motorista:
            try
            {
                using (SqlConnection conn = Sql.OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("select id_motorista from tb_motorista where nm_motorista = @nome and status_motorista = 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", input_nome_motorista.Text.Trim().ToLower());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                id_motorista = reader.GetInt32(0);
                            }
                            else
                            {
                                label_msg.Text = "Motorista inválido ou inativo.";
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                label_msg.Text = $"Erro ao inserir os dados: {ex.Message}";
                return;
            }

            //Consulta do id do passageiro:
            try
            {
                using (SqlConnection conn = Sql.OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("select id_passageiro from tb_passageiro where nm_passageiro = @nome;", conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", input_nome_passageiro.Text.Trim().ToLower());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                id_passageiro = reader.GetInt32(0);
                            }
                            else
                            {
                                label_msg.Text = "Passageiro não encontrado.";
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                label_msg.Text = $"Erro ao inserir os dados: {ex.Message}";
                return;
            }

            //Insere o registro de corrida:
            try
            {
                //insere valores na base de dados:
                using (SqlConnection conn = Sql.OpenConnection())
                {
                    // Cria um comando para inserir um novo registro à tabela
                    using (SqlCommand cmd = new SqlCommand("insert into tb_corridas (tb_passageiro_id_passageiro, tb_motorista_id_motorista, vl_corrida) values(@id_passageiro, @id_motorista, @vl_total);", conn))
                    {
                        // Esses valores poderiam vir de qualquer outro lugar, como uma TextBox...
                        cmd.Parameters.AddWithValue("@id_motorista", id_motorista);
                        cmd.Parameters.AddWithValue("@id_passageiro", id_passageiro);                         
                        cmd.Parameters.AddWithValue("@vl_total", valor);

                        cmd.ExecuteNonQuery();
                        label_msg.ForeColor = System.Drawing.Color.Blue;
                        label_msg.Text = "Dados inseridos com sucesso.";
                    }
                }
            }
            catch (SqlException ex)
            {
                label_msg.Text = $"Erro ao inserir os dados: {ex.Message}";
                     
            }      
        }
    }
}