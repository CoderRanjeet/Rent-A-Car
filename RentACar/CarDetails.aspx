<%@ Page Title="" Language="C#" MasterPageFile="~/RentCar.Master" AutoEventWireup="true" CodeBehind="CarDetails.aspx.cs" Inherits="RentACar.CarDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!-- Page Header Start -->
    <div class="container-fluid page-header">
        <h1 class="display-3 text-uppercase text-white mb-3">Car Detail</h1>
        <div class="d-inline-flex text-white">
            <h6 class="text-uppercase m-0"><a class="text-white" href="Home.aspx">Home</a></h6>
            <h6 class="text-body m-0 px-3">/</h6>
            <h6 class="text-uppercase text-body m-0">Car Detail</h6>
        </div>
    </div>
    <!-- Page Header Start -->

    <!-- Detail Start -->
    <div class="container-fluid pt-5">
        <div class="container pt-5">
            <div class="row">
                <div class="col-lg-8 mb-5">
                    <h1 class="display-4 text-uppercase mb-5"><label runat="server" id="lblCarName"></label></h1>
                    <div class="row mx-n2 mb-3">
                       
                        <div class="col-md-4 col-6 px-2 pb-2">
                             <asp:Image ID="img1" CssClass="img-fluid w-100" runat="server" />
                            <%--<img class="img-fluid w-100" src="img/gallery-2.jpg" alt="">--%>
                        </div>
                        <div class="col-md-4 col-6 px-2 pb-2">
                             <asp:Image ID="img2" CssClass="img-fluid w-100" runat="server" />
                            <%--<img class="img-fluid w-100" src="img/gallery-3.jpg" alt="">--%>
                        </div>
                        <div class="col-md-4 col-6 px-2 pb-2">
                             <asp:Image ID="img3" CssClass="img-fluid w-100" runat="server" />
                            <%--<img class="img-fluid w-100" src="img/gallery-4.jpg" alt="">--%>
                        </div>
                    </div>
                    <label runat="server" id="lblDescription"></label>
                    <div class="row pt-2">
                        <div class="col-md-3 col-6 mb-2">
                            <i class="fa fa-car text-primary mr-2"></i>
                            <span>Model: <label runat="server" id="lblModelYear"></label></span>
                        </div>
                        <div class="col-md-3 col-6 mb-2">
                            <i class="fa fa-cogs text-primary mr-2"></i>
                            <span>Brand: <label runat="server" id="lblBrand"></label></span>
                        </div>
                        <div class="col-md-3 col-6 mb-2">
                            <i class="fa fa-road text-primary mr-2"></i>
                            <span>Seating: <label runat="server" id="lblSeatingCapacity"></label></span>
                        </div>
                        <div class="col-md-3 col-6 mb-2">
                            <i class="fa fa-eye text-primary mr-2"></i>
                            <span>Fuel Type : <label runat="server" id="lblFuelType"></label></span>
                        </div>
                        <div class="col-md-3 col-6 mb-2">
                            <i class="fa fa-car text-primary mr-2"></i>
                            <span>Color: <label runat="server" id="lblCarColor"></label></span>
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
               </div>

                <div class="col-lg-4 mb-5">
                    <div class="bg-secondary p-5">
                        <h3 class="text-primary text-center mb-4">Check Availability</h3>
                      <%--  <div class="form-group">
                             <input type="text" runat="server" id="txtprice" class="form-control" disabled="disabled" />
                        </div>--%>
                     <%--   <div class="form-group">
                            <asp:DropDownList runat="server" ID="ddlHours" class="form-control">
                                 <asp:ListItem Value="0">-- select hours --</asp:ListItem>
                                 <asp:ListItem Value="1"></asp:ListItem>
                                 <asp:ListItem Value="2"></asp:ListItem>
                                 <asp:ListItem Value="3"></asp:ListItem>
                                 <asp:ListItem Value="4"></asp:ListItem>
                                 <asp:ListItem Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Add Extra Hours</label>
                           <asp:TextBox runat="server" ID="txtExtraHours" CssClass="form-control"></asp:TextBox>
                        </div>--%>

                        <div class="form-group">
                            <div class="date" id="date1" data-target-input="nearest">
                                <input type="date" runat="server" id="txtBookDate" class="form-control p-4" placeholder="Pickup Date" />
                            </div>
                        </div>

                        <asp:Label runat="server" ID="lblMsg"></asp:Label>
                       
                        <div class="form-group mb-0">
                            <button class="btn btn-primary btn-block" type="submit" runat="server" id="BtnBooking" onserverclick="BtnBooking_ServerClick" style="height: 50px;">Check and book Now</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Detail End -->


    <!-- Related Car Start -->
    <div class="container-fluid pb-5">
        <div class="container pb-5">
            <h2 class="mb-4">Related Cars</h2>
            <div class="owl-carousel related-carousel position-relative" style="padding: 0 30px;">
                 <asp:Repeater runat="server" ID="RptCars">
                      <ItemTemplate>
                <div class="rent-item">
                    <img class="img-fluid mb-4" src='<%#Eval("Car_img1")%>' alt="">
                    <h4 class="text-uppercase mb-4"><%#Eval("Car_Title")%></h4>
                    <div class="d-flex justify-content-center mb-4">
                        <div class="px-2">
                            <i class="fa fa-car text-primary mr-1"></i>
                            <span><%#Eval("Brand")%></span>
                        </div>
                        <div class="px-2 border-left border-right">
                            <i class="fa fa-cogs text-primary mr-1"></i>
                            <span><%#Eval("Model_Year")%></span>
                        </div>
                        <div class="px-2">
                            <i class="fa fa-road text-primary mr-1"></i>
                            <span><%#Eval("Fuel_Type")%></span>
                        </div>
                    </div>
                     <a class="btn btn-primary px-3 pointer-event" href="#"><%#Eval("Price")%>/Day</a>
                      <asp:LinkButton runat="server" CssClass="btn btn-success" CommandName="Book" CommandArgument='<%#Eval("CarId")%>'>View Details</asp:LinkButton>
                </div>
                </ItemTemplate>
                     </asp:Repeater>
            </div>
        </div>
    </div>
    <!-- Related Car End -->


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
