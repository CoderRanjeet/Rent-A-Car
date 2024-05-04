<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditCar.aspx.cs" Inherits="RentACar.EditCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <main id="main" class="main">
        <div class="pagetitle text-center mb-2">
            <h1>Manage Cars</h1>
        </div>
        <section class="section">          
                <div class="card">
                    <div class="card-body">
                        <div class="row g-3  mb-3 mt-3">
                            <div class="col-lg-6">
                                <div class="col-12">
                                    <label class="form-label">Brand</label>
                                    <asp:DropDownList runat="server" ID="ddlBrand" class="form-control">                                      
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12 mt-2">
                                    <label class="form-label">Car Title</label>
                                    <input type="text" runat="server" class="form-control" id="txtCarTitle">
                                </div>

                                <div class="col-12 mt-2">
                                    <label class="form-label">Price (Per Day)</label>
                                    <input type="text" runat="server" class="form-control" id="txtPrice">
                                </div>

                                 <div class="col-12 mt-2">
                                    <label class="form-label">Car Color</label>
                                    <input type="text" runat="server" class="form-control" id="txtCarColor">
                                </div>

                                <div class="col-12 mt-4">
                                    <label class="form-label">Car Image2</label><br />
                                     <asp:Image ID="img2" runat="server" />
                                    <input type="file" runat="server" class="form-control" id="txtCarImg2">
                                </div>

                                  <div class="col-12 mt-2">
                                    <label class="form-label">Car Image3</label><br />
                                     <asp:Image ID="img3" runat="server" />
                                    <input type="file" runat="server" class="form-control" id="txtCarImg3">
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="col-12">
                                    <label class="form-label">Model Year</label>
                                    <input type="text" runat="server" class="form-control" id="txtModelYear">
                                </div>
                                <div class="col-12 mt-2">
                                    <label class="form-label">Seating Capacity</label>
                                    <input type="text" runat="server" class="form-control" id="txtSeatingType">
                                </div>
                                <div class="col-12 mt-2">
                                    <label class="form-label">Fuel Type</label>
                                    <asp:DropDownList runat="server" ID="ddlFuelType" class="form-control">
                                        <asp:ListItem Value="0">-- Select Fuel Type --</asp:ListItem>
                                        <asp:ListItem Value="Petrol">Petrol</asp:ListItem>
                                        <asp:ListItem Value="Diesel">Diesel</asp:ListItem>
                                        <asp:ListItem Value="CNG">CNG</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                
                            <div class="col-12 mt-2">
                                <label class="form-label">Car Description</label>
                                <textarea runat="server" id="txtCarDesc" class="form-control"></textarea>
                            </div>

                                <div class="col-12 mt-2">
                                    <label class="form-label">Car Image</label><br />
                                    <asp:Image ID="img1" runat="server" />
                                    <input type="file" runat="server" class="form-control" id="txtCarImg1">
                                </div>               
                            </div>

                        </div>
                    </div>

                    <div class="text-center  mb-3 mt-3">
                        <button type="submit" class="btn btn-primary" runat="server" id="BtnUpdate" onserverclick="BtnUpdate_ServerClick">Update</button>
                        <button type="reset" class="btn btn-secondary" runat="server" id="BtnReset" onserverclick="BtnReset_ServerClick">Reset</button>
                    </div>
                </div>
           
        </section>
    </main>

</asp:Content>
