<%@ Page Title="Cadastro de passageiros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar_passageiro.aspx.cs" Inherits="Pedro_teste.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div id="div_cadastro_passageiro" class="form-group container text-center" style="padding: 20px;">   
        <div>
            <h1>Cadastro de passageiros:</h1>
        </div>
        <div>
             <asp:Label runat="server" id="label_msg" CssClass="mensagem"></asp:Label>                
        </div>
        <hr />
        <div class="form-group row">
            <asp:TextBox runat="server" id="input_nome" type="text" CssClass="container  form-control" placeholder="Nome completo"/>
        </div>
        <div class="form-group row">
            <asp:TextBox runat="server" id="input_data" type="date" CssClass="container form-control"/>
        </div>
        <div class="form-group row">
            <asp:TextBox runat="server" id="input_cpf" type="text" class="container form-control" placeholder="CPF"/>
        </div>         
        <div class="form-group row">
            <asp:TextBox runat="server" id="input_sexo" type="text" class="container form-control" placeholder="sexo: 'm' ou 'f'"/>
        </div> 
        <br />
        <asp:Button Text="Cadastrar passageiro" runat="server" ID="button_cadastrar_passageiro" CssClass="btn btn-primary" OnClick="button_cadastrar_passageiro_click"/>           
    </div>    
</asp:Content>
