<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddCustomers.aspx.cs" Inherits="RentACar.AddCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">
        <div class="pagetitle text-center mb-2">
            <h1>Manage Customers</h1>
        </div>
        <section class="section">
            <div class="row">
                <div class="card">
                    <div class="card-body">
                        <div class="row g-3  mb-3 mt-3">
                            <div class="col-lg-6">
                                <div class="col-12">
                                    <label class="form-label">Full Name</label>
                                    <input type="text" class="form-control" id="txtName" runat="server">
                                </div>
                                <div class="col-12">
                                    <label class="form-label">Email</label>
                                    <input type="email" class="form-control" id="txtemail" runat="server">
                                </div>
                                <div class="col-12">
                                    <label class="form-label">Password</label>
                                    <input type="password" class="form-control" id="txtpassword" runat="server">
                                </div>                             
                            </div>

                            <div class="col-lg-6">
                                <div class="col-12">
                                    <label class="form-label">Mobile Number</label>
                                    <input type="text" class="form-control" id="txtMobileNo" runat="server">
                                </div>                              

                                <div class="col-12">
                                    <label class="form-label">Address</label>
                                    <input type="text" class="form-control" id="txtAddress" runat="server">
                                </div>

                                   <div class="col-12">
                                    <label class="form-label">Confirm Password</label>
                                    <input type="password" class="form-control" id="txtcpassword" runat="server">
                                </div>  
                            </div>
                        </div>
                    </div>

                    <div class="text-center  mb-3 mt-3">
                        <button type="submit" class="btn btn-primary" id="BtnSubmit" runat="server" onserverclick="BtnSubmit_ServerClick">Submit</button>
                        <button type="reset" class="btn btn-secondary" id="BtnReset" runat="server" onserverclick="BtnReset_ServerClick">Reset</button>
                    </div>
                </div>
            </div>

        </section>

    </main>
</asp:Content>
