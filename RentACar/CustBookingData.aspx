<%@ Page Title="" Language="C#" MasterPageFile="~/RentCar.Master" AutoEventWireup="true" CodeBehind="CustBookingData.aspx.cs" Inherits="RentACar.CustBookingData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="row mt-5">
            <h5><label class="col-form-label">Enter Email </label> </h5>

            <div class="col-md-6">
                <input type="text" class="form-control" id="txtemail" runat="server" />
            </div>
            <div class="col-md-3">
                <asp:Button runat="server" CssClass="btn btn-success" Text="Get Data" ID="BtnGetData" OnClick="BtnGetData_Click" />
            </div>
        </div>

        <div class="mt-2">
        <h5>Note : Booking can cancel within 24 hrs after booking.</h5>
</div>
        <main id="main" class="main">

            <section class="section">
                <div class="card mt-4">
                    <h3 class="card-title text-center">My Booking</h3>
                    <asp:Repeater runat="server" ID="RptBooking" OnItemCommand="RptBooking_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-striped table-responsive">
                                <thead>
                                    <tr>
                                        <th>Booking No.</th>
                                        <th>Customer</th>
                                        <th>Car Name</th>
                                        <th>Price</th>
                                        <th>Days</th>
                                        <th>Total Amt</th>
                                        <th>License Number</th>
                                        <th>Booking Date</th>
                                        <th>Booking Status</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td><%#Eval("BookingId")%></td>
                                    <td><%#Eval("Cust_Name")%></td>
                                    <td><%#Eval("Car_Title")%></td>
                                    <td><%#Eval("Price")%></td>
                                    <td><%#Eval("TotalHours")%></td>
                                    <td><%#Eval("TotalPrice")%></td>
                                    <td><%#Eval("LicenseNumber")%></td>
                                    <td><%#Eval("CreatedDate")%></td>
                                    <td><b><%#Eval("BookingStatus")%> </b></td>  
                                    <td>
                                        <asp:LinkButton runat="server" class="btn btn-danger" CommandArgument='<%# Eval("BookingId") + "," + Eval("CreatedDate")%>'
                                            ID="BtnBookStatus" CommandName="View" Text="Cancel"></asp:LinkButton>
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
    </div>
</asp:Content>
