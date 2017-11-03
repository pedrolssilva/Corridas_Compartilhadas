using System;
using System.Data.SqlClient;
using Pedro_teste.Models;

namespace Pedro_teste.Views.Motorista
{
    public partial class Atualizar_status_motorista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id) == false)
                {
                    label_msg.Text = "Id inválido!";
                    return;
                }

                try
                {
                    // Cria e abre a conexão com o banco de dados
                    using (SqlConnection conn = Sql.OpenConnection())
                    {

                        // Cria um comando para selecionar registros da tabela
                        using (SqlCommand cmd = new SqlCommand("SELECT nm_motorista, dt_nasc_motorista, cpf_motorista, modelo_carro_motorista, status_motorista, sexo_motorista FROM tb_motorista WHERE id_motorista = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // Tenta obter o registro
                                if (reader.Read() == true)
                                {
                                    input_nome.Text = reader.GetString(0);
                                    input_data.Text = String.Format("{0:dd/MM/yyyy}", reader.GetDateTime(1));
                                    input_cpf.Text = reader.GetDecimal(2).ToString();
                                    input_modelo_carro.Text = reader.GetString(3);
                                    if (reader.GetInt16(4) == 0)
                                    {
                                        input_status.Text = "inativo";
                                    }
                                    else
                                    {
                                        input_status.Text = "ativo";
                                    }
                                    input_sexo.Text = Convert.ToChar(reader.GetString(5)).ToString();

                                }
                                else
                                {
                                    label_msg.Text = "Id não encontrado!";
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    label_msg.Text = $"Não foi possivel acessar os dados. Erro: {ex.Message}";
                }
            }

        }

        protected void button_atualizar_status_click(object sender, EventArgs e)
        {
            label_msg.Text = "";
            label_msg.ForeColor = System.Drawing.Color.Empty;

            int id;
            if (int.TryParse(Request.QueryString["id"], out id) == false)
            {
                label_msg.Text = "Id inválido!";
                return;
            }

            //valida status:
            decimal status;
            if (string.IsNullOrWhiteSpace(input_status.Text))
            {
                label_msg.Text = "Status vazio!";
                return;
            }
            else if (!input_status.Text.ToLower().Trim().Equals("ativo") && !input_status.Text.ToLower().Trim().Equals("inativo"))
            {
                label_msg.Text = "Status diferente de 'ativo' ou 'inativo'";
                return;
            }
            else
            {
                if (input_status.Text.ToLower().Trim().Equals("ativo"))
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
            }

            //Atualiza o status:
            try
            {
                // Cria e abre a conexão com o banco de dados
                using (SqlConnection conn = Sql.OpenConnection())
                {

                    // Cria um comando para atualizar um registro da tabela
                    using (SqlCommand cmd = new SqlCommand("UPDATE tb_motorista SET status_motorista = @status WHERE id_motorista = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
                label_msg.ForeColor = System.Drawing.Color.Blue;
                label_msg.Text = "Status alterado com sucesso!";

            }
            catch (Exception ex)
            {
                label_msg.Text = $"Não foi possivel inserir os dados. Erro: {ex.Message}";
                return;
            }
        }

        protected void button_voltar_click(object senser, EventArgs e)
        {
            Response.Redirect("Consultar_motoristas.aspx");
        }
    }
}