using System;  
using System.Data.SqlClient;   
using System.Text.RegularExpressions; 
using System.Web.UI;
using Pedro_teste.Models;

namespace Pedro_teste
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   

        }

        protected void button_cadastrar_motorista_click(object sender, EventArgs e)
        {
            label_msg.Text = "";
            label_msg.ForeColor = System.Drawing.Color.Empty;

            //Validando campo nome:
            if (string.IsNullOrWhiteSpace(input_nome.Text))
            {                  
                label_msg.Text = "Campo de nome vazio!";
                return;
            }
            else if (!input_nome.Text.Trim().Contains(" "))
            {
                label_msg.Text = "Insira o nome completo!";
                return;
            }

            //Validando campo data:
            DateTime data;
            if (DateTime.TryParse(input_data.Text, System.Globalization.CultureInfo.GetCultureInfo("pt-br"), System.Globalization.DateTimeStyles.None, out data) == false)
            {
                label_msg.Text = "data de nascimento inválida!";
                return;
            }

            //Valida CPF:           
            Regex regexCPF = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$");
            if (!regexCPF.IsMatch(input_cpf.Text))
            {
                label_msg.Text = "CPF inválido tente desta forma: 000.000.000-00";
                return;
            }
            decimal cpf = Convert.ToDecimal(input_cpf.Text.Trim().Replace(".", "").Replace("-", ""));

            //Validando modelo do carro:
            if (string.IsNullOrWhiteSpace(input_modelo_carro.Text))
            {
                label_msg.Text = "modelo do carro vazio!";
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

            //valida sexo:
            //Verifica ativo:
            if (string.IsNullOrWhiteSpace(input_sexo.Text) || input_sexo.Text.Length > 1)
            {
                label_msg.Text = "Sexo vazio ou maior que 1";
                return;
            }

            char sexo = input_sexo.Text.ToLower().Trim()[0];
            if (sexo != 'f' && sexo != 'm')
            {
                label_msg.Text = "Campo sexo diferente de 'f' e 'm'.";
                return;
            }

            //insere dados do motorista na base de dados:
            // Cria e abre a conexão com o banco de dados
            try
            {
                using (SqlConnection conn = Sql.OpenConnection())
                {

                    // Cria um comando para inserir um novo registro à tabela
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_motorista (nm_motorista, dt_nasc_motorista, cpf_motorista, modelo_carro_motorista, status_motorista, sexo_motorista) VALUES (@nome, @dt_nasc_motorista, @cpf_motorista, @modelo_carro_motorista, @status_motorista, @sexo_motorista)", conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", input_nome.Text.Trim().ToLower());
                        cmd.Parameters.AddWithValue("@dt_nasc_motorista", data);
                        cmd.Parameters.AddWithValue("@cpf_motorista", cpf);
                        cmd.Parameters.AddWithValue("@modelo_carro_motorista", input_modelo_carro.Text.Trim().ToLower());
                        cmd.Parameters.AddWithValue("@status_motorista", status);
                        cmd.Parameters.AddWithValue("@sexo_motorista", sexo);

                        cmd.ExecuteNonQuery();
                        label_msg.ForeColor = System.Drawing.Color.Blue;
                        label_msg.Text = "Motorista cadastrado.";
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601)
                {
                    label_msg.Text = "CPF DUPLICADO, ja existe um motorista com esse CPF.";
                }
                else
                {
                    label_msg.Text = $"Não foi possivel inserir os dados. Erro: {ex.Message}";
                }

            }

        }            
    }
}