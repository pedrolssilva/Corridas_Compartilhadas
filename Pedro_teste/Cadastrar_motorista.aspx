<%@ Page Title="Cadastro de motoristas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar_motorista.aspx.cs" Inherits="Pedro_teste.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <div id="div_cadastro_motorista" class="form-group container text-center" style="padding: 20px;">   
        <div>
            <h1>Cadastro de motoristas:</h1>
        </div>
        <div>
             <asp:Label runat="server" id="label_msg" CssClass="mensagem"></asp:Label>                
        </div>
        <hr />
        <div>
            <asp:TextBox runat="server" id="input_nome" type="text" CssClass="container  form-control" placeholder="Nome completo"/>
        </div>
        <div>
            <asp:TextBox runat="server" id="input_data" type="date" CssClass="container form-control"/>
        </div>
        <div>
            <asp:TextBox runat="server" id="input_cpf" type="text" class="container form-control" placeholder="CPF"/>
        </div>
        <div>
            <asp:TextBox runat="server" id="input_modelo_carro" type="text" class="container form-control" placeholder="Modelo do carro"/>
        </div>
        <div>
            <asp:TextBox runat="server" id="input_status" type="text" class="container form-control" placeholder="Status (ativo ou inativo)"/>
        </div>
        <div>
            <asp:TextBox runat="server" id="input_sexo" type="text" class="container form-control" placeholder="sexo: 'm' ou 'f'"/>
        </div> 
        <br />
        <asp:Button Text="Cadastrar motorista" runat="server" ID="button_cadastrar_motorista" CssClass="btn btn-primary" OnClick="button_cadastrar_motorista_click"/>
        <asp:Button Text="Consultar motorista" runat="server" id="button_consultar_motoristas" CssClass="btn btn-primary" OnClick="button_consultar_motorista_click"/>
    </div>    
</asp:Content>    