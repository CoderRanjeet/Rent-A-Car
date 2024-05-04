<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddBrands.aspx.cs" Inherits="RentACar.AddBrands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">

        <div class="pagetitle text-center mb-2">
            <h1>Manage Brands</h1>
        </div>

        <section class="section">
            <div class="card">
                <div class="card-body">
                    <div class="col-lg-6 mt-2 mb-2">
                        <div class="col-12">
                            <label class="form-label">Brand Name</label>
                            <input type="text" class="form-control" runat="server" id="txtBrand">
                        </div>
                    </div>
                </div>
            </div>

            <div class="text-center mb-3 mt-3">
                <button type="submit" class="btn btn-primary" runat="server" id="BtnSubmit" onserverclick="BtnSubmit_ServerClick">Submit</button>
                <button type="reset" class="btn btn-secondary" runat="server" id="BtnReset" onserverclick="BtnReset_ServerClick">Reset</button>
            </div>

        </section>

         <section class="section">
         <div class="card mt-4">
                <h3 class="card-title text-center">All Brands</h3>
                <asp:Repeater runat="server" ID="RptBrands" OnItemCommand="RptBrands_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped table-responsive">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Brand Name</th>
                                    <th>Created Date</th>
                                  
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <th><%#Eval("BrandId")%></th>
                                <th><%#Eval("BrandName")%></th>
                                <td><%#Eval("CreatedDate")%></td>
                               
                                <td>
                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="Edit" CommandArgument='<%#Eval("BrandId")%>'>Edit</asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="Delete" CommandArgument='<%#Eval("BrandId")%>'>Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
               </section>

    </main>

</asp:Content>
