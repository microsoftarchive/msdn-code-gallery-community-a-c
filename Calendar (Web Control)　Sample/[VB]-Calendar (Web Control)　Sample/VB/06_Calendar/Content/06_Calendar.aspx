<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="06_Calendar.aspx.vb" Inherits="_06_Calendar._06_Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Calendar Webコントロール　サンプル</title>
    <link href="../App_Themes/Calendar_CSS/Calendar_StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <header>Calendar Webコントロール　サンプル</header>

        <div class="divCalendar">
            <asp:Calendar ID="Calendar1" runat="server" SelectionMode="DayWeekMonth" SelectedDayStyle-BackColor="Red" 
                ShowGridLines="True">

            </asp:Calendar>
        </div> <!-- divCalendar -->

        <br />
        <asp:Label ID="Label1" runat="server" Text="選択された日付を表示"></asp:Label>


    </div>
    </form>
</body>
</html>
