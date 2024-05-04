<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddBookings.aspx.cs" Inherits="RentACar.AddBookings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="main" class="main">

        <div class="pagetitle text-center mb-2">
            <h1>Manage Booking</h1>
        </div>

        <section class="section">
            <div class="row">
                <div class="card">
                    <div class="card-body">
                        <div class="row g-3  mb-3 mt-3">
                            <div class="col-lg-6">
                                <div class="col-12">
                                    <label class="form-label">Full Name</label>
                                    <input type="text" class="form-control" id="txtFullName" runat="server">
                                </div>
                                <div class="col-12">
                                    <label class="form-label">Email</label>
                                    <input type="email" class="form-control" id="txtEmail" runat="server">
                                </div>
                                <div class="col-12">
                                    <label class="form-label">Brand</label>
                                    <asp:DropDownList runat="server" ID="ddlBrand" class="form-control" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-12 mt-2">
                                    <label>Booking Date</label>
                                    <input type="date" runat="server" id="txtBookDate" class="form-control" />
                                </div>

                                <div class="col-12 mt-2">
                                    <label class="form-label">Select Days</label>
                                    <asp:DropDownList runat="server" ID="ddlHours" class="form-control" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">-- select Days --</asp:ListItem>
                                        <asp:ListItem Value="1"></asp:ListItem>
                                        <asp:ListItem Value="2"></asp:ListItem>
                                        <asp:ListItem Value="3"></asp:ListItem>
                                        <asp:ListItem Value="4"></asp:ListItem>
                                        <asp:ListItem Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-12 mt-2">
                                    <label>License Number</label>
                                    <asp:TextBox ID="txtLicenseNo" placeholder="Enter License Number" CssClass="form-control" runat="server"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ControlToValidate="txtLicenseNo" ValidationExpression="^[a-zA-Z]{2}-\d\d-(19\d\d|20[01][0-9])-\d{7}$" Display="Dynamic" ErrorMessage="Invalid License Number format (e.g. MH-42-1998-9876543)." ForeColor="Red" />

                                </div>
                            </div>


                            <div class="col-lg-6">
                                <div class="col-12">
                                    <label class="form-label">Mobile Number</label>
                                    <asp:TextBox ID="txtAltMobileNo" placeholder="Enter phone number" CssClass="form-control" runat="server"></asp:TextBox>

                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtAltMobileNo" ForeColor="Red" ErrorMessage="Phone number is not valid format (e.g. 8674768766)"
                                    ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>

                                </div>

                                <div class="col-12">
                                    <label class="form-label">Address</label>
                                    <input type="text" class="form-control" id="txtFullAddress" runat="server">
                                </div>
                                <div class="col-12">
                                    <label>Car Name</label>
                                    <asp:DropDownList runat="server" ID="ddlCars" class="form-control" OnSelectedIndexChanged="ddlCars_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12 mt-2">
                                    <label class="form-label">Price</label>
                                    <input type="text" runat="server" id="txtprice" class="form-control" disabled="disabled" />
                                </div>

                                <div class="col-12 mt-2">
                                    <label class="form-label">Total Amount</label>
                                    <input type="text" runat="server" id="txtTotalAmt" class="form-control" disabled="disabled" />

                                </div>

                                <div class="col-12 mt-2">
                                    <label class="form-label">Payment Option </label><br />
                                    <asp:CheckBox ID="CheckBox1" CssClass="me-3" runat="server" Text=" On Cash" />
                                    <asp:CheckBox ID="CheckBox2" CssClass="me-3" runat="server" Text=" UPI" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                    <asp:CheckBox ID="CheckBox3" runat="server" Text=" Credit/Debit Card" AutoPostBack="true" OnCheckedChanged="CheckBox3_CheckedChanged" />
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
                    </div>
                </div>

                <div class="text-center  mb-3 mt-3">
                    <button type="submit" class="btn btn-primary" id="BtnSubmit" runat="server" onserverclick="BtnSubmit_ServerClick">Submit</button>
                    <button type="reset" class="btn btn-secondary" id="BtnReset" runat="server" onserverclick="BtnReset_ServerClick">Reset</button>
                </div>
            </div>

        </section>

    </main>
</asp:Content>
