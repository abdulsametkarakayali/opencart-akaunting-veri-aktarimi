<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server"><div class="container">

        <asp:Button ID="btnEsitle" runat="server"  OnClick="btnEsitle_Click" CssClass="btn btn-large" Text="Ürün Esitle" />
        <asp:Label ID="lblSonuc" runat="server" Text="Label"></asp:Label>
         <table class="table table-striped">
        <thead>
            <tr>
                <th>Adı</th>
               
                <th>Kod</th>
                <th>Adet</th>
                
                <th>Resim</th>     
                 
                
            </tr>
        </thead>
        <tbody>


             <asp:Repeater ID="rptMusteriler" runat="server" >
        <ItemTemplate>
             
             <tr>
                <td>   <%# Eval("Ad")%> </td>
                   
                  <td>   <%# Eval("Kod")%> </td>
                  <td>   <%# Eval("Adet")%> </td>
                
                 <td>  <img src="<%# Eval("Resim")%>" class="img-thumbnail float-right"  width="200" height="200"/> </td>
                               
            </tr>
            
        </ItemTemplate>
        
    </asp:Repeater>
           
             </tbody>
         
    </table>
        </div>
    </form>
</body>
</html>
