<%@ Page Title="Registrar corrida" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar_corrida.aspx.cs" Inherits="Pedro_teste.Registrar_corrida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_registrar_corrida" class="form-group container text-center" style="padding: 20px;">   
        <div>
            <h1>Registrar corrida:</h1>
        </div>
        <div>
             <label id="label_msg"></label>
        </div>
        <div>                                                                                                                                                         
            <input id="input_nome_motorista" type="text" class="container" placeholder="Nome completo do motorista">
        </div>
        <div>
            <input id="input_nome_passageiro" type="text" class="container" placeholder="Nome completo do passageiro">
        </div>            
        <button id="button_cadastrar_motorista">Registrar corrida</button>          
    </div>
</asp:Content>
