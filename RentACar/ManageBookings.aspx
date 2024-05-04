<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageBookings.aspx.cs" Inherits="RentACar.ManageBookings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">
        <div class="pagetitle text-center mb-2">
            <h1>Manage Bookings</h1>
        </div>
        <section class="section">
            <div class="card mt-4">
                <h3 class="card-title text-center">All Booking</h3>
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
                                    <th>Booked Date</th>
                                    <th>Booking Date</th>
                                    <th>Return Date</th>
                                    <th>Booking Status</th>
                                    <th>Status</th>
                                    <th>Change</th>
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
                                <td><%#Eval("CreatedDate")%></td>
                                 <td><%#Eval("BookingDate")%></td>
                                 <td><%#Eval("ReturnDate")%></td>
                                <td><b><%#Eval("BookingStatus")%> </b></td>
                                <td>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlstatus">
                                        <asp:ListItem  Value="0">-- Select Status --</asp:ListItem>
                                        <asp:ListItem Text="Cancelled">Cancel</asp:ListItem>
                                        <asp:ListItem Text="Rented Out">Rented Out</asp:ListItem>
                                        <asp:ListItem Text="Returned">Returned</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:LinkButton runat="server" class="btn btn-success" CommandArgument='<%# Eval("BookingId") %>' ID="BtnBookStatus" CommandName="View" Text="Change"></asp:LinkButton>
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
