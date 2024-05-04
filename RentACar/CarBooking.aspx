<%@ Page Title="" Language="C#" MasterPageFile="~/RentCar.Master" AutoEventWireup="true" CodeBehind="CarBooking.aspx.cs" Inherits="RentACar.CarBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Header Start -->
    <div class="container-fluid page-header">
        <h1 class="display-3 text-uppercase text-white mb-3">Car Booking</h1>
        <div class="d-inline-flex text-white">
            <h6 class="text-uppercase m-0"><a class="text-white" href="#">Home</a></h6>
            <h6 class="text-body m-0 px-3">/</h6>
            <h6 class="text-uppercase text-body m-0">Car Booking</h6>
        </div>
    </div>
    <!-- Page Header Start -->

    <!-- Detail Start -->
    <div class="container-fluid pt-5">
        <div class="container pt-5 pb-3">
            <h1 class="display-4 text-uppercase mb-5">
                <label runat="server" id="lblCarName"></label>
            </h1>
            <div class="row align-items-center pb-2">
                <div class="col-lg-6 mb-4">
                    <asp:Image ID="img1" CssClass="img-fluid w-100" runat="server" />
                </div>
                <div class="col-lg-6 mb-4">
                    <h4 class="mb-2">
                        <label runat="server" id="lblPrice"></label>
                    </h4>
                    <label runat="server" id="lblDescription"></label>
                    <div class="d-flex pt-1">
                        <h6>Share on:</h6>
                        <div class="d-inline-flex">
                            <a class="px-2" href="#"><i class="fab fa-facebook-f"></i></a>
                            <a class="px-2" href="#"><i class="fab fa-twitter"></i></a>
                            <a class="px-2" href="#"><i class="fab fa-linkedin-in"></i></a>
                            <a class="px-2" href="#"><i class="fab fa-pinterest"></i></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-n3 mt-lg-0 pb-4">

                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-car text-primary mr-2"></i>
                    <span>Model:
                        <label runat="server" id="lblModelYear"></label>
                    </span>
                </div>
                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-cogs text-primary mr-2"></i>
                    <span>Brand:
                        <label runat="server" id="lblBrand"></label>
                    </span>
                </div>
                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-road text-primary mr-2"></i>
                    <span>Seating:
                        <label runat="server" id="lblSeatingCapacity"></label>
                    </span>
                </div>
                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-eye text-primary mr-2"></i>
                    <span>Fuel Type :
                        <label runat="server" id="lblFuelType"></label>
                    </span>
                </div>
                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-car text-primary mr-2"></i>
                    <span>Color:
                        <label runat="server" id="lblCarColor"></label>
                    </span>
                </div>
                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-cogs text-primary mr-2"></i>
                    <span>Power Steering</span>
                </div>
                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-road text-primary mr-2"></i>
                    <span>Best mileage</span>
                </div>
                <div class="col-md-3 col-6 mb-2">
                    <i class="fa fa-eye text-primary mr-2"></i>
                    <span>GPS Navigation</span>
                </div>
            </div>
            <h5>Disclaimer :-
                <br />
                1. If you are drunk at the time of car rental, we will have right to deny you renting.
                <br />
                2. If your licence is not renewed or has been suspended,the car rental company will deny you the services. It is important to ensure your driver's licence is valid before renting a car.
                <br />
                3. While returning a car if we found any kind of damage then customer has to pay extra charges</h5>
        </div>
    </div>
    <!-- Detail End -->


    <!-- Car Booking Start -->
    <div class="container-fluid pb-5">
        <div class="container">
            <div class="row">
                <div class="col-lg-8">
                    <h2 class="mb-4">Personal Detail</h2>
                    <div class="mb-5">
                        <div class="row">
                            <div class="col-6 form-group">
                                <input type="text" class="form-control p-4" runat="server" id="txtFullName" placeholder="Full Name" required="required">
                            </div>
                            <div class="col-6 form-group">
                                <input type="text" class="form-control p-4" runat="server" id="txtFullAddress" placeholder="Full Address" required="required">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 form-group">
                                <input type="email" class="form-control p-4" runat="server" id="txtEmail" placeholder="Your Email" required="required">
                            </div>
                            <div class="col-6 form-group">
                                <%-- <input type="text" class="form-control p-4" runat="server" id="txtMobileNo" placeholder="Mobile Number" required="required">--%>
                                <asp:TextBox ID="txtAltMobileNo" placeholder="Enter phone number" CssClass="form-control p-4" runat="server"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtAltMobileNo" ForeColor="Red" ErrorMessage="Phone number is not valid format (e.g. 8674768766)"
                                    ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                    </div>
                    <h2 class="mb-4">Booking Detail</h2>
                    <div class="mb-5">

                        <div class="row">
                            <div class="col-6 form-group">
                                <label>Car Name</label>
                                <input type="text" runat="server" disabled="disabled" id="txtCarName" class="form-control" />
                            </div>
                            <div class="col-6 form-group">
                                <label>Booking Date</label>
                                <input type="text" runat="server" id="txtBookDate" disabled="disabled" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 form-group">
                                <label>License Number</label>
                                <asp:TextBox ID="txtLicenseNo" placeholder="Enter License Number" CssClass="form-control p-4" runat="server"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ControlToValidate="txtLicenseNo" ValidationExpression="^[a-zA-Z]{2}-\d\d-(19\d\d|20[01][0-9])-\d{7}$" Display="Dynamic" ErrorMessage="Invalid License Number format (e.g. MH-42-1998-9876543)." ForeColor="Red" />
                            </div>
                            <div class="col-6 form-group">
                                <label class="form-label">Payment Option </label>
                                <br />
                                <asp:CheckBox ID="CheckBox1" CssClass="me-3" runat="server" Text=" On Cash" />
                                <asp:CheckBox ID="CheckBox2" CssClass="me-3" runat="server" Text=" UPI" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                <asp:CheckBox ID="CheckBox3" runat="server" Text=" Credit/Debit Card" AutoPostBack="true" OnCheckedChanged="CheckBox3_CheckedChanged" />
                            </div>
                        </div>

                        <div id="divupi" runat="server" class="row" visible="false">
                            <div class="col-6 form-group">
                                <label>Enter UPI here</label>
                                <input type="text" runat="server" id="txtUPI" class="form-control" />
                            </div>
                            <div class="col-6">
                                <button runat="server" class="btn btn-success btn-lg mt-4" id="BtnUpiPayment" onserverclick="BtnUpiPayment_ServerClick">Pay</button>
                            </div>
                        </div>

                        <div id="divpaymentcard" runat="server" visible="false">
                            <div class="row">
                                <label>Total Amount :  </label>
                                <asp:Label runat="server" ID="lblAmount"></asp:Label>
                            </div>
                            <div class="row mb-3">
                                <label>Bank Name :  </label>
                                <asp:DropDownList runat="server" ID="ddlbanks" CssClass="form-control w-50">
                                    <asp:ListItem>-- select Bank --</asp:ListItem>
                                    <asp:ListItem>Hdfc Bank</asp:ListItem>
                                    <asp:ListItem>SBI Bank</asp:ListItem>
                                    <asp:ListItem>Union Bank</asp:ListItem>
                                    <asp:ListItem>BOI Bank</asp:ListItem>
                                    <asp:ListItem>Kotak Bank</asp:ListItem>
                                    <asp:ListItem>Maharashtra Bank</asp:ListItem>
                                    <asp:ListItem>CBI Bank</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="row">
                                <asp:Label ID="lblcardnumber" runat="server" Text="Card Number"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtCardNumber" runat="server" placeholder="Enter card number" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCardNumber" runat="server" ControlToValidate="txtCardNumber"
                                        ErrorMessage="Card Number is required." ForeColor="Red" />

                                    <asp:RegularExpressionValidator ID="revCardNumber" runat="server" ControlToValidate="txtCardNumber" ValidationExpression="^[1-9][0-9]{3}[1-3]{4}[0-9]{4}[0-9]{4}$" Display="Dynamic"
                                        ErrorMessage="Invalid card number format. Ex. 67476456453345" ForeColor="Red" />
                                </div>
                            </div>

                            <div class="row">
                                <asp:Label ID="Label6" runat="server" Text="CVV Number"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtCardholder" placeholder="Enter CVV Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                        ControlToValidate="txtCardholder">CVV Number is Required </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-6">
                                <button runat="server" class="btn btn-success btn-lg mt-4" id="BtnCardPayment" onserverclick="BtnCardPayment_ServerClick">Pay</button>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="bg-secondary p-5 mb-5">
                        <h2 class="text-primary mb-4">Booking</h2>
                        <div class="form-group">
                            <label class="form-label">Price</label>
                            <input type="text" runat="server" id="txtprice" class="form-control" disabled="disabled" />
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="ddlHours" class="form-control" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">-- select Days --</asp:ListItem>
                                <asp:ListItem Value="1"></asp:ListItem>
                                <asp:ListItem Value="2"></asp:ListItem>
                                <asp:ListItem Value="3"></asp:ListItem>
                                <asp:ListItem Value="4"></asp:ListItem>
                                <asp:ListItem Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%-- <div class="form-group">
                            <label class="form-label">Add Extra Hours</label>
                            <asp:TextBox runat="server" ID="txtExtraHours" CssClass="form-control"></asp:TextBox>
                        </div>--%>
                        <div class="form-group">
                            <label class="form-label">Total Amount</label>
                            <asp:Label runat="server" ID="lblTotalAmt" CssClass="form-control"></asp:Label>
                        </div>
                        <button class="btn btn-block btn-primary py-3" runat="server" id="BtnReserve" onserverclick="BtnReserve_ServerClick">Reserve Now</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Car Booking End -->


    <!-- Vendor Start -->
    <div class="container-fluid py-5">
        <div class="container py-5">
            <div class="owl-carousel vendor-carousel">
                <div class="bg-light p-4">
                    <img src="img/vendor-1.png" alt="">
                </div>
                <div class="bg-light p-4">
                    <img src="img/vendor-2.png" alt="">
                </div>
                <div class="bg-light p-4">
                    <img src="img/vendor-3.png" alt="">
                </div>
                <div class="bg-light p-4">
                    <img src="img/vendor-4.png" alt="">
                </div>
                <div class="bg-light p-4">
                    <img src="img/vendor-5.png" alt="">
                </div>
                <div class="bg-light p-4">
                    <img src="img/vendor-6.png" alt="">
                </div>
                <div class="bg-light p-4">
                    <img src="img/vendor-7.png" alt="">
                </div>
                <div class="bg-light p-4">
                    <img src="img/vendor-8.png" alt="">
                </div>
            </div>
        </div>
    </div>
    <!-- Vendor End -->

</asp:Content>
