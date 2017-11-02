<%@ Page Title="Cadastro de passageiros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar_passageiro.aspx.cs" Inherits="Pedro_teste.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div id="div_cadastro_passageiro" class="form-group container text-center" style="padding: 20px;">   
        <div>
            <h1>Cadastro de passageiros:</h1>
        </div>
        <div>
             <label id="label_msg"></label>
        </div>
        <div>
            <input id="input_nome" type="text" class="container" placeholder="Nome completo">
        </div>
        <div>
            <input id="input_data" type="date" class="container form-control">
        </div>
        <div>
            <input id="input_cpf" type="text" class="container form-control" placeholder="CPF">
        </div>          
        <div>
            <input id="input_sexo" type="text" class="container form-control" placeholder="sexo">
        </div>
        <button id="button_cadastrar_motorista">Cadastrar passageiro</button>
        <button id="button_consultar_motoristas">Consultar passageiros</button>
    </div>
</asp:Content>
