<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasketPage.aspx.cs" Inherits="MaetsStore.BasketPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="\Content\Main.css" />
    <asp:ListView ID="StoreList" runat="server"
        DataKeyNames="GameId" GroupItemCount="2"
        ItemType="MaetsStore.Classes.Game" SelectMethod="LoadBasket">
        <EmptyDataTemplate>
            <br />
            <td runat="server">You seem to not have any games in your basket right now... </td>
        </EmptyDataTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td class="catalogTd">
                <%--                        id="groupPlaceholderContainer"--%>
                <table runat="server">
                    <tr runat="server">
                        <td>
                            <br />
                            <%--                                    <a href="GameDetails.aspx?GameId=<%#:Item.GameId%>">--%>
                            <a href="CleanPage.aspx?GameId=<%#:Item.GameId%>">
                                <img src='<%#: @"\Images\" + Item.GameImagePath %>' class="catalogImg" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--                                    <a href="GameDetails.aspx?GameId=<%#:Item.GameId%>" runat="server">--%>
                            <a href="CleanPage.aspx?GameId=<%#:Item.GameId%>">
                                <div class="catalogText" runat="server">
                                    <span>
                                        <b class="catalogText"><%#:Item.GameName%></b>
                                    </span>
                                </div>
                            </a>
                            <span>
                                <b>Price: </b><%#:String.Format("{0:c}", Item.GamePrice)%>
                            </span>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </p>
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="groupPlaceholderContainer" runat="server" class="tableClass">
                <tr id="groupPlaceholder"></tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>

            <div class="fullLabel">
                <asp:Label runat="server" CssClass="totalAmountNumber">Total:</asp:Label>
                <asp:Label runat="server" ID="TotalNumber" CssClass="totalAmountText"></asp:Label>
                <br />
                <asp:Button runat="server" ID="BtnFinishPurchase" Text="Checkout" OnClick="BtnFinishPurchase_Click" />
            </div>

</asp:Content>
