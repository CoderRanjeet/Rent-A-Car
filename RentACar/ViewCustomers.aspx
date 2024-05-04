<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewCustomers.aspx.cs" Inherits="RentACar.ViewCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">

        <div class="pagetitle text-center mb-2">
            <h1>Manage Customers</h1>
        </div>
        <section class="section">
            <div class="card mt-4">
                <h3 class="card-title text-center">All Customers</h3>
                <asp:Repeater runat="server" ID="RptCustomers">
                    <headertemplate>
                        <table class="table table-bordered table-striped table-responsive">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Customer</th>
                                    <th>Email</th>
                                    <th>Mobile No.</th>
                                    <th>Address</th>
                                    <th>Created Date</th>
                                    
                                </tr>
                            </thead>
                    </headertemplate>
                    <itemtemplate>
                        <tbody>
                            <tr>
                                <th><%#Eval("Cust_Id")%></th>
                                <th><%#Eval("Cust_Name")%></th>
                                <th><%#Eval("Email")%></th>
                                <th><%#Eval("Mobile_No")%></th>
                                <th><%#Eval("Address")%></th>
                                <td><%#Eval("CreatedDate")%></td>
                              
                            </tr>
                        </tbody>
                    </itemtemplate>
                    <footertemplate>
                        </table>
                    </footertemplate>
                </asp:Repeater>
            </div>
        </section>
    </main>

</asp:Content>
