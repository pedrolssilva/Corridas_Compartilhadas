<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultar_motoristas.aspx.cs" Inherits="Pedro_teste.Consultar_motoristas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <hr />
        <div>
            <asp:Label runat="server" ID="label_msg" CssClass="mensagem"></asp:Label>
        </div>
        <hr />
        <asp:Button Text="Atualizar" runat="server" ID="button_atualizar_consulta_motoristas" CssClass="btn btn-primary" OnClick="button_atualizar_consulta_motoristas_click" />
        <br />
        <table class="table table-striped table-dark">
            <caption class="container">
                <h3>Consulta de motoristas:</h3>
            </caption>
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Data nascimento</th>
                    <th>CPF</th>
                    <th>Modelo carro</th>
                    <th>Status</th>
                    <th>Sexo</th>
                    <th></th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="listRepeater">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("nm_motorista") %></td>
                            <td><%#Eval("dt_nasc_motorista") %></td>
                            <td><%#Eval("cpf_motorista") %></td>
                            <td><%#Eval("modelo_carro_motorista") %></td>
                            <td><%#Eval("status_motorista") %></td>
                            <td><%#Eval("sexo_motorista") %></td>                              
                            <td><a href="Atualizar_status_motorista.aspx?id=<%#Eval("id_motorista") %>">Atualizar status</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
