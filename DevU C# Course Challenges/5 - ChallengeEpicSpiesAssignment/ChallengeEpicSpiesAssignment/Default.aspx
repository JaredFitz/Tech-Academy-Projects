<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeEpicSpiesAssignment.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="190px" ImageUrl="epic-spies-logo.jpg" />
            <br />
            <br />
            <h1><span class="auto-style1">Spy New Assignment Form</span></h1>
            Spy Code Name:
            <asp:TextBox ID="spyNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            New Assignment Name:
            <asp:TextBox ID="assignmentNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            End Date of Previous Assignment:<asp:Calendar ID="oldAssignmentEndCalendar" runat="server" OnSelectionChanged="oldAssignmentEndCalendar_SelectionChanged"></asp:Calendar>
            <br />
            <br />
            Start Date of New Assignment:<asp:Calendar ID="newAssignmentStartCalendar" runat="server" OnSelectionChanged="newAssignmentStartCalendar_SelectionChanged"></asp:Calendar>
            <br />
            <br />
            Projected End Date of New Assignment:<asp:Calendar ID="newAssignmentEndCalendar" runat="server" OnSelectionChanged="newAssignmentEndCalendar_SelectionChanged"></asp:Calendar>
            <br />
            <br />
            <asp:Button ID="assignButton" runat="server" OnClick="assignButton_Click" Text="Assign Spy" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
