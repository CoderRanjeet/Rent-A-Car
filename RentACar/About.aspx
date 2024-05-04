<%@ Page Title="" Language="C#" MasterPageFile="~/RentCar.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="RentACar.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Header Start -->
    <div class="container-fluid page-header">
        <h1 class="display-3 text-uppercase text-white mb-3">About</h1>
        <div class="d-inline-flex text-white">
            <h6 class="text-uppercase m-0"><a class="text-white" href="#">Home</a></h6>
            <h6 class="text-body m-0 px-3">/</h6>
            <h6 class="text-uppercase text-body m-0">About</h6>
        </div>
    </div>
    <!-- Page Header Start -->

    <!-- About Start -->
    <div class="container-fluid py-5">
        <div class="container pt-5 pb-3">
            <h1 class="display-4 text-uppercase text-center mb-5">Welcome To <span class="text-primary">Rental Cars</span></h1>

            <div class="row justify-content-center">
                <div class="col-lg-10 text-center">
                    <img class="w-75 mb-4" src="img/about.png" alt="">


                    <p class="text-justify">
                        At Rental Cars, we pride ourselves on delivering a regal journey that transcends ordinary
            transportation. Step into a world where every detail is meticulously curated to ensure your comfort, style,
            and sophistication.
                    </p>

                    <div class="row">
                        <div class="col-md-6">
                            <p class="text-justify">
                                Our fleet of meticulously maintained, high-end vehicles represents the epitome of
                    automotive elegance. From sleek sedans to spacious SUVs, each vehicle in our collection is chosen to
                    provide a seamless blend of opulence and performance. Immerse yourself in the plush interiors,
                    cutting-edge technology, and superior craftsmanship that define our fleet.
                            </p>
                        </div>

                        <div class="col-md-6">
                            <img src="img/car-rent-2.png" width="250" alt="Luxury Car" class="img-fluid rounded">
                        </div>
                    </div>

                    <p class="text-justify">
                        But Rental Cars is more than just a mode of transportation; it's an experience tailored
            to your every need. Our professional chauffeurs are not just drivers; they are ambassadors of luxury,
            ensuring that your journey is not only safe and efficient but also marked by impeccable service. From the
            moment you step into our vehicles, you can expect a level of hospitality that goes above and beyond.
                    </p>

                    <p class="text-justify">
                        Whether you're headed to a business meeting, special event, or simply desire a taste of
            the extraordinary in your daily commute, Rental Cars is your trusted partner in refined transportation. We
            understand the value of your time and the importance of making a lasting impression, and we are committed to
            exceeding your expectations at every turn.
                    </p>

                    <p class="text-justify">
                        Indulge in the Rental Cars experience and elevate your travel to a level of sophistication
            that is truly unmatched. Discover a new standard of luxury, where every ride is an opportunity to embrace
            elegance, comfort, and a touch of royalty. Welcome aboard – your journey with Rental Cars begins here.
                    </p>
                </div>

                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-4 mb-2">
                    <div class="d-flex align-items-center bg-light p-4 mb-4" style="height: 150px;">
                        <div class="d-flex align-items-center justify-content-center flex-shrink-0 bg-primary ml-n4 mr-4" style="width: 100px; height: 100px;">
                            <i class="fa fa-2x fa-headset text-secondary"></i>
                        </div>
                        <h4 class="text-uppercase m-0">24/7 Car Rental Support</h4>
                    </div>
                </div>
                <div class="col-lg-4 mb-2">
                    <div class="d-flex align-items-center bg-secondary p-4 mb-4" style="height: 150px;">
                        <div class="d-flex align-items-center justify-content-center flex-shrink-0 bg-primary ml-n4 mr-4" style="width: 100px; height: 100px;">
                            <i class="fa fa-2x fa-car text-secondary"></i>
                        </div>
                        <h4 class="text-light text-uppercase m-0">Car Reservation Anytime</h4>
                    </div>
                </div>
                <div class="col-lg-4 mb-2">
                    <div class="d-flex align-items-center bg-light p-4 mb-4" style="height: 150px;">
                        <div class="d-flex align-items-center justify-content-center flex-shrink-0 bg-primary ml-n4 mr-4" style="width: 100px; height: 100px;">
                            <i class="fa fa-2x fa-map-marker-alt text-secondary"></i>
                        </div>
                        <h4 class="text-uppercase m-0">Lots Of Pickup Locations</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- About End -->


</asp:Content>
