<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="labwork3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 136px;
        }
        .auto-style3 {
            width: 136px;
            height: 67px;
        }
        .auto-style4 {
            height: 67px;
        }
        .auto-style7 {
            width: 136px;
            height: 50px;
        }
        .auto-style8 {
            height: 50px;
        }
        .auto-style9 {
            width: 136px;
            height: 54px;
        }
        .auto-style10 {
            height: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; username: </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="username_textbox" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; password:</td>
                    <td class="auto-style10">
                        <input id="password_textbox" runat="server" type="password"/></td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="login_button" runat="server" Height="31px" OnClick="LoginButton_Click" Text="Login" Width="167px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
