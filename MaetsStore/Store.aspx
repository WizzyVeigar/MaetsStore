<%@ Page Title="Store" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Store.aspx.cs" Inherits="MaetsStore.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="\Content\Main.css" />
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="StoreList" runat="server"
                DataKeyNames="GameId" GroupItemCount="4"
                ItemType="MaetsStore.Classes.Game" SelectMethod="GetGames">
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
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
                                    <a href="GameDetails.aspx?GameId=<%#:Item.GameId%>">
                                        <img src='<%#: @"\Images\" + Item.GameImagePath %>' class="catalogImg" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="GameDetails.aspx?GameId=<%#:Item.GameId%>" runat="server">
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
        </div>
    </section>
</asp:Content>
