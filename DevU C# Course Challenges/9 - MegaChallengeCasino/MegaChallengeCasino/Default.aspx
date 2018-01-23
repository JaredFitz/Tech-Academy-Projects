<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="firstSlotImage" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="secondSlotImage" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="thirdSlotImage" runat="server" Height="150px" Width="150px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull the Lever!" />
            &nbsp;
            <asp:Button ID="resetButton" runat="server" OnClick="resetButton_Click" Text="Reset Money" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry -&nbsp;&nbsp; <strong>x2</strong> Your Bet<br />
            2 Cherries - <strong>x3</strong> Your Bet<br />
            3 Cherries - <strong>x4</strong> Your Bet<br />
            3 7&#39;s - Jackpot - <strong>x100</strong> Your Bet<br />
            <br />
            HOWEVER ... if there&#39;s even one BAR you win nothing</div>
    </form>
</body>
</html>
