<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddExtraCharges.aspx.cs" Inherits="RentACar.AddExtraCharges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">
        <div class="pagetitle text-center mb-2">
            <h1>Add Extra Charges</h1>
        </div>
        <section class="section">
            <div class="card">
                <div class="card-body">
                    <div class="row g-3  mb-3 mt-3">
                        <div class="col-lg-6">
                            <div class="col-12 mt-2">
                                <label class="form-label">Customer Name</label>
                                <input type="text" runat="server" class="form-control" id="txtCustName">
                            </div>

                            <div class="col-12 mt-2">
                                <label class="form-label">Booking No.</label>
                                <input type="text" runat="server" class="form-control" id="txtBookingNo">
                            </div>
                        </div>

                        <div class="col-lg-6">

                            <div class="col-12 mt-2">
                                <label class="form-label">Issue Type</label>
                                <asp:DropDownList runat="server" ID="ddlIssueType" class="form-control">
                                    <asp:ListItem Value="0">-- Select Fuel Type --</asp:ListItem>
                                    <asp:ListItem Value="Petrol">Engine</asp:ListItem>
                                    <asp:ListItem Value="Diesel">Tyre</asp:ListItem>
                                    <asp:ListItem Value="CNG">other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-12">
                                <label class="form-label">charges</label>
                                <input type="text" runat="server" class="form-control" id="txtCharges">
                            </div>
                            <div class="col-12 mt-2">
                                <label class="form-label">Issue Description</label>
                                <input type="text" runat="server" class="form-control" id="txtDescription">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="text-center  mb-3 mt-3">
                    <button type="submit" class="btn btn-primary" runat="server" id="BtnSubmit" onserverclick="BtnSubmit_ServerClick">Submit</button>
                    <button type="reset" class="btn btn-secondary" runat="server" id="BtnReset" onserverclick="BtnReset_ServerClick">Reset</button>
                </div>
            </div>

        </section>
    </main>


    <div class="pagetitle text-center mb-2">
        <h1>Charges</h1>
    </div>
    <section class="section">
        <div class="card mt-4">
            <h3 class="card-title text-center">All Charges</h3>
            <asp:Repeater runat="server" ID="RptCharges">
                <HeaderTemplate>
                    <table class="table table-bordered table-striped table-responsive">
                        <thead>
                            <tr>
                                <th>Sr.No</th>
                                <th>customer name</th>
                                <th>Booking no</th>
                                <th>Issue </th>
                                <th>Charges</th>
                                <th>Description</th>
                                <th>Created Date</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%#Eval("CostId")%></td>
                            <td><%#Eval("Customer_Name")%>
                            </th><td><%#Eval("Booking_No")%> </th>
                            <td><%#Eval("Issue_Type")%> </th>
                            <td><%#Eval("Charges")%></td>
                            <td><%#Eval("Description")%></td>
                            <td><%#Eval("CreatedDate")%></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </section>

</asp:Content>
