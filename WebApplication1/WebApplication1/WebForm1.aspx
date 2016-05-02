<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<!--#include file="header.inc"-->
	<div class="clearfix"></div>

<div class="clearfix"></div><br />
    <div class="container">
    <form id="form1" runat="server">
        <div class="GridviewDiv">
            <asp:GridView runat="server" ID="gvDetails" ShowFooter="true" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" DataKeyNames="book_id,book_name,book_author,book_ISBN" OnPageIndexChanging="gvDetails_PageIndexChanging" OnRowCancelingEdit="gvDetails_RowCancelingEdit"
                OnRowEditing="gvDetails_RowEditing" OnRowUpdating="gvDetails_RowUpdating" OnRowDeleting="gvDetails_RowDeleting" OnRowCommand ="gvDetails_RowCommand" CssClass="table table-bordered table-responsive">
                <HeaderStyle CssClass="headerstyle" />
                    <Columns>

                        <asp:BoundField DataField="book_id" HeaderText="Book Id" ReadOnly="true" />

                        <asp:TemplateField HeaderText="Book Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("book_name")%>'/>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <asp:TextBox ID="txtBookName" runat="server" Text='<%# Eval("book_name")%>'/>
                            </EditItemTemplate>

                            <FooterTemplate>
                                    <asp:TextBox ID="txtbname" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText = "Book Author">
                            <ItemTemplate>
                                <asp:Label ID="lblBookAuthor" runat="server" Text='<%# Eval("book_author")%>'></asp:Label>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <asp:TextBox ID="txtBookAuthor" runat="server" Text='<%# Eval("book_author")%>'/>
                            </EditItemTemplate>

                            <FooterTemplate>
                                <asp:TextBox ID="txtbauthor" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText = "Book ISBN">
                            <ItemTemplate>
                                <asp:Label ID="lblBookISBN" runat="server" Text='<%# Eval("book_ISBN")%>'></asp:Label>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <asp:TextBox ID="txtBookISBN" runat="server" Text='<%# Eval("book_ISBN")%>'/>
                            </EditItemTemplate>

                            <FooterTemplate>
                                <asp:TextBox ID="txtbISBN" runat="server" />
                                <asp:LinkButton ID="btnAdd" CommandName="AddNew" runat="server" CssClass="btn btn-large btn-info pull-right"><i class="glyphicon glyphicon-plus"></i> &nbsp; Add Records</asp:LinkButton>   
                            </FooterTemplate>
                        </asp:TemplateField>
						<asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                    </Columns>

            </asp:GridView>
            <div id="success_alert" class="alert alert-success" runat="server" Visible="false">
    	        <asp:Label ID="lblresult" runat="server"></asp:Label>
		    </div>
        </div>
        <script type="text/javascript">
            function HideLabel() {
                var seconds = 5;
                setTimeout(function () {
                    document.getElementById("<%=success_alert.ClientID %>").style.display = "none";
                }, seconds * 1000);
            };
    </script>
    </form>
    </div>
    <!--#include file="footer.inc"-->
