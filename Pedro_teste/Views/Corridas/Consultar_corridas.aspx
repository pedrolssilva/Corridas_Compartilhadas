<%@ Page Title="Consultar corridas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultar_corridas.aspx.cs" Inherits="Pedro_teste.Consultar_corridas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <hr />
        <div>              
            <asp:Label runat="server" ID="label_msg" CssClass="mensagem"></asp:Label>
        </div>
         <hr />
        <asp:Button Text="Atualizar" runat="server" ID="button_atualizar_consulta_corridas" CssClass="btn btn-primary" OnClick="button_atualizar_consulta_corridas_click" />
        <br />
        <table class="table table-striped table-dark">
            <caption class="container"><h3>Consulta de corridas:</h3></caption>
            <thead>
                <tr>
                    <th>Nome motorista</th>
                    <th>Nome passageiro</th>
                    <th>Valor da corrida</th>           
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="listRepeater">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("nm_motorista") %></td>
                            <td><%#Eval("nm_passageiro") %></td>
                            <td><%#Eval("vl_corrida") %></td>                              
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
