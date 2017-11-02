﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultar_passageiros.aspx.cs" Inherits="Pedro_teste.Views.Passageiro.Consultar_passageiros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <hr />
        <div>
            <asp:Label runat="server" ID="label_msg" CssClass="mensagem"></asp:Label>
        </div>
        <asp:Button Text="Atualizar" runat="server" ID="button_atualizar_consulta_passageiros" CssClass="btn btn-primary" OnClick="button_atualizar_consulta_passageiros_click" />
        <br />
        <table class="table table-striped table-dark">
            <caption class="container"><h3>Consulta de passageiros:</h3></caption>
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Data nascimento</th>
                    <th>CPF</th>
                    <th>Sexo</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="listRepeater">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("nm_passageiro") %></td>
                            <td><%#Eval("dt_nasc_passageiro") %></td>
                            <td><%#Eval("cpf_passageiro") %></td>
                            <td><%#Eval("sexo_passageiro") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>