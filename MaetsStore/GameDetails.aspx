<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="GameDetails.aspx.cs" Inherits="MaetsStore.store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="GameDetail" runat="server" ItemType="MaetsStore.Classes.Game" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.GameId %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%# Item.GameImagePath %>"class="imageStyle" alt="<%#:Item.GameName%>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td class="tdStyle">
                        <b>Description:</b><br /><%#:Item.GameDesc %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.GamePrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.GameId %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
