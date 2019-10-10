<%@ Page Language="C#" Title="Login" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MaetsStore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="\Content\Main.css" />
</head>
<body>
    <form method="post" runat="server">
        <div class="imgcontainer">
            <img src="\Images\LeviathanWhaleBlade.png" alt="Avatar" class="avatar" />
        </div>
        <div class="container">
            <label for="uname"><b>Username</b></label>
            <input type="text" runat="server" placeholder="Enter Username" name="uname" id="unameId" required="required"/>

            <label for="psw"><b>Password</b></label>
            <input type="password" runat="server" placeholder="Enter Password" name="psw" id="pswId"  required="required"/>

            <asp:button runat="server" CssClass="Login"  onclick="Button_Submit" Text="Login"></asp:button>
            <label>
                <input type="checkbox" checked="checked" name="remember"/>
                Remember me
            </label>
        </div>

        <div class="container" >
            <button runat="server" class="cancelbtn" onclick="Button_CreateUser" >Create</button>
            <span class="psw">Forgot <a href="#">password?</a></span>
        </div>
    </form>
</body>
</html>
