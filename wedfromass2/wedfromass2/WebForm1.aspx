<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="wedfromass2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:DropDownList runat="server" ID="dropdown"></asp:DropDownList>
            <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="submit_Click"></asp:Button>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId"
                OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
                OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Category Id" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("CategoryID") %>'></asp:Label>
                        </ItemTemplate>
                       
<ItemStyle Width="150px"></ItemStyle>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("Title") %>'></asp:TextBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Short Description" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblShortDescription" runat="server" Text='<%# Eval("ShortDescription") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtShortDescription" runat="server" Text='<%# Eval("ShortDescription") %>'></asp:TextBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Long Description" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblLongDescription" runat="server" Text='<%# Eval("LongDescription") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLongDescription" runat="server" Text='<%# Eval("LongDescription") %>'></asp:TextBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ImageUrl" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblImageUrln" runat="server" Text='<%# Eval("ImageUrl") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImageUrl" runat="server" Text='<%# Eval("ImageUrl") %>'></asp:TextBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />
                        </ItemTemplate>


                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <table border="1" style="border-collapse: collapse">
                <tr>
                    <td style="width: 150px">Category ID:<br />
                        <asp:DropDownList runat="server" ID="dropdowadd" Width="140" ></asp:DropDownList>
                    </td>
                   
                    <td style="width: 150px">Title:<br />
                        <asp:TextBox ID="txtaddTitle" runat="server" Width="140" />
                    </td>
                    
                    <td style="width: 150px">Short Description:<br />
                        <asp:TextBox ID="txtaddShortDescription" runat="server" Width="140" />
                    </td>
                   
                    <td style="width: 150px">Long Description:<br />
                        <asp:TextBox ID="TxtaddLongDescription" runat="server" Width="140" />
                    </td>
                    <td style="width: 150px">Image Url:<br />
                        <asp:TextBox ID="TxtappImageUrl" runat="server" Width="140" />
                    </td>
                    
                     <td style="width: 150px">Price:<br />
                        <asp:TextBox ID="TxtappPrice" runat="server" Width="140" />
                    </td>
                    <td style="width: 100px">
                        <asp:Button ID="btnAdd" CausesValidation="False" runat="server" Text="Add" OnClick="Insert" />
                    </td>
                </tr>
            </table>

             <asp:DropDownList runat="server" ID="dropdown2"></asp:DropDownList>
            <asp:Button runat="server" ID="ButtonDelete" Text="Delete" OnClick="ButtonDelete_Click"></asp:Button>
            <asp:Label ID="validation" runat="server" Text="aaaaaaaaaaaa"></asp:Label>
            
        </div>
    </form>
</body>
</html>
