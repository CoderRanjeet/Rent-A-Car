<%@ Page Title="" Language="C#" MasterPageFile="~/RentCar.Master" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="RentACar.Cars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Page Header Start -->
    <div class="container-fluid page-header">
        <h1 class="display-3 text-uppercase text-white mb-3">Car Listing</h1>
        <div class="d-inline-flex text-white">
            <h6 class="text-uppercase m-0"><a class="text-white" href="Home.aspx">Home</a></h6>
            <h6 class="text-body m-0 px-3">/</h6>
            <h6 class="text-uppercase text-body m-0">Car Listing</h6>
        </div>
    </div>
    <!-- Page Header Start -->

    <!-- Rent A Car Start -->
    <div class="container-fluid py-5">
        <div class="container pt-5 pb-3">
            <h1 class="display-4 text-uppercase text-center mb-5">Find Your Car</h1>
            <div class="row">
                <asp:Repeater runat="server" ID="RptCars" OnItemCommand="RptCars_ItemCommand">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 mb-2">
                            <div class="rent-item mb-4">
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
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
    <!-- Rent A Car End -->

</asp:Content>
