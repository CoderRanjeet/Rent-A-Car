<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewCars.aspx.cs" Inherits="RentACar.ViewCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <main id="main" class="main">

        <div class="pagetitle text-center mb-2">
            <h1>Manage Cars</h1>
        </div>
     <section class="section">
         <div class="card mt-4">
                <h3 class="card-title text-center">All Cars</h3>
                <asp:Repeater runat="server" ID="RptCars" OnItemCommand="RptCars_ItemCommand">
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
                                    <th>Action</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("CarId")%></td>
                                <td><img src='<%#Eval("Car_img1")%>' width="80" /></td>
                                <td><%#Eval("Car_Title")%></th>
                                <td><%#Eval("Brand")%></th>
                                <td><%#Eval("Price")%></th>
                                <td><%#Eval("Model_Year")%></td>
                                <td><%#Eval("Seating_Capacity")%></td>
                                <td><%#Eval("Fuel_Type")%></td>
                                
                                <td>
                                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="Edit" CommandArgument='<%#Eval("CarId")%>'>Edit</asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="Delete" CommandArgument='<%#Eval("CarId")%>'>Delete</asp:LinkButton>
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
