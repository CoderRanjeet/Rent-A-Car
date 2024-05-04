<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RentedCars.aspx.cs" Inherits="RentACar.RentedCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <main id="main" class="main">
        <div class="pagetitle text-center mb-2">
            <h1>Manage Bookings</h1>
        </div>
        <section class="section">
            <div class="card mt-4">
                <h3 class="card-title text-center">All Old Booking</h3>
                <asp:Repeater runat="server" ID="RptOldBookings">
                    <HeaderTemplate>
                        <table class="table table-bordered table-striped table-responsive">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Customer</th>
                                    <th>Car Name</th>
                                    <th>Price</th>
                                    <th>Hours</th>
                                    <th>Total Amt</th>
                                    <th>Status</th>
                                    <th>Booking Date</th>
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
                                <td><%#Eval("BookingStatus")%></td>
                                <td><%#Eval("BookingDate")%></td>
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
