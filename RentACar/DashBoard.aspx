<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="RentACar.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">
        <div class="pagetitle">
            <h1>Dashboard</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Dashboard</li>
                </ol>
            </nav>
        </div>

        <section class="section dashboard">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card sales-card">
                                <div class="card-body">
                                    <h5 class="card-title">Total Bookings <span>| This Month</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-check2-circle"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>
                                                <asp:Label runat="server" ID="lblMonthBookings"></asp:Label></h6>
                                            <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card sales-card">
                                <div class="card-body">
                                    <h5 class="card-title">All Customers <span>| Total</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-person-fill-up"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>
                                                <asp:Label runat="server" ID="lblAllCustomers"></asp:Label></h6>
                                            <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card sales-card">
                                <div class="card-body">
                                    <h5 class="card-title">All Bookings <span>| Upto All</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-calendar2-check"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>
                                                <asp:Label runat="server" ID="lblAllBookings"></asp:Label></h6>
                                            <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-xxl-3 col-md-3">
                            <div class="card info-card sales-card">
                                <div class="card-body">
                                    <h5 class="card-title">Listed Vehicles <span>| Total</span></h5>

                                    <div class="d-flex align-items-center">
                                        <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                            <i class="bi bi-car-front-fill"></i>
                                        </div>
                                        <div class="ps-3">
                                            <h6>
                                                <asp:Label runat="server" ID="lblTotalCars"></asp:Label></h6>
                                            <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <section class="section">
                            <div class="col-12">
                                <div class="card recent-sales overflow-auto">
                                    <div class="card-body">
                                        <h5 class="card-title">Recent Listed Cars <span>| Total</span></h5>
                                        <asp:Repeater runat="server" ID="RptCars">
                                            <HeaderTemplate>
                                                <table class="table table-bordered table-striped table-responsive">
                                                    <thead>
                                                        <tr>
                                                            <th>Sr.No</th>
                                                            <th>Car</th>
                                                            <th>Car Name</th>
                                                            <th>Brand</th>
                                                            <th>Price</th>
                                                            <th>Model Year</th>
                                                            <th>Seating</th>
                                                            <th>Fuel Type</th>
                                                            <th>Created Date</th>
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tbody>
                                                    <tr>
                                                        <td><%#Eval("CarId")%></td>
                                                        <td><img src='<%#Eval("Car_img1")%>' width="80" /></td>
                                                        <td><%#Eval("Car_Title")%></td>
                                                        <td><%#Eval("Brand")%></td>
                                                        <td><%#Eval("Price")%></td>
                                                        <td><%#Eval("Model_Year")%> </td>
                                                        <td><%#Eval("Seating_Capacity")%></td>
                                                        <td><%#Eval("Fuel_Type")%></td>
                                                        <td><%#Eval("CreatedDate")%></td>
                                                    </tr>
                                                </tbody>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:Button runat="server" Text="See More" CssClass="btn btn-primary float-end" ID="SeeCars" OnClick="SeeCars_Click" />
                                    </div>
                                </div>
                            </div>
                        </section>

                        <section class="section">
                            <div class="col-12">
                                <div class="card recent-sales overflow-auto">
                                    <div class="card-body">
                                        <h5 class="card-title">Recent Bookings <span>| Today</span></h5>
                                        <asp:Repeater runat="server" ID="RptBookings">
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
                                                    </tr>
                                                </tbody>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:Button runat="server" Text="See More" CssClass="btn btn-primary float-end" ID="SeeBookings" OnClick="SeeBookings_Click" />
                                    </div>
                                </div>
                            </div>
                        </section>

                        <section class="section">
                            <div class="col-12">
                                <div class="card recent-sales overflow-auto">
                                    <div class="card-body">
                                        <h5 class="card-title">Recent Cutomers <span>| All</span></h5>
                                        <asp:Repeater runat="server" ID="RptCustomers">
                                            <HeaderTemplate>
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
                                            </HeaderTemplate>
                                            <ItemTemplate>
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
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:Button runat="server" Text="See More" CssClass="btn btn-primary float-end" ID="SeeCustomers" OnClick="SeeCustomers_Click" />
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </section>

    </main>
</asp:Content>
