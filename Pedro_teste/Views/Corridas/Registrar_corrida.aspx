<%@ Page Title="Registrar corrida" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar_corrida.aspx.cs" Inherits="Pedro_teste.Registrar_corrida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="div_registrar_corrida" class="form-group container text-center" style="padding: 20px;">   
        <div>
            <h1>Registrar corridas:</h1>
        </div>
        <div>
             <asp:Label runat="server" id="label_msg" CssClass="mensagem"></asp:Label>                
        </div>
        <hr />
        <div>
            <asp:TextBox runat="server" id="input_nome_motorista" type="text" CssClass="container  form-control" placeholder="Nome completo do motorista"/>
        </div>
         <div>
            <asp:TextBox runat="server" id="input_nome_passageiro" type="text" CssClass="container  form-control" placeholder="Nome completo do passageiro"/>
        </div> 
         <div>
            <asp:TextBox runat="server" id="input_valor" type="text" CssClass="container  form-control" placeholder="Valor da corrida (0000,00)"/>
        </div> 
        <br />
        <asp:Button Text="Registar a corrida" runat="server" ID="button_registrar_corrida" CssClass="btn btn-primary" OnClick="button_registrar_corrida_click"/>           
    </div>
</asp:Content>
