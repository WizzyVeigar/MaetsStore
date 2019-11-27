<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CleanPage.aspx.cs" Inherits="MaetsStore.CleanPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="\Content\Main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="GameDetails" runat="server" ItemType="MaetsStore.Classes.Game" SelectMethod="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <br />
                <h1><%#:Item.GameId %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src='<%#: @"\Images\" + Item.GameImagePath %>' class="imageStyle" alt="<%#:Item.GameName%>" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td class="tdStyle">
                        <b>Description:</b><br />
                        <%#:Item.GameDesc %>
                        <br />
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.GamePrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.GameId %></span>
                        <br />
                        <asp:Button runat="server" OnClick="AddProductToBasket" Text="Add to Basket" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
