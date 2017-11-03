<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Atualizar_status_motorista.aspx.cs" Inherits="Pedro_teste.Views.Motorista.Atualizar_status_motorista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_atualizar_status" class="form-group container text-center" style="padding: 20px;">
        <div>
            <h1>Atualizar status:</h1>
        </div>
        <div>
            <asp:Label runat="server" ID="label_msg" CssClass="mensagem"></asp:Label>
        </div>
        <hr />
        <div class="form-group row">             
            <label for="input_nome" class="col-form-label">Nome:</label>             
            <asp:TextBox runat="server" ID="input_nome" type="text" CssClass="container form-control text-center" placeholder="Nome completo" ReadOnly="true" />                  
        </div>
        <div class="form-group row">
            <label for="input_data" class="col-form-label">Data de nascimento:</label>  
            <asp:TextBox runat="server" ID="input_data" type="text" CssClass="container form-control text-center" ReadOnly="true" />
        </div>
        <div class="form-group row">
            <label for="input_cpf" class="col-form-label">CPF:</label> 
            <asp:TextBox runat="server" ID="input_cpf" type="text" class="container form-control text-center" placeholder="CPF" ReadOnly="true" />
        </div>
        <div class="form-group row">
            <label for="input_modelo_carro" class="col-form-label">Modelo do carro:</label> 
            <asp:TextBox runat="server" ID="input_modelo_carro" type="text" class="container form-control text-center" placeholder="Modelo do carro" ReadOnly="true" />
        </div>
        <div class="form-group row">
            <label for="input_status" class="col-form-label">Status:</label>
            <asp:TextBox runat="server" ID="input_status" type="text" class="container form-control text-center" placeholder="Status (ativo ou inativo)" />
        </div>
        <div class="form-group row">
             <label for="input_sexo" class="col-form-label">Sexo:</label>
            <asp:TextBox runat="server" ID="input_sexo" type="text" class="container form-control text-center" placeholder="sexo: 'm' ou 'f'" ReadOnly="true" />
        </div>
        <br />
        <asp:Button Text="Atualizar status" runat="server" ID="button_atualizar_status" CssClass="btn btn-primary" OnClick="button_atualizar_status_click" />
        <asp:Button Text="&laquo; voltar" runat="server" ID="button_voltar" CssClass="btn btn-primary" OnClick="button_voltar_click" />
    </div>
</asp:Content>
